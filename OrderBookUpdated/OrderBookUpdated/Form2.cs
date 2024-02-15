using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderBookUpdated
{
    public partial class OrderbookForm : Form
    {
        public int BuySizeColumnIndex { get; private set; }
        public int SellSizeColumnIndex { get; private set; }
        public OrderbookForm()
        {
            InitializeComponent();
        }
        public void SetOrdersDataSource(object buyDataSource, object sellDataSource)
        {
            dgvSell.DataSource = sellDataSource;
            dgvBuy.DataSource = buyDataSource;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BuySizeColumnIndex = dgvBuy.Columns["Size1"].Index;
            SellSizeColumnIndex = dgvSell.Columns["Size"].Index;
            dgvBuy.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvSell.DefaultCellStyle.Font = new Font("Tahoma", 12);

            dgvBuy.AutoGenerateColumns = false;
            dgvSell.AutoGenerateColumns = false;
        }
    }
}
