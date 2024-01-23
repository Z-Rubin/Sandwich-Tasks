using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Text;
using static System.Text.Json.JsonElement;


namespace Orderbook
{

    public partial class Orderbook : Form
    {
        public Orderbook orderbookInstance;
        public Orderbook()
        {
            InitializeComponent();
            orderbookInstance = this;  // Initialize the instance variable
        }



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

                    // Assume the structure is uniform, and use the first element to create columns
                    foreach (var property in firstElement.EnumerateObject())
                    {
                        dataTable.Columns.Add(property.Name, typeof(string)); // Adjust the data type as needed
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
            string apiUrl = "https://www.bitmex.com/api/v1/orderBook/L2?symbol=XBT&depth=25";
            string responseBody;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    // Check if the request was successful (status code 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        responseBody = response.Content.ReadAsStringAsync().Result;
                        OutputRichTextBox.Text = responseBody;
                        JsonDocument jsonResponse = JsonDocument.Parse(responseBody);

                        var dataTable = ConvertJsonDocumentToDataTable(jsonResponse);
                        dataGridView1.DataSource = dataTable;


                        // Display the response string
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        // Display an error message if the request was not successful
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // Display any exception that occurred during the request
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        private async void SubscribeButton_Click(object sender, EventArgs e)
        {
            string socketUrl = "wss://ws.bitmex.com/realtime?subscribe=instrument,orderBookL2_25:XBTUSD";

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

                        // Convert complete string to json
                        JsonDocument completeJson = JsonDocument.Parse(completeMessage);
                        var dataTableSocket = orderbookInstance.ConvertJsonDocumentToDataTable(completeJson);

                        JsonElement root = completeJson.RootElement;

                        List<string> keysList = new List<string>();


                        // Iterate over the properties and add the keys to the list
                        foreach (JsonProperty property in root.EnumerateObject())
                        {
                            string key = property.Name;
                            keysList.Add(key);

                        }



                        if (keysList.Contains("action")) {

                            JsonElement dataElement = root.GetProperty("data");

                            if (root.GetProperty("action").GetString() == "partial")
                            {
                                orderbookInstance.OutputRichtextBox2.Text = completeMessage;

                                // Extract the "data" property
                                orderbookInstance.OutputRichtextBox2.Text = dataElement.ToString();

                                // Create a new JSON object with only the "data" property
                                JsonDocument newDataJsonDocument = JsonDocument.Parse(dataElement.ToString());



                                dataTableSocket = orderbookInstance.ConvertJsonDocumentToDataTable(newDataJsonDocument);
                                orderbookInstance.dataGridView2.DataSource = dataTableSocket;

                            }
                            else if (root.GetProperty("action").GetString() == "update")
                            {
                                messageBuilder.Clear();

                            }
                            else if (root.GetProperty("action").GetString() == "insert")
                            {
                                AddJsonToDataTable(dataElement.ToString(), dataTableSocket);
                                //MessageBox.Show(dataElement.ToString(), "insert Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                            }
                            else if (root.GetProperty("action").GetString() == "delete")
                            {
                                messageBuilder.Clear();

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

            // Assuming the keys in the JSON match the column names in the DataTable
            newRow["symbol"] = jsonElement.GetProperty("symbol").GetString();
            newRow["id"] = jsonElement.GetProperty("id").GetInt64();
            newRow["side"] = jsonElement.GetProperty("side").GetString();
            newRow["size"] = jsonElement.GetProperty("size").GetInt64();
            newRow["price"] = jsonElement.GetProperty("price").GetSingle();
            newRow["timestamp"] = jsonElement.GetProperty("timestamp").GetDateTime();

            // Add the new row to the DataTable
            dataTable.Rows.Add(newRow);
        }


   


    }
}
