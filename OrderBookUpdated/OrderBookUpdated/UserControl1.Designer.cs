namespace OrderBookUpdated
{
    partial class pnlOrderbook
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblSymbol = new Label();
            dgvSell = new DataGridView();
            dgvBuy = new DataGridView();
            Size1 = new DataGridViewTextBoxColumn();
            Price1 = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblSymbol);
            panel1.Controls.Add(dgvSell);
            panel1.Controls.Add(dgvBuy);
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(704, 783);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblSymbol
            // 
            lblSymbol.AutoSize = true;
            lblSymbol.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSymbol.Location = new Point(299, 0);
            lblSymbol.Name = "lblSymbol";
            lblSymbol.Size = new Size(100, 40);
            lblSymbol.TabIndex = 15;
            lblSymbol.Text = "label1";
            // 
            // dgvSell
            // 
            dgvSell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSell.Columns.AddRange(new DataGridViewColumn[] { Price, Size });
            dgvSell.Location = new Point(352, 43);
            dgvSell.Name = "dgvSell";
            dgvSell.ReadOnly = true;
            dgvSell.RowTemplate.Height = 25;
            dgvSell.Size = new Size(345, 688);
            dgvSell.TabIndex = 14;
            // 
            // dgvBuy
            // 
            dgvBuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuy.Columns.AddRange(new DataGridViewColumn[] { Size1, Price1 });
            dgvBuy.Location = new Point(3, 43);
            dgvBuy.Name = "dgvBuy";
            dgvBuy.ReadOnly = true;
            dgvBuy.RowTemplate.Height = 25;
            dgvBuy.Size = new Size(343, 688);
            dgvBuy.TabIndex = 13;
            // 
            // Size1
            // 
            Size1.DataPropertyName = "Size";
            Size1.HeaderText = "Size";
            Size1.Name = "Size1";
            Size1.ReadOnly = true;
            // 
            // Price1
            // 
            Price1.DataPropertyName = "Price";
            Price1.HeaderText = "Price";
            Price1.Name = "Price1";
            Price1.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Price";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Size";
            Size.Name = "Size";
            Size.ReadOnly = true;
            // 
            // pnlOrderbook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "pnlOrderbook";
            Load += pnlOrderbook_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSell).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvSell;
        private DataGridView dgvBuy;
        private Label lblSymbol;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Size1;
        private DataGridViewTextBoxColumn Price1;
    }
}
