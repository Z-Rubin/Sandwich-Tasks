using log4net.Core;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;



[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace OrderBookUpdated
{





    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }


        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Orderbook orderbook = new Orderbook();


        private async void SubscribeButton_Click(object sender, EventArgs e)
        {
            string Token = InputTokenRichTextBox.Text;

            string socketUrl = $"wss://ws.bitmex.com/realtime?subscribe=orderBookL2_25:{Token}";

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
                    Logger.Error(ex.Message);
                }
            }
        }

        static async Task ReceiveMessages(ClientWebSocket webSocket)
        {
            const int bufferSize = 8192;
            byte[] buffer = new byte[bufferSize];
            StringBuilder messageBuilder = new StringBuilder();


            while (webSocket.State == WebSocketState.Open)
            {

                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string stringFragment = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    messageBuilder.Append(stringFragment);


                    if (result.EndOfMessage)
                    {
                        string completeMessage = messageBuilder.ToString();

                        JsonDocument jsonDoc = JsonDocument.Parse(completeMessage);

                        JsonElement root = jsonDoc.RootElement;
                        root.TryGetProperty("action", out JsonElement action);
                        if (!action.Equals(null) && action.ToString() != "")
                        {
                            try
                            {
                                processDataReceived(root);
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.Message);
                            }

                        }
       



                        messageBuilder.Clear();
                    }
                }
            }
        }

        public static void processDataReceived(JsonElement root)
        {
            string action = root.GetProperty("action").ToString();
            try
            {
                if (action == "partial")
                {
                    partialAction(root);
                    MessageBox.Show(orderbook.ToString());
                }
                else if (action == "delete")
                {
                    deleteAction(root);
                }
                else if (action == "insert")
                {
                    insertAction(root);
                }
                else if (action == "update")
                {
                    updateAction(root);
                }
                else
                {
                    throw new Exception(string.Format("unknown action encountered: {0}", action));
                }
            } catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

        }

        public static void partialAction(JsonElement root)
        {
            // loop through orders and add to orderbook object
            foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
            {

                Order order = new Order(dataPoint);

                orderbook.AddOrder(order);


            }
        }

        public static void deleteAction(JsonElement root) 
        {
            throw new NotImplementedException();
        }
        public static void insertAction(JsonElement root) 
        {
            throw new NotImplementedException();
        }
        public static void updateAction(JsonElement root)
        {
            throw new NotImplementedException();
        }




    }


    public class Order
    {
        public string symbol { get; set; }
        public string id { get; set; }
        public string side { get; set; }
        public int size { get; set; }
        public double price { get; set; }
        public DateTime timestamp { get; set; }

        public Order(string symbol, string id, string side, int size, double price, DateTime timestamp)
        {
            this.symbol = symbol;
            this.id = id;
            this.side = side;
            this.size = size;
            this.price = price;
            this.timestamp = timestamp;
        }

        public Order(JsonElement root)
        {
            this.symbol = root.GetProperty("symbol").ToString();
            this.id = root.GetProperty("id").ToString();
            this.side = root.GetProperty("side").ToString();
            this.size = root.GetProperty("size").GetInt32();
            this.price = root.GetProperty("price").GetDouble();
            this.timestamp = root.GetProperty("timestamp").GetDateTime();
        }
        public Order()
        {

        }

        public override string ToString()
        {
            return $"Order [Symbol: {symbol}, ID: {id}, Side: {side}, Size: {size}, Price: {price}, Timestamp: {timestamp}]";
        }

    }

    public class Orderbook
    {
        public List<Order> orders = new List<Order>();

        public Orderbook()
        {

        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public void InsertOrder(Order order)
        {
            // adjust this
            orders.Insert(0, order);
        }

        public void DeleteOrder(string id)
        {
            foreach (Order order in orders)
            {
                if (order.id == id)
                {
                    orders.Remove(order);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in orders)
            {
                sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
    }
}
