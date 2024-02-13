using log4net.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;



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

        public static DataTable buyTable = new DataTable();
        public static DataTable sellTable = new DataTable();


        private async void SubscribeButton_Click(object sender, EventArgs e)
        {
            string Token = InputTokenRichTextBox.Text;

            string socketUrl = $"wss://ws.bitmex.com/realtime?subscribe=orderBookL2_25:{Token}";

            await ConnectWebSocket(socketUrl);
        }

        async Task ConnectWebSocket(string socketUrl)
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

        async Task ReceiveMessages(ClientWebSocket webSocket)
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

        public void updateOutput()
        {           
            label1.Text = orderbook.length.ToString();
        }
        public async Task processDataReceived(JsonElement root)
        {
            string action = root.GetProperty("action").ToString();
            try
            {
                if (action == "partial")
                {
                    partialAction(root);

                    dataGridView1.DataSource = orderbook.orders;                                           

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
                    Logger.Info($"{action} is not catered for yet");
                }

                updateOutput();



            }
            catch (Exception ex)
            {
                Logger.Error($"Error processing action {action}, exception: {ex}");
            }

        }


        // Action methods:
        public void partialAction(JsonElement root)
        {
            // loop through orders and add to orderbook object
            foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
            {
                Order order = new Order(dataPoint);

                orderbook.AddOrder(order);
            }
        }
        public void deleteAction(JsonElement root)
        {
            JsonElement data = root.GetProperty("data");
            if (data.GetArrayLength() > 0)
            {
                foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
                {
                    orderbook.DeleteOrder(dataPoint.GetProperty("id").ToString());
                }
            }
            else
            {
                orderbook.DeleteOrder(data.GetProperty("id").ToString());
            }
        }
        public void insertAction(JsonElement root)
        {
            JsonElement data = root.GetProperty("data");
            if (data.GetArrayLength() > 0)
            {
                foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
                {
                    Order order = new Order(dataPoint);

                    orderbook.InsertOrder(order);
                }
            }
            else
            {
                Order order = new Order(data);

                orderbook.InsertOrder(order);
            }
        }
        public void updateAction(JsonElement root)
        {
            JsonElement data = root.GetProperty("data");
            if (data.GetArrayLength() > 0)
            {
                foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
                {
                    Order order = new Order(dataPoint);

                    orderbook.UpdateOrder(order);
                }
            }
            else
            {
                Order order = new Order(data);

                orderbook.UpdateOrder(order);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class OrderComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            return y.price.CompareTo(x.price);
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
        public BindingList<Order> orders = new BindingList<Order>();
        public int length { get; set; }
        public Orderbook()
        {

        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            this.length++;
        }
        public void InsertOrder(Order order)
        {
            OrderComparer orderComparer = new OrderComparer();
            // convert to normal list to use binary search
            List<Order> orderList = new List<Order>(orders);

            int index = orderList.BinarySearch(order, orderComparer);
            if (index < 0) 
            { 
                index = ~index; 
            }

            orders.Insert(index, order);
            this.length++;
        }
        public void DeleteOrder(string id)
        {
            List<int> indiciesToRemove = new List<int>();
            for (int i = 0; i < this.length; i++){
                if (orders[i].id == id)
                {
                    indiciesToRemove.Add(i);
                }
            }
            foreach (int index  in indiciesToRemove)
            {
                this.orders.RemoveAt(index);
                this.length--;
            }
        }
        public void UpdateOrder(Order order)
        {
            
            for (int i = 0; i < this.length; i++){
                {
                    if (order.id == this.orders[i].id)
                    {
                        this.orders[i] = order;
                    }
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

        public string ToStringBuy()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in orders)
            {
                if (order.side == "Buy")
                sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }

        public string ToStringSell()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in orders)
            {
                if (order.side == "Sell")
                    sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
    }
}
