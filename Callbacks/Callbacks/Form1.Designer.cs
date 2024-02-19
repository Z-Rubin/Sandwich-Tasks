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
            btnNormalSubscribe.Click += button1_Click;
            // 
            // btnNormalUnsubscribe
            // 
            btnNormalUnsubscribe.Location = new Point(149, 12);
            btnNormalUnsubscribe.Name = "btnNormalUnsubscribe";
            btnNormalUnsubscribe.Size = new Size(116, 23);
            btnNormalUnsubscribe.TabIndex = 12;
            btnNormalUnsubscribe.Text = "Unsubscribe";
            btnNormalUnsubscribe.UseVisualStyleBackColor = true;
            btnNormalUnsubscribe.Click += button2_Click;
            // 
            // btnEvenUnsunscribe
            // 
            btnEvenUnsunscribe.Location = new Point(437, 12);
            btnEvenUnsunscribe.Name = "btnEvenUnsunscribe";
            btnEvenUnsunscribe.Size = new Size(116, 23);
            btnEvenUnsunscribe.TabIndex = 15;
            btnEvenUnsunscribe.Text = "Unsubscribe Even";
            btnEvenUnsunscribe.UseVisualStyleBackColor = true;
            btnEvenUnsunscribe.Click += button3_Click;
            // 
            // btnEvenSubscribe
            // 
            btnEvenSubscribe.Location = new Point(312, 12);
            btnEvenSubscribe.Name = "btnEvenSubscribe";
            btnEvenSubscribe.Size = new Size(116, 23);
            btnEvenSubscribe.TabIndex = 14;
            btnEvenSubscribe.Text = "Subscribe Even";
            btnEvenSubscribe.UseVisualStyleBackColor = true;
            btnEvenSubscribe.Click += button4_Click;
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
            btnOddUnsubscribe.Click += button5_Click;
            // 
            // btnOddSubscribe
            // 
            btnOddSubscribe.Location = new Point(598, 12);
            btnOddSubscribe.Name = "btnOddSubscribe";
            btnOddSubscribe.Size = new Size(116, 23);
            btnOddSubscribe.TabIndex = 17;
            btnOddSubscribe.Text = "Subscribe Odd";
            btnOddSubscribe.UseVisualStyleBackColor = true;
            btnOddSubscribe.Click += button6_Click;
            // 
            // rtbOdd
            // 
            rtbOdd.Location = new Point(598, 41);
            rtbOdd.Name = "rtbOdd";
            rtbOdd.Size = new Size(241, 517);
            rtbOdd.TabIndex = 16;
            rtbOdd.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 570);
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
    }
}
