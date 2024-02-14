using log4net.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.AxHost;



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




        public int BuySizeColumnIndex { get; private set; }
        public int SellSizeColumnIndex { get; private set; }

        public static void OnHeartbeatTimer(object? state)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                Logger?.Error(ex);
            }
        }
        private async void SubscribeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var autoEvent = new AutoResetEvent(false);

                System.Threading.Timer HeartbeatTimer = new System.Threading.Timer(OnHeartbeatTimer, autoEvent, 5000, 5000);

                dgvBuy.AutoGenerateColumns = false;
                dgvSell.AutoGenerateColumns = false;

                string Token = InputTokenRichTextBox.Text;

                string socketUrl = $"wss://ws.bitmex.com/realtime?subscribe=orderBookL2_25:{Token}";

                await ConnectWebSocket(socketUrl);

            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
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
                    Logger.Error(ex);
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
                                await Task.Run(() =>
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        processDataReceived(root);
                                    });


                                });

                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex);
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
        public void processDataReceived(JsonElement root)
        {
            try
            {
                string action = root.GetProperty("action").ToString();

                try
                {

                    if (action == "partial")
                    {
                        partialAction(root);

                        // Assuming orderbook.sellOrders and orderbook.buyOrders are updated inside partialAction
                        // Use BeginInvoke to update the DataGridView on the UI thread
                        dgvSell.BeginInvoke(new Action(() => dgvSell.DataSource = orderbook.sellOrders));
                        dgvBuy.BeginInvoke(new Action(() => dgvBuy.DataSource = orderbook.buyOrders));

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
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }





        // Action methods:
        public void partialAction(JsonElement root)
        {            // loop through orders and add to orderbook object
            foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
            {
                Order order = new Order(dataPoint);
                orderbook.AddOrder(order, orderbook.GetOrders(order.Side));
            }
            dgvBuy.Columns["Price1"].DefaultCellStyle.ForeColor = Color.Green;
            dgvSell.Columns["Price"].DefaultCellStyle.ForeColor = Color.Red;

        }
        public void deleteAction(JsonElement root)
        {
            JsonElement data = root.GetProperty("data");
            if (data.GetArrayLength() > 0)
            {
                foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
                {
                    orderbook.DeleteOrder(dataPoint.GetProperty("id").ToString(), orderbook.GetOrders(dataPoint.GetProperty("side").ToString()));
                }
            }
            else
            {
                orderbook.DeleteOrder(data.GetProperty("id").ToString(), orderbook.GetOrders(data.GetProperty("side").ToString()));
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

                    orderbook.InsertOrder(order, orderbook.GetOrders(order.Side));
                    UpdateCellColour(order);

                }
            }
            else
            {
                Order order = new Order(data);

                orderbook.InsertOrder(order, orderbook.GetOrders(order.Side));
                UpdateCellColour(order);

            }
        }
        public void updateAction(JsonElement root)
        {
            try
            {
                JsonElement data = root.GetProperty("data");
                if (data.GetArrayLength() > 0)
                {
                    foreach (var dataPoint in root.GetProperty("data").EnumerateArray())
                    {
                        Order order = new Order(dataPoint);

                        orderbook.UpdateOrder(order, orderbook.GetOrders(order.Side));

                        UpdateCellColour(order);
                    }
                }
                else
                {
                    Order order = new Order(data);

                    orderbook.UpdateOrder(order, orderbook.GetOrders(order.Side));

                    UpdateCellColour(order);
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }

        // Change Cell Colour on updates and inserts
        public void UpdateCellColour(Order order)
        {
            try
            {
                int CellColour = order.GetCellColour();
                int CellIndex = orderbook.GetOrderIndex(order, orderbook.GetOrders(order.Side));
                ChangeCellColour(order.Side, CellIndex, CellColour);
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void ChangeCellColour(string side, int cellIndex, int cellColour)
        {
            try
            {
                if (side == "Buy")
                {
                    if (cellColour == 1)
                    {
                        dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Green;

                    }
                    else if (cellColour == 2)
                    {
                        dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Red;

                    }
                    else if (cellColour == 0)
                    {
                        dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Black;

                    }
                }
                if (side == "Sell")
                {
                    if (cellColour == 1)
                    {
                        dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Green;

                    }
                    else if (cellColour == 2)
                    {
                        dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Red;

                    }
                    else if (cellColour == 0)
                    {
                        dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Black;

                    }
                }
            }
            catch (Exception ex)
            {
                Logger?.Error($"cellIndex Received: {cellIndex}. Error: {ex}");
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            BuySizeColumnIndex = dgvBuy.Columns["Size1"].Index;
            SellSizeColumnIndex = dgvSell.Columns["Size"].Index;
            dgvBuy.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvSell.DefaultCellStyle.Font = new Font("Tahoma", 12);


        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class OrderComparerBuy : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            return y.Price.CompareTo(x.Price);
        }
    }
    public class OrderComparerSell : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
    public class Order
    {
        public string Symbol { get; set; }
        public string Id { get; set; }
        public string Side { get; set; }
        public int Size { get; set; }
        public int OldSize { get; set; }
        public double Price { get; set; }
        public DateTime Timestamp { get; set; }



        public Order(string symbol, string id, string side, int size, double price, DateTime timestamp)
        {
            this.Symbol = symbol;
            this.Id = id;
            this.Side = side;
            this.Size = size;
            this.Price = price;
            this.Timestamp = timestamp;
            this.OldSize = -1;
        }

        public Order(JsonElement root)
        {
            this.Symbol = root.GetProperty("symbol").ToString();
            this.Id = root.GetProperty("id").ToString();
            this.Side = root.GetProperty("side").ToString();
            this.Size = root.GetProperty("size").GetInt32();
            this.Price = root.GetProperty("price").GetDouble();
            this.Timestamp = root.GetProperty("timestamp").GetDateTime();
            this.OldSize = -1;

        }
        public Order()
        {

        }
        
        public int GetCellColour()
        {
            if (this.OldSize == -1)
            {
                return 0;
            } else if( this.OldSize < this.Size)
            {
                return 1;
            } else
            {
                return 2;
            }
        }

        public override string ToString()
        {
            return $"Order [Symbol: {Symbol}, ID: {Id}, Side: {Side}, Size: {Size}, Price: {Price}, Timestamp: {Timestamp}]";
        }

    }

    public class Orderbook
    {
        public BindingList<Order> sellOrders = new BindingList<Order>();
        public BindingList<Order> buyOrders = new BindingList<Order>();
        public int length { get; set; }
        public Orderbook()
        {

        }

        public BindingList<Order> GetOrders(string orderType)
        {
            if (orderType == "Buy")
            {
                return buyOrders;
            } else
            {
                return sellOrders;
            }
        }
        public void AddOrder(Order order, BindingList<Order> orders)
        {
            if (order.Side == "Buy")
            {
                orders.Add(order);

            }
            else
            {
                orders.Insert(0,order);
            }

            this.length++;
        }
        public void InsertOrder(Order order, BindingList<Order> orders)
        {
            // convert to normal list to use binary search
            List<Order> orderList = new List<Order>(orders);
            int index;
            if (order.Side == "Buy")
            {
                OrderComparerBuy orderComparer = new OrderComparerBuy();
                index = orderList.BinarySearch(order, orderComparer);

            }
            else
            {
                OrderComparerSell orderComparer = new OrderComparerSell();

                index = orderList.BinarySearch(order, orderComparer);

            }
            if (index < 0) 
            { 
                index = ~index; 
            }
      
            orders.Insert(index, order);
            this.length++;
        }
        public void DeleteOrder(string id, BindingList<Order> orders)
        {
            List<int> indiciesToRemove = new List<int>();

            for (int i = 0; i < orders.Count; i++){
                if (orders[i].Id == id)
                {
                    indiciesToRemove.Add(i);
                }
            }
            foreach (int index  in indiciesToRemove)
            {
                orders.RemoveAt(index);
                this.length--;
            }
        }
        public void UpdateOrder(Order order, BindingList<Order> orders)
        {
            
            for (int i = 0; i < orders.Count; i++){
                {
                    if (order.Id == orders[i].Id)
                    {
                        int OldSize = orders[i].Size;                        
                        orders[i] = order;
                        orders[i].OldSize = OldSize;
                    }
                }
            }
        }

        public int GetOrderIndex(Order order, BindingList<Order> orders)
        {

            for (int i = 0; i < orders.Count; i++)
            {
                {
                    if (order.Id == orders[i].Id)
                    {
                        return i;
                    }
                }
            }
            
            return -1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in buyOrders)
            {
                sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }

        public string ToStringBuy()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in buyOrders)
            {
                if (order.Side == "Buy")
                sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }

        public string ToStringSell()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in buyOrders)
            {
                if (order.Side == "Sell")
                    sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
    }
}
