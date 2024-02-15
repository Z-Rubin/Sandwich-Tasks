namespace OrderBookUpdated
{
    partial class OrderbookForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvBuy = new DataGridView();
            Side = new DataGridViewTextBoxColumn();
            Size1 = new DataGridViewTextBoxColumn();
            Price1 = new DataGridViewTextBoxColumn();
            dgvSell = new DataGridView();
            Price = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Side1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).BeginInit();
            SuspendLayout();
            // 
            // dgvBuy
            // 
            dgvBuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuy.Columns.AddRange(new DataGridViewColumn[] { Side, Size1, Price1 });
            dgvBuy.Location = new Point(210, 12);
            dgvBuy.Name = "dgvBuy";
            dgvBuy.ReadOnly = true;
            dgvBuy.RowTemplate.Height = 25;
            dgvBuy.Size = new Size(343, 725);
            dgvBuy.TabIndex = 11;
            // 
            // Side
            // 
            Side.DataPropertyName = "Side";
            Side.HeaderText = "Side";
            Side.Name = "Side";
            Side.ReadOnly = true;
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
            // dgvSell
            // 
            dgvSell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSell.Columns.AddRange(new DataGridViewColumn[] { Price, Size, Side1 });
            dgvSell.Location = new Point(559, 12);
            dgvSell.Name = "dgvSell";
            dgvSell.ReadOnly = true;
            dgvSell.RowTemplate.Height = 25;
            dgvSell.Size = new Size(345, 725);
            dgvSell.TabIndex = 12;
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
            // Side1
            // 
            Side1.DataPropertyName = "Side";
            Side1.HeaderText = "Side";
            Side1.Name = "Side1";
            Side1.ReadOnly = true;
            // 
            // OrderbookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 799);
            Controls.Add(dgvSell);
            Controls.Add(dgvBuy);
            Name = "OrderbookForm";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBuy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBuy;
        private DataGridViewTextBoxColumn Side;
        private DataGridViewTextBoxColumn Size1;
        private DataGridViewTextBoxColumn Price1;
        private DataGridView dgvSell;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Side1;
    }
}