namespace Callbacks
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
            rtbNormal = new RichTextBox();
            btnNormalSubscribe = new Button();
            btnNormalUnsubscribe = new Button();
            btnEvenUnsunscribe = new Button();
            btnEvenSubscribe = new Button();
            rtbEven = new RichTextBox();
            btnOddUnsubscribe = new Button();
            btnOddSubscribe = new Button();
            rtbOdd = new RichTextBox();
            rtbWorkerName = new RichTextBox();
            btnSubscribeEvenThreadName = new Button();
            btnUnsubscribeEvenThreadName = new Button();
            SuspendLayout();
            // 
            // rtbNormal
            // 
            rtbNormal.Location = new Point(24, 41);
            rtbNormal.Name = "rtbNormal";
            rtbNormal.Size = new Size(241, 517);
            rtbNormal.TabIndex = 2;
            rtbNormal.Text = "";
            // 
            // btnNormalSubscribe
            // 
            btnNormalSubscribe.Location = new Point(24, 12);
            btnNormalSubscribe.Name = "btnNormalSubscribe";
            btnNormalSubscribe.Size = new Size(116, 23);
            btnNormalSubscribe.TabIndex = 4;
            btnNormalSubscribe.Text = "Subscribe";
            btnNormalSubscribe.UseVisualStyleBackColor = true;
            btnNormalSubscribe.Click += btnNormalSubscribe_Click;
            // 
            // btnNormalUnsubscribe
            // 
            btnNormalUnsubscribe.Location = new Point(149, 12);
            btnNormalUnsubscribe.Name = "btnNormalUnsubscribe";
            btnNormalUnsubscribe.Size = new Size(116, 23);
            btnNormalUnsubscribe.TabIndex = 12;
            btnNormalUnsubscribe.Text = "Unsubscribe";
            btnNormalUnsubscribe.UseVisualStyleBackColor = true;
            btnNormalUnsubscribe.Click += btnNormalUnsubscribe_Click;
            // 
            // btnEvenUnsunscribe
            // 
            btnEvenUnsunscribe.Location = new Point(437, 12);
            btnEvenUnsunscribe.Name = "btnEvenUnsunscribe";
            btnEvenUnsunscribe.Size = new Size(116, 23);
            btnEvenUnsunscribe.TabIndex = 15;
            btnEvenUnsunscribe.Text = "Unsubscribe Even";
            btnEvenUnsunscribe.UseVisualStyleBackColor = true;
            btnEvenUnsunscribe.Click += btnEvenUnsunscribe_Click;
            // 
            // btnEvenSubscribe
            // 
            btnEvenSubscribe.Location = new Point(312, 12);
            btnEvenSubscribe.Name = "btnEvenSubscribe";
            btnEvenSubscribe.Size = new Size(116, 23);
            btnEvenSubscribe.TabIndex = 14;
            btnEvenSubscribe.Text = "Subscribe Even";
            btnEvenSubscribe.UseVisualStyleBackColor = true;
            btnEvenSubscribe.Click += btnEvenSubscribe_Click;
            // 
            // rtbEven
            // 
            rtbEven.Location = new Point(312, 41);
            rtbEven.Name = "rtbEven";
            rtbEven.Size = new Size(241, 517);
            rtbEven.TabIndex = 13;
            rtbEven.Text = "";
            // 
            // btnOddUnsubscribe
            // 
            btnOddUnsubscribe.Location = new Point(723, 12);
            btnOddUnsubscribe.Name = "btnOddUnsubscribe";
            btnOddUnsubscribe.Size = new Size(116, 23);
            btnOddUnsubscribe.TabIndex = 18;
            btnOddUnsubscribe.Text = "Unsubscribe Odd";
            btnOddUnsubscribe.UseVisualStyleBackColor = true;
            btnOddUnsubscribe.Click += btnOddUnsubscribe_Click;
            // 
            // btnOddSubscribe
            // 
            btnOddSubscribe.Location = new Point(598, 12);
            btnOddSubscribe.Name = "btnOddSubscribe";
            btnOddSubscribe.Size = new Size(116, 23);
            btnOddSubscribe.TabIndex = 17;
            btnOddSubscribe.Text = "Subscribe Odd";
            btnOddSubscribe.UseVisualStyleBackColor = true;
            btnOddSubscribe.Click += btnOddSubscribe_Click;
            // 
            // rtbOdd
            // 
            rtbOdd.Location = new Point(598, 41);
            rtbOdd.Name = "rtbOdd";
            rtbOdd.Size = new Size(241, 517);
            rtbOdd.TabIndex = 16;
            rtbOdd.Text = "";
            // 
            // rtbWorkerName
            // 
            rtbWorkerName.Location = new Point(876, 61);
            rtbWorkerName.Name = "rtbWorkerName";
            rtbWorkerName.Size = new Size(241, 497);
            rtbWorkerName.TabIndex = 19;
            rtbWorkerName.Text = "";
            // 
            // btnSubscribeEvenThreadName
            // 
            btnSubscribeEvenThreadName.Location = new Point(876, 12);
            btnSubscribeEvenThreadName.Name = "btnSubscribeEvenThreadName";
            btnSubscribeEvenThreadName.Size = new Size(116, 43);
            btnSubscribeEvenThreadName.TabIndex = 20;
            btnSubscribeEvenThreadName.Text = "Subscribe Even Worker Name";
            btnSubscribeEvenThreadName.UseVisualStyleBackColor = true;
            btnSubscribeEvenThreadName.Click += btnSubscribeEvenThreadName_Click;
            // 
            // btnUnsubscribeEvenThreadName
            // 
            btnUnsubscribeEvenThreadName.Location = new Point(998, 12);
            btnUnsubscribeEvenThreadName.Name = "btnUnsubscribeEvenThreadName";
            btnUnsubscribeEvenThreadName.Size = new Size(116, 43);
            btnUnsubscribeEvenThreadName.TabIndex = 21;
            btnUnsubscribeEvenThreadName.Text = "Unsubscribe Even Worker Name";
            btnUnsubscribeEvenThreadName.UseVisualStyleBackColor = true;
            btnUnsubscribeEvenThreadName.Click += btnUnsubscribeEvenThreadName_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 570);
            Controls.Add(btnUnsubscribeEvenThreadName);
            Controls.Add(btnSubscribeEvenThreadName);
            Controls.Add(rtbWorkerName);
            Controls.Add(btnOddUnsubscribe);
            Controls.Add(btnOddSubscribe);
            Controls.Add(rtbOdd);
            Controls.Add(btnEvenUnsunscribe);
            Controls.Add(btnEvenSubscribe);
            Controls.Add(rtbEven);
            Controls.Add(btnNormalUnsubscribe);
            Controls.Add(btnNormalSubscribe);
            Controls.Add(rtbNormal);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbNormal;
        private Button btnNormalSubscribe;
        private Button btnNormalUnsubscribe;
        private Button btnEvenUnsunscribe;
        private Button btnEvenSubscribe;
        private RichTextBox rtbEven;
        private Button btnOddUnsubscribe;
        private Button btnOddSubscribe;
        private RichTextBox rtbOdd;
        private RichTextBox rtbWorkerName;
        private Button btnSubscribeEvenThreadName;
        private Button btnUnsubscribeEvenThreadName;
    }
}
