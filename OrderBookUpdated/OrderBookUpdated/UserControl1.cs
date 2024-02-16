using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
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
                        this.dgvBuy[1, cellIndex].Style.ForeColor = Color.Green;

                    }
                    else if (cellColour == 2)
                    {
                        this.dgvBuy[1, cellIndex].Style.ForeColor = Color.Red;

                    }
                    else if (cellColour == 0)
                    {
                        this.dgvBuy[1, cellIndex].Style.ForeColor = Color.Black;

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
        public void AddTotalColumns(float LargestTotalBuy, float LargestTotalSell)
        {
            DataGridViewProgressColumn dgvProgressCol = new DataGridViewProgressColumn();
            //dgvProgressCol.SetLargestTotal(100);
            dgvBuy.Columns.Insert(0, dgvProgressCol);
            dgvBuy.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBuy.Columns[0].DataPropertyName = "TotalUSD";
            dgvBuy.Columns[0].HeaderText = "Total (USD)";
            dgvProgressCol = new DataGridViewProgressColumn();
            dgvSell.Columns.Add(dgvProgressCol);
            dgvSell.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSell.Columns[2].DataPropertyName = "TotalUSD";
            dgvSell.Columns[2].HeaderText = "Total (USD)";

            if (dgvBuy.Rows[0].Cells[0].OwningColumn is DataGridViewProgressColumn OwningColumn)
            {
                OwningColumn.SetLargestTotal(LargestTotalBuy);
                OwningColumn.SetSide("Buy");
            }
            if (dgvSell.Rows[0].Cells[2].OwningColumn is DataGridViewProgressColumn OwningColumn2)
            {
                OwningColumn2.SetLargestTotal(LargestTotalSell);
                OwningColumn2.SetSide("Sell");
            }
        }
        public void SetLargestTotalsAll(float LargestTotalBuy, float LargestTotalSell)        {
  
                if (dgvBuy.Columns[0] is DataGridViewProgressColumn Column)
                {
                    Column.SetLargestTotal(LargestTotalBuy);
                }
                if (dgvSell.Columns[2] is DataGridViewProgressColumn Column1)
                {
                    Column1.SetLargestTotal(LargestTotalSell);
                }

            dgvBuy.InvalidateColumn(0);
            dgvSell.InvalidateColumn(2);
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
