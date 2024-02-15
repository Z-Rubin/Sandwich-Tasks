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
            btnConnect = new Button();
            btnDisconnect = new Button();
            cbSelectToken = new ComboBox();
            btnUnsubscribeSelected = new Button();
            lbActiveSubs = new ListBox();
            cbSubscriptionTopics = new ComboBox();
            btnUnsubscribeAll = new Button();
            tabControlSubscriptions = new TabControl();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).BeginInit();
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
            // tabControlSubscriptions
            // 
            tabControlSubscriptions.Location = new Point(170, 12);
            tabControlSubscriptions.Name = "tabControlSubscriptions";
            tabControlSubscriptions.SelectedIndex = 0;
            tabControlSubscriptions.Size = new Size(1187, 725);
            tabControlSubscriptions.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 749);
            Controls.Add(tabControlSubscriptions);
            Controls.Add(btnUnsubscribeAll);
            Controls.Add(cbSubscriptionTopics);
            Controls.Add(lbActiveSubs);
            Controls.Add(btnUnsubscribeSelected);
            Controls.Add(cbSelectToken);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Controls.Add(btnSubscribe);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderbookBindingSource).EndInit();
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button btnConnect;
        private Button btnDisconnect;
        private ComboBox cbSelectToken;
        private Button btnUnsubscribeSelected;
        private ListBox lbActiveSubs;
        private ComboBox cbSubscriptionTopics;
        private Button btnUnsubscribeAll;
        private TabControl tabControlSubscriptions;
    }
}
