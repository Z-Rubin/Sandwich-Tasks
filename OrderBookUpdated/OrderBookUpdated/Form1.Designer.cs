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
            orderBindingSource = new BindingSource(components);
            orderbookBindingSource = new BindingSource(components);
            dgvSell = new DataGridView();
            Price = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Side1 = new DataGridViewTextBoxColumn();
            Symbol = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            checkBox1 = new CheckBox();
            dgvBuy = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Side = new DataGridViewTextBoxColumn();
            Size1 = new DataGridViewTextBoxColumn();
            Price1 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).BeginInit();
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
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Order);
            orderBindingSource.CurrentChanged += orderBindingSource_CurrentChanged;
            // 
            // orderbookBindingSource
            // 
            orderbookBindingSource.DataSource = typeof(Orderbook);
            // 
            // dgvSell
            // 
            dgvSell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSell.Columns.AddRange(new DataGridViewColumn[] { Price, Size, Side1, Symbol, ID });
            dgvSell.Location = new Point(761, 12);
            dgvSell.Name = "dgvSell";
            dgvSell.ReadOnly = true;
            dgvSell.RowTemplate.Height = 25;
            dgvSell.Size = new Size(543, 725);
            dgvSell.TabIndex = 8;
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
            // Symbol
            // 
            Symbol.DataPropertyName = "Symbol";
            Symbol.HeaderText = "Symbol";
            Symbol.Name = "Symbol";
            Symbol.ReadOnly = true;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 237);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dgvBuy
            // 
            dgvBuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuy.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Side, Size1, Price1 });
            dgvBuy.Location = new Point(214, 12);
            dgvBuy.Name = "dgvBuy";
            dgvBuy.ReadOnly = true;
            dgvBuy.RowTemplate.Height = 25;
            dgvBuy.Size = new Size(547, 725);
            dgvBuy.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Symbol";
            dataGridViewTextBoxColumn2.HeaderText = "Symbol";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // button1
            // 
            button1.Location = new Point(20, 299);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 749);
            Controls.Add(button1);
            Controls.Add(dgvBuy);
            Controls.Add(checkBox1);
            Controls.Add(dgvSell);
            Controls.Add(label1);
            Controls.Add(InputTokenRichTextBox);
            Controls.Add(SubscribeButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SubscribeButton;
        private RichTextBox InputTokenRichTextBox;
        private Label label1;
        private DataGridView dataGridViewBuy;
        private BindingSource orderBindingSource;
        private BindingSource orderbookBindingSource;
        private DataGridView dataGridViewSell;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dgvSell;
        private CheckBox checkBox1;
        private DataGridView dgvBuy;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Side1;
        private DataGridViewTextBoxColumn Symbol;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Side;
        private DataGridViewTextBoxColumn Size1;
        private DataGridViewTextBoxColumn Price1;
        private Button button1;
    }
}
