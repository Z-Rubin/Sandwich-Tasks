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
    public partial class pnlOrderbook : UserControl
    {
        public pnlOrderbook()
        {
            InitializeComponent();
        }

        public int BuySizeColumnIndex { get; private set; }
        public int SellSizeColumnIndex { get; private set; }

        public void SetCellForeColor(SideType SideType, int cellIndex, int cellColour)
        {

            if (SideType == SideType.Buy)
            {
                if (this.dgvBuy.RowCount > cellIndex)
                {
                    if (cellColour == 1)
                    {
                        this.dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Green;

                    }
                    else if (cellColour == 2)
                    {
                        this.dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Red;

                    }
                    else if (cellColour == 0)
                    {
                        this.dgvBuy[BuySizeColumnIndex, cellIndex].Style.ForeColor = Color.Black;

                    }
                }
            }
            if (SideType == SideType.Sell)
            {
                if (this.dgvSell.RowCount > cellIndex)
                {
                    if (cellColour == 1)
                    {
                        this.dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Green;

                    }
                    else if (cellColour == 2)
                    {
                        this.dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Red;

                    }
                    else if (cellColour == 0)
                    {
                        this.dgvSell[SellSizeColumnIndex, cellIndex].Style.ForeColor = Color.Black;

                    }
                }
            }
        }
        public void SetOrdersDataSource(object buyDataSource, object sellDataSource)
        {
            this.dgvSell.DataSource = sellDataSource;
            this.dgvBuy.DataSource = buyDataSource;
            dgvBuy.CurrentCell = null;
            dgvSell.CurrentCell = null;
        }
        public void SetLargestTotals(float LargestTotalBuy, float LargestTotalSell)
        {

            if (dgvBuy.Columns[0] is DataGridViewProgressColumn progressColumn)
            {
                // Set the new LargestTotal value
                progressColumn.SetLargestTotal(LargestTotalBuy);
                dgvBuy.InvalidateColumn(0);
                MessageBox.Show("");
            }
            if (dgvSell.Columns[2] is DataGridViewProgressColumn TotalColumnSell)
            {
                TotalColumnSell.SetLargestTotal(LargestTotalSell);
            }

        }
        public void SetSymbolLabel(string symbolLabel)
        {
            lblSymbol.Text = symbolLabel;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dgvBuy.Columns["Price1"].DefaultCellStyle.ForeColor = Color.Green;
            dgvSell.Columns["Price"].DefaultCellStyle.ForeColor = Color.Red;

            BuySizeColumnIndex = dgvBuy.Columns["Size1"].Index;
            SellSizeColumnIndex = dgvSell.Columns["Size"].Index;
            dgvBuy.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvSell.DefaultCellStyle.Font = new Font("Tahoma", 10);

            dgvBuy.AutoGenerateColumns = false;
            dgvSell.AutoGenerateColumns = false;

            //DataGridViewProgressColumn column = new DataGridViewProgressColumn();
            //dgvBuy.Columns.Insert(0,column);
            //dgvBuy.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //column.HeaderText = "Total (USD)";

        }
        private void pnlOrderbook_Load(object sender, EventArgs e)
        {

        }

    }
}
