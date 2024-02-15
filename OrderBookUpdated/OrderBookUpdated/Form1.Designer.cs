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
            btnSubscribe = new Button();
            label1 = new Label();
            orderBindingSource = new BindingSource(components);
            orderbookBindingSource = new BindingSource(components);
            dgvSell = new DataGridView();
            Price = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Side1 = new DataGridViewTextBoxColumn();
            dgvBuy = new DataGridView();
            Side = new DataGridViewTextBoxColumn();
            Size1 = new DataGridViewTextBoxColumn();
            Price1 = new DataGridViewTextBoxColumn();
            btnConnect = new Button();
            btnDisconnect = new Button();
            cbSelectToken = new ComboBox();
            btnUnsubscribeSelected = new Button();
            lbActiveSubs = new ListBox();
            cbSubscriptionTopics = new ComboBox();
            btnUnsubscribeAll = new Button();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).BeginInit();
            SuspendLayout();
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(12, 96);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(152, 36);
            btnSubscribe.TabIndex = 0;
            btnSubscribe.Text = "Subscribe";
            btnSubscribe.UseVisualStyleBackColor = true;
            btnSubscribe.Click += btnSubscribe_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 466);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Order);
            orderBindingSource.CurrentChanged += OrderBindingSource_CurrentChanged;
            // 
            // orderbookBindingSource
            // 
            orderbookBindingSource.DataSource = typeof(Orderbook);
            // 
            // dgvSell
            // 
            dgvSell.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSell.Columns.AddRange(new DataGridViewColumn[] { Price, Size, Side1 });
            dgvSell.Location = new Point(563, 12);
            dgvSell.Name = "dgvSell";
            dgvSell.ReadOnly = true;
            dgvSell.RowTemplate.Height = 25;
            dgvSell.Size = new Size(345, 725);
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
            // dgvBuy
            // 
            dgvBuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuy.Columns.AddRange(new DataGridViewColumn[] { Side, Size1, Price1 });
            dgvBuy.Location = new Point(214, 12);
            dgvBuy.Name = "dgvBuy";
            dgvBuy.ReadOnly = true;
            dgvBuy.RowTemplate.Height = 25;
            dgvBuy.Size = new Size(343, 725);
            dgvBuy.TabIndex = 10;
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
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(152, 36);
            btnConnect.TabIndex = 12;
            btnConnect.Text = "Connect to Socket";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(12, 54);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(152, 36);
            btnDisconnect.TabIndex = 13;
            btnDisconnect.Text = "Disconnect from Socket";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // cbSelectToken
            // 
            cbSelectToken.FormattingEnabled = true;
            cbSelectToken.Location = new Point(12, 246);
            cbSelectToken.Name = "cbSelectToken";
            cbSelectToken.Size = new Size(152, 23);
            cbSelectToken.TabIndex = 14;
            // 
            // btnUnsubscribeSelected
            // 
            btnUnsubscribeSelected.Location = new Point(12, 138);
            btnUnsubscribeSelected.Name = "btnUnsubscribeSelected";
            btnUnsubscribeSelected.Size = new Size(152, 36);
            btnUnsubscribeSelected.TabIndex = 16;
            btnUnsubscribeSelected.Text = "Unsubscribe Selected";
            btnUnsubscribeSelected.UseVisualStyleBackColor = true;
            btnUnsubscribeSelected.Click += btnUnsubscribe_Click;
            // 
            // lbActiveSubs
            // 
            lbActiveSubs.FormattingEnabled = true;
            lbActiveSubs.ItemHeight = 15;
            lbActiveSubs.Location = new Point(12, 369);
            lbActiveSubs.Name = "lbActiveSubs";
            lbActiveSubs.Size = new Size(120, 94);
            lbActiveSubs.TabIndex = 17;
            // 
            // cbSubscriptionTopics
            // 
            cbSubscriptionTopics.FormattingEnabled = true;
            cbSubscriptionTopics.Location = new Point(12, 275);
            cbSubscriptionTopics.Name = "cbSubscriptionTopics";
            cbSubscriptionTopics.Size = new Size(152, 23);
            cbSubscriptionTopics.TabIndex = 18;
            // 
            // btnUnsubscribeAll
            // 
            btnUnsubscribeAll.Location = new Point(12, 180);
            btnUnsubscribeAll.Name = "btnUnsubscribeAll";
            btnUnsubscribeAll.Size = new Size(152, 36);
            btnUnsubscribeAll.TabIndex = 19;
            btnUnsubscribeAll.Text = "Unsubscribe All";
            btnUnsubscribeAll.UseVisualStyleBackColor = true;
            btnUnsubscribeAll.Click += btnUnsubscribeAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 749);
            Controls.Add(btnUnsubscribeAll);
            Controls.Add(cbSubscriptionTopics);
            Controls.Add(lbActiveSubs);
            Controls.Add(btnUnsubscribeSelected);
            Controls.Add(cbSelectToken);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(dgvBuy);
            Controls.Add(dgvSell);
            Controls.Add(label1);
            Controls.Add(btnSubscribe);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSell).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBuy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubscribe;
        private Label label1;
        private DataGridView dataGridViewBuy;
        private BindingSource orderBindingSource;
        private BindingSource orderbookBindingSource;
        private DataGridView dataGridViewSell;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dgvSell;
        private DataGridView dgvBuy;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Side1;
        private DataGridViewTextBoxColumn Side;
        private DataGridViewTextBoxColumn Size1;
        private DataGridViewTextBoxColumn Price1;
        private Button btnConnect;
        private Button btnDisconnect;
        private ComboBox cbSelectToken;
        private Button btnUnsubscribeSelected;
        private ListBox lbActiveSubs;
        private ComboBox cbSubscriptionTopics;
        private Button btnUnsubscribeAll;
    }
}
