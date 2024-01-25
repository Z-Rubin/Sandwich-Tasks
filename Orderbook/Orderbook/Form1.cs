using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Text;
using static System.Text.Json.JsonElement;
using System.Timers;


namespace Orderbook
{

    public partial class Orderbook : Form
    {
        public Orderbook orderbookInstance;
        public Orderbook()
        {
            InitializeComponent();
            orderbookInstance = this;
        }

        private System.Timers.Timer RefreshTimer;


        public DataTable ConvertJsonDocumentToDataTable(JsonDocument jsonDocument)
        {
            DataTable dataTable = new DataTable();

            // Check if the root element is an array
            if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                var arrayEnumerator = jsonDocument.RootElement.EnumerateArray().GetEnumerator();

                // Check if there's at least one element in the array
                if (arrayEnumerator.MoveNext())
                {
                    var firstElement = arrayEnumerator.Current;

                    // use the first element to create columns
                    foreach (var property in firstElement.EnumerateObject())
                    {
                        dataTable.Columns.Add(property.Name, typeof(string));
                    }

                    // Populate the DataTable with JSON data
                    do
                    {
                        DataRow row = dataTable.NewRow();
                        foreach (var property in arrayEnumerator.Current.EnumerateObject())
                        {
                            row[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(row);
                    } while (arrayEnumerator.MoveNext());
                }
            }

            return dataTable;
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (TokenSelectionComboBox.SelectedIndex == -1)
            {

            }
            else
            {
                string apiUrl = $"https://www.bitmex.com/api/v1/orderBook/L2?symbol={TokenSelectionComboBox.Text}&depth=25";
                string responseBody;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            responseBody = response.Content.ReadAsStringAsync().Result;
                            OutputRichTextBox.Text = responseBody;
                            JsonDocument jsonResponse = JsonDocument.Parse(responseBody);

                            var dataTable = ConvertJsonDocumentToDataTable(jsonResponse);
                            dataGridView1.DataSource = dataTable;


                            Console.WriteLine(responseBody);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                }
            }
        }

        public async void SubscribeButton_Click(object sender, EventArgs e)
        {
            RefreshData();
            RefreshTimer = new System.Timers.Timer(5000);

            RefreshTimer.Elapsed += OnTimerElapsed;
            RefreshTimer.AutoReset = true;

            RefreshTimer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Ensure RefreshData is called on the UI thread
            Invoke(new Action(async () => RefreshData()));
        }

        private async void RefreshData()
        {
            // Ensure UI-related operations are performed on the UI thread
            if (InputTokenRichTextBox.InvokeRequired)
            {
                InputTokenRichTextBox.Invoke(new Action(() => RefreshData()));
                return;
            }

            string socketUrl = $"wss://ws.bitmex.com/realtime?subscribe=instrument,orderBookL2_25:{InputTokenRichTextBox.Text}";

            await ConnectWebSocket(socketUrl, orderbookInstance);
        }

        static async Task ConnectWebSocket(string socketUrl, Orderbook orderbookInstance)
        {
            using (ClientWebSocket webSocket = new ClientWebSocket())
            {
                try
                {
                    await webSocket.ConnectAsync(new Uri(socketUrl), CancellationToken.None);
                    Console.WriteLine("WebSocket connected.");

                    await ReceiveMessages(webSocket, orderbookInstance);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static async Task ReceiveMessages(ClientWebSocket webSocket, Orderbook orderbookInstance)
        {
            const int bufferSize = 16384;
            byte[] buffer = new byte[bufferSize];
            StringBuilder messageBuilder = new StringBuilder();

            while (webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string fragment = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    messageBuilder.Append(fragment);

                    if (result.EndOfMessage)
                    {

                        string completeMessage = messageBuilder.ToString();
                        //MessageBox.Show(completeMessage, "WebSocket Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        JsonDocument completeJson = JsonDocument.Parse(completeMessage);
                        var dataTableSocket = orderbookInstance.ConvertJsonDocumentToDataTable(completeJson);

                        JsonElement root = completeJson.RootElement;

                        List<string> keysList = new List<string>();


                        foreach (JsonProperty property in root.EnumerateObject())
                        {
                            string key = property.Name;
                            keysList.Add(key);

                        }



                        if (keysList.Contains("action"))
                        {

                            JsonElement dataElement = root.GetProperty("data");

                            if (root.GetProperty("action").GetString() == "partial")
                            {
                                orderbookInstance.OutputRichtextBox2.Text = completeMessage;

                                orderbookInstance.OutputRichtextBox2.Text = dataElement.ToString();

                                JsonDocument newDataJsonDocument = JsonDocument.Parse(dataElement.ToString());



                                dataTableSocket = orderbookInstance.ConvertJsonDocumentToDataTable(newDataJsonDocument);
                                orderbookInstance.dataGridView2.DataSource = dataTableSocket;

                            }
                            else if (root.GetProperty("action").GetString() == "update")
                            {

                            }
                            else if (root.GetProperty("action").GetString() == "insert")
                            {
                                AddJsonToDataTable(dataElement.ToString(), dataTableSocket);

                            }
                            else if (root.GetProperty("action").GetString() == "delete")
                            {

                            }
                        }

                        // Clear the StringBuilder for the next message
                        messageBuilder.Clear();
                    }
                }
            }
        }
        static void AddJsonToDataTable(string json, DataTable dataTable)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement jsonElement = jsonDocument.RootElement;

            DataRow newRow = dataTable.NewRow();

            newRow["symbol"] = jsonElement.GetProperty("symbol").GetString();
            newRow["id"] = jsonElement.GetProperty("id").GetInt64();
            newRow["side"] = jsonElement.GetProperty("side").GetString();
            newRow["size"] = jsonElement.GetProperty("size").GetInt64();
            newRow["price"] = jsonElement.GetProperty("price").GetSingle();
            newRow["timestamp"] = jsonElement.GetProperty("timestamp").GetDateTime();

            dataTable.Rows.Add(newRow);
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            if (RefreshTimer.Enabled)
            {
                RefreshTimer.Enabled = false;
            } else { RefreshTimer.Enabled = true; }
        }
    }
}
