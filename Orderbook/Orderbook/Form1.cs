using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Text;


namespace Orderbook
{

    public partial class Orderbook : Form
    {

        public Orderbook()
        {
            InitializeComponent();
        }


        private DataTable ConvertJsonDocumentToDataTable(JsonDocument jsonDocument)
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
                        JsonDocument jsonResponse = JsonDocument.Parse(responseBody);

                        var dataTable = ConvertJsonDocumentToDataTable(jsonResponse);

                        //OutputRichTextBox.Text = orderBook
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

            await ConnectWebSocket(socketUrl);
        }



        static async Task ConnectWebSocket(string socketUrl)
        {
            using (ClientWebSocket webSocket = new ClientWebSocket())
            {
                try
                {
                    await webSocket.ConnectAsync(new Uri(socketUrl), CancellationToken.None);
                    Console.WriteLine("WebSocket connected.");

                    await ReceiveMessages(webSocket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static async Task ReceiveMessages(ClientWebSocket webSocket)
        {
            byte[] buffer = new byte[16384];
            while (webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    MessageBox.Show(message, "WebSocket Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Console.WriteLine($"Received message: {message}");
                }
            }
        }





    }
}
