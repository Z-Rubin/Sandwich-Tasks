namespace Orderbook
{
    partial class Orderbook
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
            RefreshButton = new Button();
            TokenSelectionComboBox = new ComboBox();
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            OutputLabel = new Label();
            OutputRichTextBox = new RichTextBox();
            tabPage2 = new TabPage();
            ToggleButton = new Button();
            SubscriptionInputLabel = new Label();
            InputTokenRichTextBox = new RichTextBox();
            OutputLabel2 = new Label();
            OutputRichtextBox2 = new RichTextBox();
            SubscribeButton = new Button();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(17, 13);
            RefreshButton.Margin = new Padding(2, 2, 2, 2);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(78, 20);
            RefreshButton.TabIndex = 0;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += button1_Click;
            // 
            // TokenSelectionComboBox
            // 
            TokenSelectionComboBox.FormattingEnabled = true;
            TokenSelectionComboBox.Items.AddRange(new object[] { "XBT", "ETH", "SOL" });
            TokenSelectionComboBox.Location = new Point(17, 45);
            TokenSelectionComboBox.Margin = new Padding(2, 2, 2, 2);
            TokenSelectionComboBox.Name = "TokenSelectionComboBox";
            TokenSelectionComboBox.Size = new Size(129, 23);
            TokenSelectionComboBox.TabIndex = 2;
            TokenSelectionComboBox.Text = "Select a token";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(251, 13);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(932, 501);
            dataGridView1.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(2, 2, 2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1205, 551);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(OutputLabel);
            tabPage1.Controls.Add(RefreshButton);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(OutputRichTextBox);
            tabPage1.Controls.Add(TokenSelectionComboBox);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2, 2, 2, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 2, 2, 2);
            tabPage1.Size = new Size(1197, 523);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Rest API";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // OutputLabel
            // 
            OutputLabel.AutoSize = true;
            OutputLabel.Location = new Point(17, 91);
            OutputLabel.Margin = new Padding(2, 0, 2, 0);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(73, 15);
            OutputLabel.TabIndex = 6;
            OutputLabel.Text = "Raw Output:";
            // 
            // OutputRichTextBox
            // 
            OutputRichTextBox.Location = new Point(17, 107);
            OutputRichTextBox.Margin = new Padding(2, 2, 2, 2);
            OutputRichTextBox.Name = "OutputRichTextBox";
            OutputRichTextBox.Size = new Size(180, 408);
            OutputRichTextBox.TabIndex = 5;
            OutputRichTextBox.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ToggleButton);
            tabPage2.Controls.Add(SubscriptionInputLabel);
            tabPage2.Controls.Add(InputTokenRichTextBox);
            tabPage2.Controls.Add(OutputLabel2);
            tabPage2.Controls.Add(OutputRichtextBox2);
            tabPage2.Controls.Add(SubscribeButton);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2, 2, 2, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 2, 2, 2);
            tabPage2.Size = new Size(1197, 523);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Websocket API";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ToggleButton
            // 
            ToggleButton.Location = new Point(14, 38);
            ToggleButton.Margin = new Padding(2, 2, 2, 2);
            ToggleButton.Name = "ToggleButton";
            ToggleButton.Size = new Size(158, 33);
            ToggleButton.TabIndex = 15;
            ToggleButton.Text = "Toggle Refresh";
            ToggleButton.UseVisualStyleBackColor = true;
            ToggleButton.Click += ToggleButton_Click;
            // 
            // SubscriptionInputLabel
            // 
            SubscriptionInputLabel.AutoSize = true;
            SubscriptionInputLabel.Location = new Point(14, 73);
            SubscriptionInputLabel.Margin = new Padding(2, 0, 2, 0);
            SubscriptionInputLabel.Name = "SubscriptionInputLabel";
            SubscriptionInputLabel.Size = new Size(77, 15);
            SubscriptionInputLabel.TabIndex = 14;
            SubscriptionInputLabel.Text = "Input a token";
            // 
            // InputTokenRichTextBox
            // 
            InputTokenRichTextBox.Location = new Point(14, 89);
            InputTokenRichTextBox.Margin = new Padding(2, 2, 2, 2);
            InputTokenRichTextBox.Name = "InputTokenRichTextBox";
            InputTokenRichTextBox.Size = new Size(159, 20);
            InputTokenRichTextBox.TabIndex = 13;
            InputTokenRichTextBox.Text = "XBTUSD";
            // 
            // OutputLabel2
            // 
            OutputLabel2.AutoSize = true;
            OutputLabel2.Location = new Point(14, 116);
            OutputLabel2.Margin = new Padding(2, 0, 2, 0);
            OutputLabel2.Name = "OutputLabel2";
            OutputLabel2.Size = new Size(73, 15);
            OutputLabel2.TabIndex = 12;
            OutputLabel2.Text = "Raw Output:";
            // 
            // OutputRichtextBox2
            // 
            OutputRichtextBox2.Location = new Point(14, 133);
            OutputRichtextBox2.Margin = new Padding(2, 2, 2, 2);
            OutputRichtextBox2.Name = "OutputRichtextBox2";
            OutputRichtextBox2.Size = new Size(159, 369);
            OutputRichtextBox2.TabIndex = 11;
            OutputRichtextBox2.Text = "";
            // 
            // SubscribeButton
            // 
            SubscribeButton.Location = new Point(14, 13);
            SubscribeButton.Margin = new Padding(2, 2, 2, 2);
            SubscribeButton.Name = "SubscribeButton";
            SubscribeButton.Size = new Size(158, 22);
            SubscribeButton.TabIndex = 8;
            SubscribeButton.Text = "Subscribe";
            SubscribeButton.UseVisualStyleBackColor = true;
            SubscribeButton.Click += SubscribeButton_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(190, 13);
            dataGridView2.Margin = new Padding(2, 2, 2, 2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(981, 488);
            dataGridView2.TabIndex = 7;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(445, 0);
            dataGridView3.Margin = new Padding(2, 2, 2, 2);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.Size = new Size(6, 5);
            dataGridView3.TabIndex = 7;
            // 
            // Orderbook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 558);
            Controls.Add(dataGridView3);
            Controls.Add(tabControl1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Orderbook";
            Text = "Orderbook";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RefreshButton;
        private ComboBox TokenSelectionComboBox;
        private DataGridView dataGridView1;
        private RichTextBox InputTokenRichTextBox;
        private RichTextBox OutputRichTextBox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView3;
        private Button SubscribeButton;
        private RichTextBox OutputRichtextBox2;
        public DataGridView dataGridView2;
        private Label OutputLabel;
        private Label OutputLabel2;
        private Label SubscriptionInputLabel;
        private Button ToggleButton;
    }
}
