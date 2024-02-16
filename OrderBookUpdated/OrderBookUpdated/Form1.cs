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
using System.Text.Json.Serialization;
using System.Runtime.Serialization;



[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace OrderBookUpdated
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Boolean Connected { get; private set; }
        public List<pnlOrderbook> Panels { get; private set; } = new();
        public ClientWebSocket WebSocket { get; private set; }
        public List<Orderbook> Orderbooks = new();
        public JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public List<Subscription> ActiveSubscriptions = new();

        public void OnHeartbeatTimer(object? state)
        {
            try
            {
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                Logger?.Error(ex);
            }
        }
        private async void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string Token = cbSelectToken.Text;
                TopicType Topic = (TopicType)Enum.Parse(typeof(TopicType), cbSubscriptionTopics.Text, true);
                TopicTokenPair TTP = new(Topic, cbSelectToken.Text);
                string argsString = TTP.ToArgsString();

                if (!Connected)
                {
                    await ConnectWebSocket();
                }

                Subscription NewSubscription = new(argsString);
                int index = ActiveSubscriptions.FindIndex(Subscription => Subscription.args == NewSubscription.args);

                if (index < 0)
                {
                    await Subscribe(NewSubscription, argsString, Topic, Token);
                }
                else
                {
                    Logger.Warn("Symbol Topic combo is already subscribed to");
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        private async void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbActiveSubs.SelectedItems.Count == 1)
                {
                    int index = ActiveSubscriptions.FindIndex(Subscription => Subscription.args == lbActiveSubs.SelectedItem.ToString());
                    if (index > -1)
                    {
                        await Unsubscribe(ActiveSubscriptions[index]);
                        lbActiveSubs.Items.RemoveAt(index);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        private async void btnUnsubscribeAll_Click(object sender, EventArgs e)
        {
            try
            {
                await UnsubscribeAll();
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public async Task Subscribe(Subscription NewSubscription, string args, TopicType Topic, string Token)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(NewSubscription.SubscribeToJsonMessage());
                await WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                AddsForSubscribe(args, NewSubscription, Topic, Token); // adds panels, tabs, orderbook to list etc...
                Logger?.Info($"Successfully subscribed with: {NewSubscription.SubscribeToJsonMessage()}");
                if (ActiveSubscriptions.Count < 2)
                {
                    await ReceiveMessages(WebSocket, Orderbooks.Count - 1);// ActiveSubscriptions.IndexOf(NewSubscription));
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void AddsForSubscribe(string args, Subscription NewSubscription, TopicType Topic, string Token)
        {
            lbActiveSubs.Items.Add(args);
            TabPage newTabPage = new TabPage(Topic.ToString());
            pnlOrderbook pnlOrderbook = new pnlOrderbook();
            pnlOrderbook.Dock = DockStyle.Fill;
            newTabPage.Controls.Add(pnlOrderbook);
            pnlOrderbook.SetSymbolLabel(Token);
            Panels.Add(pnlOrderbook);
            tabControlSubscriptions.TabPages.Add(newTabPage);
            tabControlSubscriptions.SelectTab(newTabPage);
            ActiveSubscriptions.Add(NewSubscription);
            Orderbooks.Add(new Orderbook());
        }
        public async Task Unsubscribe(Subscription Subscription)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(Subscription.UnsubscribeToJsonMessage());
                await WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                int index = ActiveSubscriptions.IndexOf(Subscription);
                RemovesForUnsubscribe(index); // removes panels, list entries etc...
                Logger?.Info($"Successfully unsubscribed with {Subscription.UnsubscribeToJsonMessage()}");

            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void RemovesForUnsubscribe(int index)
        {
            tabControlSubscriptions.TabPages.RemoveAt(index);
            Panels.RemoveAt(index);
            ActiveSubscriptions.RemoveAt(index);
            Orderbooks.RemoveAt(index);
        }
        public async Task UnsubscribeAll()
        {
            try
            {
                while (ActiveSubscriptions.Count > 0)
                {
                    await Unsubscribe(ActiveSubscriptions[0]);
                    lbActiveSubs.Items.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }

        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Connected)
                {
                    await ConnectWebSocket();

                    var autoEvent = new AutoResetEvent(false);

                    System.Threading.Timer HeartbeatTimer = new System.Threading.Timer(OnHeartbeatTimer, autoEvent, 5000, 5000);
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                await DisconnectSocket();
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public async Task ConnectWebSocket()
        {
            try
            {
                string socketUrl = $"wss://ws.bitmex.com/realtime";
                WebSocket = new ClientWebSocket();

                await WebSocket.ConnectAsync(new Uri(socketUrl), CancellationToken.None);
                Connected = true;
                Logger.Info($"Connection Established: {socketUrl}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public async Task DisconnectSocket()
        {
            try
            {
                if (Connected)
                {
                    await UnsubscribeAll();
                    await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing WebSocket", CancellationToken.None);
                    Connected = false;
                    Logger.Info("Connection successfully closed");
                    Connected = false;
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public async Task ReceiveMessages(ClientWebSocket webSocket, int OrderbookI)
        {
            try
            {
                const int bufferSize = 8192;
                byte[] buffer = new byte[bufferSize];
                StringBuilder messageBuilder = new();

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
                            ActionData ActionData;
                            try
                            {
                                ActionData = JsonSerializer.Deserialize<ActionData>(completeMessage, options);
                                if (ActionData.Action != null && ActionData.Data != null)
                                {
                                    try
                                    {
                                        ProcessDataReceived(ActionData);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Error(ex);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Debug", "net6.0-windows7.0", "log.txt");
                                WriteToLogFile(logFilePath, completeMessage);
                                Logger.Error(ex);
                            }
                            messageBuilder.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void ProcessDataReceived(ActionData ActionData)
        {
            int OrderbookI = -1;

            try
            {
                ActionType action = ActionData.Action;
                try
                {
                    OrderbookI = ActiveSubscriptions.FindIndex(Subscription => Subscription.args.Contains(ActionData.Data[0].Symbol));
                    if (OrderbookI != -1)
                    {
                        if (action == ActionType.partial)
                        {
                            PartialAction(ActionData.Data, OrderbookI);
                            Panels[OrderbookI].SetOrdersDataSource(Orderbooks[OrderbookI].BuyOrders, Orderbooks[OrderbookI].SellOrders);
                        }
                        else if (action == ActionType.delete)
                        {
                            DeleteAction(ActionData.Data, OrderbookI);
                        }
                        else if (action == ActionType.insert)
                        {
                            InsertAction(ActionData.Data, OrderbookI);
                        }
                        else if (action == ActionType.update)
                        {
                            UpdateAction(ActionData.Data, OrderbookI);
                        }
                        else
                        {
                            Logger.Info($"{action} is not catered for yet");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error processing action {action}, index is {OrderbookI}, exception: {ex}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public void WriteToLogFile(string filePath, string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        // Action methods:
        public void PartialAction(List<Order> Data, int OrderbookI)
        {            // loop through orders and add to orderbook object
            foreach (var order in Data)
            {
                Orderbooks[OrderbookI].AddOrder(order);
            }
            //Panels[OrderbookI].SetLargestTotals(Orderbooks[OrderbookI].BuyOrders[^1].TotalUSD, Orderbooks[OrderbookI].SellOrders[^1].TotalUSD);
            Panels[OrderbookI].AddTotalColumns(10000, 10000);
        }
        public void DeleteAction(List<Order> Data, int OrderbookI)
        {

            foreach (var order in Data)
            {
                Orderbooks[OrderbookI].DeleteOrder(order);
            }

        }
        public void InsertAction(List<Order> Data, int OrderbookI)
        {
            foreach (var order in Data)
            {
                Orderbooks[OrderbookI].InsertOrder(order);
                UpdateCellColour(order, OrderbookI);
            }
        }
        public void UpdateAction(List<Order> Data, int OrderbookI)
        {
            Panels[OrderbookI].SetLargestTotals(10000, 10000);

            try
            {
                foreach (var order in Data)
                {
                    Orderbooks[OrderbookI].UpdateOrder(order);

                    UpdateCellColour(order, OrderbookI);
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }

        // Change Cell Colour on updates and inserts
        public void UpdateCellColour(Order order, int OrderbookI)
        {
            try
            {
                int CellColour = order.GetCellColour();
                int CellIndex = Orderbooks[OrderbookI].GetOrderIndex(order);
                if (CellIndex > -1)
                {
                    ChangeCellColour(order.Side, CellIndex, CellColour, OrderbookI);
                }
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void ChangeCellColour(SideType SideType, int cellIndex, int cellColour, int OrderbookI)
        {
            try
            {
                Panels[OrderbookI].SetCellForeColor(SideType, cellIndex, cellColour);
            }
            catch (Exception ex)
            {
                Logger?.Error($"cellIndex Received: {cellIndex}. Error: {ex}");
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            cbSubscriptionTopics.DataSource = Enum.GetNames(typeof(TopicType));
            cbSelectToken.DataSource = Enum.GetNames(typeof(Symbols));
            cbSubscriptionTopics.SelectedIndex = 0;
        }
        private void OrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await DisconnectSocket(); // also unsubscribes
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        private void tabControlSubscriptions_Selected(object sender, TabControlEventArgs e)
        {
            lbActiveSubs.SelectedIndex = tabControlSubscriptions.SelectedIndex;
        }

        private void TestBut_Click(object sender, EventArgs e)
        {
           
        }
    }
    public class ActionData
    {
        public ActionType Action { get; set; }
        public string Table {  get; set; }
        public List<Order> Data { get; set; }

        public ActionData(ActionType Action, List<Order> Data, string Table)
        {
            this.Action = Action;
            this.Data = Data;
            this.Table = Table;
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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SideType
    {
        Buy,
        Sell
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ActionType
    {
        [EnumMember(Value = "partial")]
        partial,
        [EnumMember(Value = "insert")]
        insert,
        [EnumMember(Value = "update")]
        update,
        [EnumMember(Value = "delete")]
        delete
    }
    public class Order
    {
        public string Symbol { get; set; }
        public Int64 Id { get; set; }
        public SideType Side { get; set; }
        public int Size { get; set; }
        public int OldSize { get; set; }
        public double Price { get; set; }
        public DateTime Timestamp { get; set; }
        public int TotalUSD { get; set; }



        public Order(string symbol, int id, SideType side, int size, double price, DateTime timestamp)
        {
            this.Symbol = symbol;
            this.Id = id;
            this.Side = side;
            this.Size = size;
            this.Price = price;
            this.Timestamp = timestamp;
            this.OldSize = -1;
            this.TotalUSD = size;
        }
        public void UpdateTotalUSD(BindingList<Order> orders, int index) {
            this.TotalUSD = this.Size;
            if (index != 0)
            {
                for (int i = index-1; i >= 0; i--)
                {
                    this.TotalUSD += orders[i].Size;
                }
            }
        }
        public Order()
        {

        }
        public int GetCellColour()
        {
            if (this.OldSize == -1)
            {
                return 0;
            }
            else if (this.OldSize < this.Size)
            {
                return 1;
            }
            else
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
        public BindingList<Order> SellOrders = new();
        public BindingList<Order> BuyOrders = new();
        public int Length { get; set; }
        public void AddOrder(Order order)
        {
            if (order.Side == SideType.Buy)
            {
                BuyOrders.Add(order);
                BuyOrders[^1].UpdateTotalUSD(BuyOrders, BuyOrders.Count-1);
            }
            else
            {
                SellOrders.Insert(0, order);
                for (int i = 0; i < SellOrders.Count; i++)
                {
                    SellOrders[i].TotalUSD += order.Size;
                }
            }

            this.Length++;
        }
        public void InsertOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.BuyOrders : this.SellOrders;

            // convert to normal list to use binary search
            List<Order> orderList = new List<Order>(orders);
            int index;


            IComparer<Order> orderComparer = (order.Side == SideType.Buy)
            ? (IComparer<Order>)new OrderComparerBuy()
            : (IComparer<Order>)new OrderComparerSell();

            index = orderList.BinarySearch(order, (IComparer<Order>?)orderComparer);

            if (index < 0)
            {
                index = ~index;
            }
            if (order.Side == SideType.Buy)
            {
                this.BuyOrders.Insert(index, order);
                this.BuyOrders[index].UpdateTotalUSD(this.BuyOrders, index);
                for (int i =  index; i < orderList.Count; i++)
                {
                    BuyOrders[i].TotalUSD += order.Size;
                }
            }
            else
            {
                this.SellOrders.Insert(index, order);
                this.SellOrders[index].UpdateTotalUSD(this.SellOrders, index);
                for (int i = index; i < orderList.Count; i++)
                {
                    SellOrders[i].TotalUSD += order.Size;
                }
            }
            this.Length++;
        }
        public void DeleteOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.BuyOrders : this.SellOrders;
            for (int i = orders.Count -1; i >= 0; i--)
            {
                if (orders[i].Price == order.Price)
                {
                    for (int j = i + 1; j < orders.Count; j++)
                    {
                        orders[j].TotalUSD -= orders[i].Size;
                    }
                    orders.RemoveAt(i);
                }
            }
        }
        public void UpdateOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.BuyOrders : this.SellOrders;
            for (int i = 0; i < orders.Count; i++)
            {
                {
                    if (order.Price == orders[i].Price)
                    {
                        int OldSize = orders[i].Size;
                        orders[i] = order;
                        orders[i].OldSize = OldSize;
                        int SizeDif = order.Size - OldSize;
                        orders[i].UpdateTotalUSD(orders, i);
                        for (int j = i+1; j < orders.Count; j++)
                        {
                            orders[j].TotalUSD += SizeDif;
                        }

                    }
                }
            }
        }
        public int GetOrderIndex(Order order)
        {
            int i;
            if (order.Side == SideType.Buy)
            {
                i = BuyOrders.IndexOf(order);
            }
            else
            {
                i = SellOrders.IndexOf(order);
            }
            return i;


        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in BuyOrders)
            {
                sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
        public string ToStringBuy()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in BuyOrders)
            {
                if (order.Side == SideType.Buy)
                    sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
        public string ToStringSell()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Orderbook:");

            foreach (Order order in BuyOrders)
            {
                if (order.Side == SideType.Sell)
                    sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
    }
    public enum Symbols
    {
        NEARUSD,
        XBTUSD,
        SOLUSD,
        ETHUSD,
        XRPUSD,
        BNBUSD
    }
    public enum TopicType
    {
        orderBookL2_25,
        orderBookL2
    }
    public class Subscription
    {
        public string op { get; set; } = "";
        public string args { get; set; }
        public Subscription(string arg, string op) : this(arg)
        {
            this.op = op;
        }
        public Subscription(string arg)
        {
            this.args = arg;
        }
        public int IsInActiveSubscriptions(List<Subscription> activeSubscriptions)
        {
            for (int i = 0; i < activeSubscriptions.Count; i++)
            {
                if (activeSubscriptions[i].args == this.args)
                {
                    return i;
                }
            }
            return -1;
        }
        public string ToJsonMessage()
        {
            return JsonSerializer.Serialize(this);
        }
        public string UnsubscribeToJsonMessage()
        {
            this.op = "unsubscribe";
            return JsonSerializer.Serialize(this);
        }
        public string SubscribeToJsonMessage()
        {
            this.op = "subscribe";
            return JsonSerializer.Serialize(this);
        }
    }
    public class TopicTokenPair
    {
        public TopicType Topic { get; set; }
        public string Symbol { get; set; }
        public TopicTokenPair(TopicType topic, string symbol)
        {
            Topic = topic;
            Symbol = symbol;
        }
        public string ToArgsString()
        {
            return $"{this.Topic}:{this.Symbol}";
        }
    }


}
