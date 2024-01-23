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
            OutputRichTextBox = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            checkedListBox1 = new CheckedListBox();
            SubscribeButton = new Button();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            OutputRichtextBox2 = new RichTextBox();
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
            RefreshButton.Location = new Point(24, 21);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(112, 34);
            RefreshButton.TabIndex = 0;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += button1_Click;
            // 
            // TokenSelectionComboBox
            // 
            TokenSelectionComboBox.FormattingEnabled = true;
            TokenSelectionComboBox.Items.AddRange(new object[] { "XBT" });
            TokenSelectionComboBox.Location = new Point(24, 75);
            TokenSelectionComboBox.Name = "TokenSelectionComboBox";
            TokenSelectionComboBox.Size = new Size(182, 33);
            TokenSelectionComboBox.TabIndex = 2;
            TokenSelectionComboBox.Text = "Select a token";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(358, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1656, 835);
            dataGridView1.TabIndex = 3;
            // 
            // OutputRichTextBox
            // 
            OutputRichTextBox.Location = new Point(24, 132);
            OutputRichTextBox.Name = "OutputRichTextBox";
            OutputRichTextBox.Size = new Size(256, 724);
            OutputRichTextBox.TabIndex = 5;
            OutputRichTextBox.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2044, 918);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(RefreshButton);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(OutputRichTextBox);
            tabPage1.Controls.Add(TokenSelectionComboBox);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2036, 880);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(OutputRichtextBox2);
            tabPage2.Controls.Add(checkedListBox1);
            tabPage2.Controls.Add(SubscribeButton);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2036, 880);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "XBT" });
            checkedListBox1.Location = new Point(20, 157);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(180, 144);
            checkedListBox1.TabIndex = 10;
            // 
            // SubscribeButton
            // 
            SubscribeButton.Location = new Point(31, 39);
            SubscribeButton.Name = "SubscribeButton";
            SubscribeButton.Size = new Size(143, 37);
            SubscribeButton.TabIndex = 8;
            SubscribeButton.Text = "Subscribe";
            SubscribeButton.UseVisualStyleBackColor = true;
            SubscribeButton.Click += SubscribeButton_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(271, 21);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1729, 765);
            dataGridView2.TabIndex = 7;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(636, 0);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.Size = new Size(8, 8);
            dataGridView3.TabIndex = 7;
            // 
            // OutputRichtextBox2
            // 
            OutputRichtextBox2.Location = new Point(20, 336);
            OutputRichtextBox2.Name = "OutputRichtextBox2";
            OutputRichtextBox2.Size = new Size(150, 144);
            OutputRichtextBox2.TabIndex = 11;
            OutputRichtextBox2.Text = "";
            // 
            // Orderbook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2044, 930);
            Controls.Add(dataGridView3);
            Controls.Add(tabControl1);
            Name = "Orderbook";
            Text = "Orderbook";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RefreshButton;
        private ComboBox TokenSelectionComboBox;
        private DataGridView dataGridView1;
        private RichTextBox richTextBox1;
        private RichTextBox OutputRichTextBox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Button SubscribeButton;
        private CheckedListBox checkedListBox1;
        private RichTextBox OutputRichtextBox2;
    }
}
