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
        public int BuySizeColumnIndex { get; private set; }
        public int SellSizeColumnIndex { get; private set; }
        public  Orderbook Orderbook = new();
        public  DataTable BuyTable = new();
        public  DataTable SellTable = new();

        public JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public void OnHeartbeatTimer(object? state)
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
                        ActionData ActionData;
                        try
                        {
                            ActionData = JsonSerializer.Deserialize<ActionData>(completeMessage, options);
                                if (ActionData.Action != null && ActionData.Data != null)
                                {                                    try
                                    {
                                        ProcessDataReceived(ActionData);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Error(ex);
                                    }

                                }                           
                        }
                        catch (Exception ex){
                            Logger.Error(ex); 
                        }
                    messageBuilder.Clear();
                    }
                }
            }
        }
        public void UpdateOutput()
        {
            label1.Text = Orderbook.Length.ToString();
        }
        public void ProcessDataReceived(ActionData ActionData)
        {
            try
            {
                ActionType action = ActionData.Action;

                try
                {

                    if (action == ActionType.partial)
                    {
                        PartialAction(ActionData.Data);

                        // Assuming orderbook.sellOrders and orderbook.buyOrders are updated inside partialAction
                        // Use BeginInvoke to update the DataGridView on the UI thread
                        dgvSell.BeginInvoke(new Action(() => dgvSell.DataSource = Orderbook.SellOrders));
                        dgvBuy.BeginInvoke(new Action(() => dgvBuy.DataSource = Orderbook.BuyOrders));

                    }
                    else if (action == ActionType.delete)
                    {
                        DeleteAction(ActionData.Data);
                    }
                    else if (action == ActionType.insert)
                    {
                        InsertAction(ActionData.Data);
                    }
                    else if (action == ActionType.update)
                    {
                        UpdateAction(ActionData.Data);
                    }
                    else
                    {
                        Logger.Info($"{action} is not catered for yet");
                    }


                    UpdateOutput();
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
        public void PartialAction(List<Order> Data)
        {            // loop through orders and add to orderbook object
            foreach (var order in Data)
            {
                Orderbook.AddOrder(order);
            }
            dgvBuy.Columns["Price1"].DefaultCellStyle.ForeColor = Color.Green;
            dgvSell.Columns["Price"].DefaultCellStyle.ForeColor = Color.Red;

        }
        public void DeleteAction(List<Order> Data)
        {
            
            foreach (var order in Data)
            {
                Orderbook.DeleteOrder(order);
            }

        }
        public void InsertAction(List<Order> Data)
        {
            foreach (var order in Data)
            {
                Orderbook.InsertOrder(order);
                UpdateCellColour(order);
            }   
        }
        public void UpdateAction(List<Order> Data)
        {
            try
            {
                foreach (var order in Data)
                {
                    Orderbook.UpdateOrder(order);

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
                int CellIndex = Orderbook.GetOrderIndex(order);
                ChangeCellColour(order.Side, CellIndex, CellColour);
            }
            catch (Exception ex)
            {
                Logger?.Error(ex);
            }
        }
        public void ChangeCellColour(SideType SideType, int cellIndex, int cellColour)
        {
            try
            {
                if (SideType == SideType.Buy)
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
                if (SideType == SideType.Sell)
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

        private void OrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class ActionData
    {
        public ActionType Action { get; set; }
        public List<Order> Data { get; set; }

        public ActionData(ActionType Action, List<Order> Data) {
            this.Action = Action;
            this.Data = Data;   
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



        public Order(string symbol, int id, SideType side, int size, double price, DateTime timestamp)
        {
            this.Symbol = symbol;
            this.Id = id;
            this.Side = side;
            this.Size = size;
            this.Price = price;
            this.Timestamp = timestamp;
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
        public BindingList<Order> SellOrders = new BindingList<Order>();
        public BindingList<Order> BuyOrders = new BindingList<Order>();
        public int Length { get; set; }
        public void AddOrder(Order order)
        {
            if (order.Side == SideType.Buy)
            {
                BuyOrders.Add(order);

            }
            else
            {
                SellOrders.Insert(0,order);
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
            } else
            {
                this.SellOrders.Insert(index, order);
            }
            this.Length++;
        }
        public void DeleteOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.BuyOrders : this.SellOrders;
            List<int> indiciesToRemove = new List<int>();

            for (int i = 0; i < orders.Count; i++){
                if (orders[i].Id == order.Id)
                {
                    indiciesToRemove.Add(i);
                }
            }
            foreach (int index  in indiciesToRemove)
            {
                orders.RemoveAt(index);
                this.Length--;
            }
        }
        public void UpdateOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.BuyOrders : this.SellOrders;
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
}
