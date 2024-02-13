namespace OrderBookUpdated
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SubscribeButton = new Button();
            InputTokenRichTextBox = new RichTextBox();
            label1 = new Label();
            dataGridViewBuy = new DataGridView();
            symbolDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sideDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            timestampDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderBindingSource = new BindingSource(components);
            orderbookBindingSource = new BindingSource(components);
            dataGridViewSell = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSell).BeginInit();
            SuspendLayout();
            // 
            // SubscribeButton
            // 
            SubscribeButton.Location = new Point(12, 12);
            SubscribeButton.Name = "SubscribeButton";
            SubscribeButton.Size = new Size(152, 36);
            SubscribeButton.TabIndex = 0;
            SubscribeButton.Text = "Subscribe";
            SubscribeButton.UseVisualStyleBackColor = true;
            SubscribeButton.Click += SubscribeButton_Click;
            // 
            // InputTokenRichTextBox
            // 
            InputTokenRichTextBox.Location = new Point(12, 54);
            InputTokenRichTextBox.Name = "InputTokenRichTextBox";
            InputTokenRichTextBox.Size = new Size(152, 33);
            InputTokenRichTextBox.TabIndex = 1;
            InputTokenRichTextBox.Text = "XBTUSD";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 205);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // dataGridViewBuy
            // 
            dataGridViewBuy.AutoGenerateColumns = false;
            dataGridViewBuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBuy.Columns.AddRange(new DataGridViewColumn[] { symbolDataGridViewTextBoxColumn, idDataGridViewTextBoxColumn, sideDataGridViewTextBoxColumn, sizeDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, timestampDataGridViewTextBoxColumn });
            dataGridViewBuy.DataSource = orderBindingSource;
            dataGridViewBuy.Location = new Point(214, 12);
            dataGridViewBuy.Name = "dataGridViewBuy";
            dataGridViewBuy.ReadOnly = true;
            dataGridViewBuy.RowTemplate.Height = 25;
            dataGridViewBuy.Size = new Size(643, 689);
            dataGridViewBuy.TabIndex = 7;
            // 
            // symbolDataGridViewTextBoxColumn
            // 
            symbolDataGridViewTextBoxColumn.DataPropertyName = "symbol";
            symbolDataGridViewTextBoxColumn.HeaderText = "symbol";
            symbolDataGridViewTextBoxColumn.Name = "symbolDataGridViewTextBoxColumn";
            symbolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sideDataGridViewTextBoxColumn
            // 
            sideDataGridViewTextBoxColumn.DataPropertyName = "side";
            sideDataGridViewTextBoxColumn.HeaderText = "side";
            sideDataGridViewTextBoxColumn.Name = "sideDataGridViewTextBoxColumn";
            sideDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            sizeDataGridViewTextBoxColumn.DataPropertyName = "size";
            sizeDataGridViewTextBoxColumn.HeaderText = "size";
            sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            sizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            priceDataGridViewTextBoxColumn.HeaderText = "price";
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            timestampDataGridViewTextBoxColumn.DataPropertyName = "timestamp";
            timestampDataGridViewTextBoxColumn.HeaderText = "timestamp";
            timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            timestampDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Order);
            // 
            // orderbookBindingSource
            // 
            orderbookBindingSource.DataSource = typeof(Orderbook);
            // 
            // dataGridViewSell
            // 
            dataGridViewSell.AutoGenerateColumns = false;
            dataGridViewSell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSell.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridViewSell.DataSource = orderBindingSource;
            dataGridViewSell.Location = new Point(863, 12);
            dataGridViewSell.Name = "dataGridViewSell";
            dataGridViewSell.ReadOnly = true;
            dataGridViewSell.RowTemplate.Height = 25;
            dataGridViewSell.Size = new Size(643, 689);
            dataGridViewSell.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "symbol";
            dataGridViewTextBoxColumn1.HeaderText = "symbol";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "id";
            dataGridViewTextBoxColumn2.HeaderText = "id";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "side";
            dataGridViewTextBoxColumn3.HeaderText = "side";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "size";
            dataGridViewTextBoxColumn4.HeaderText = "size";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "price";
            dataGridViewTextBoxColumn5.HeaderText = "price";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "timestamp";
            dataGridViewTextBoxColumn6.HeaderText = "timestamp";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 749);
            Controls.Add(dataGridViewSell);
            Controls.Add(dataGridViewBuy);
            Controls.Add(label1);
            Controls.Add(InputTokenRichTextBox);
            Controls.Add(SubscribeButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuy).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSell).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SubscribeButton;
        private RichTextBox InputTokenRichTextBox;
        private Label label1;
        private DataGridView dataGridViewBuy;
        private DataGridViewTextBoxColumn symbolDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sideDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private BindingSource orderBindingSource;
        private BindingSource orderbookBindingSource;
        private DataGridView dataGridViewSell;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
