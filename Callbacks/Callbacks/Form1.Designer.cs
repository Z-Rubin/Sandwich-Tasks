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
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            richTextBox2 = new RichTextBox();
            button5 = new Button();
            button6 = new Button();
            richTextBox3 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(24, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(241, 517);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(24, 12);
            button1.Name = "button1";
            button1.Size = new Size(116, 23);
            button1.TabIndex = 4;
            button1.Text = "Subscribe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(149, 12);
            button2.Name = "button2";
            button2.Size = new Size(116, 23);
            button2.TabIndex = 12;
            button2.Text = "Subscribe";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(437, 12);
            button3.Name = "button3";
            button3.Size = new Size(116, 23);
            button3.TabIndex = 15;
            button3.Text = "Subscribe";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(312, 12);
            button4.Name = "button4";
            button4.Size = new Size(116, 23);
            button4.TabIndex = 14;
            button4.Text = "Subscribe";
            button4.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(312, 41);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(241, 517);
            richTextBox2.TabIndex = 13;
            richTextBox2.Text = "";
            // 
            // button5
            // 
            button5.Location = new Point(723, 12);
            button5.Name = "button5";
            button5.Size = new Size(116, 23);
            button5.TabIndex = 18;
            button5.Text = "Subscribe";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(598, 12);
            button6.Name = "button6";
            button6.Size = new Size(116, 23);
            button6.TabIndex = 17;
            button6.Text = "Subscribe";
            button6.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(598, 41);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(241, 517);
            richTextBox3.TabIndex = 16;
            richTextBox3.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 570);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(richTextBox3);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(richTextBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private RichTextBox richTextBox2;
        private Button button5;
        private Button button6;
        private RichTextBox richTextBox3;
    }
}
