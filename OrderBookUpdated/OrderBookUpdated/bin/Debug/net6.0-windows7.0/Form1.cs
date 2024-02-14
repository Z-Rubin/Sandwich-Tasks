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

        private  readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int BuySizeColumnIndex { get; private set; }

        public int SellSizeColumnIndex { get; private set; }

        public static Orderbook Orderbook = new Orderbook();
        public static DataTable BuyTable = new DataTable();
        public static DataTable SellTable = new DataTable();

        public JsonSerializerOptions options = new JsonSerializerOptions
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

                _logger?.Error(ex);
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
                _logger?.Error(ex);
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
                    _logger.Error(ex);
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
                            {
                                MessageBox.Show(ActionData.Data.ToString());
                                try
                                {
                                    processDataReceived(ActionData);
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error(ex);
                                }

                            }

                        }
                        catch (Exception ex){
                            _logger.Error(ex); 
                        }
                    messageBuilder.Clear();
                    }
                }
            }
        }

        public void updateOutput()
        {
            label1.Text = Orderbook.length.ToString();
        }

        public void processDataReceived(ActionData ActionData)
        {
            try
            {
                ActionType action = ActionData.Action;

                try
                {

                    if (action == ActionType.partial)
                    {
                        partialAction(ActionData.Data);

                        // Assuming orderbook.sellOrders and orderbook.buyOrders are updated inside partialAction
                        // Use BeginInvoke to update the DataGridView on the UI thread
                        dgvSell.BeginInvoke(new Action(() => dgvSell.DataSource = Orderbook.sellOrders));
                        dgvBuy.BeginInvoke(new Action(() => dgvBuy.DataSource = Orderbook.buyOrders));

                    }
                    else if (action == ActionType.delete)
                    {
                        deleteAction(ActionData.Data);
                    }
                    else if (action == ActionType.insert)
                    {
                        insertAction(ActionData.Data);
                    }
                    else if (action == ActionType.update)
                    {
                        updateAction(ActionData.Data);
                    }
                    else
                    {
                        _logger.Info($"{action} is not catered for yet");
                    }


                    updateOutput();
                }

                catch (Exception ex)
                {
                    _logger.Error($"Error processing action {action}, exception: {ex}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }





        // Action methods:
        public void partialAction(List<Order> Data)
        {            // loop through orders and add to orderbook object
            foreach (var order in Data)
            {
                Orderbook.AddOrder(order, Orderbook.GetOrders(order.Side));
            }
            dgvBuy.Columns["Price1"].DefaultCellStyle.ForeColor = Color.Green;
            dgvSell.Columns["Price"].DefaultCellStyle.ForeColor = Color.Red;

        }
        public void deleteAction(List<Order> Data)
        {
            
            foreach (var order in Data)
            {
                Orderbook.DeleteOrder(order);
            }

        }
        public void insertAction(List<Order> Data)
        {
            foreach (var order in Data)
            {
                Orderbook.InsertOrder(order);
                UpdateCellColour(order);
            }   
        }
        public void updateAction(List<Order> Data)
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
                _logger?.Error(ex);
            }
        }

        // Change Cell Colour on updates and inserts
        public void UpdateCellColour(Order order)
        {
            try
            {
                int CellColour = order.GetCellColour();
                int CellIndex = Orderbook.GetOrderIndex(order, Orderbook.GetOrders(order.Side));
                ChangeCellColour(order.Side, CellIndex, CellColour);
            }
            catch (Exception ex)
            {
                _logger?.Error(ex);
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
                _logger?.Error($"cellIndex Received: {cellIndex}. Error: {ex}");
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

    public class ActionData
    {
        public ActionType Action { get; set; }
        public List<Order> Data { get; set; }

        public ActionData(ActionType action, List<Order> data) {
            this.Action = action;
            this.Data = data;   
        }
        public ActionData() { }

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


    public enum SideType
    {
        Buy,
        Sell
    }
    public enum ActionType
    {
        partial,
        insert,
        update,
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
        public BindingList<Order> sellOrders = new BindingList<Order>();
        public BindingList<Order> buyOrders = new BindingList<Order>();
        public int length { get; set; }
        public Orderbook()
        {

        }

        public BindingList<Order> GetOrders(SideType SideType)
        {
            if (SideType == SideType.Buy)
            {
                return buyOrders;
            } else
            {
                return sellOrders;
            }
        }
        public void AddOrder(Order order, BindingList<Order> orders)
        {
            if (order.Side == SideType.Buy)
            {
                orders.Add(order);

            }
            else
            {
                orders.Insert(0,order);
            }

            this.length++;
        }
        public void InsertOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.buyOrders : this.sellOrders;

            // convert to normal list to use binary search
            List<Order> orderList = new List<Order>(orders);
            int index;

            IComparer orderComparer = (order.Side == SideType.Buy) ? (IComparer)new OrderComparerBuy() : (IComparer)new OrderComparerSell();
            
            index = orderList.BinarySearch(order, (IComparer<Order>?)orderComparer);

            if (index < 0) 
            { 
                index = ~index; 
            }
      
            orders.Insert(index, order);
            this.length++;
        }
        public void DeleteOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.buyOrders : this.sellOrders;
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
                this.length--;
            }
        }
        public void UpdateOrder(Order order)
        {
            BindingList<Order> orders = (order.Side == SideType.Buy) ? this.buyOrders : this.sellOrders;
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
                if (order.Side == SideType.Buy)
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
                if (order.Side == SideType.Sell)
                    sb.AppendLine(order.ToString());
            }

            return sb.ToString();
        }
    }
}
