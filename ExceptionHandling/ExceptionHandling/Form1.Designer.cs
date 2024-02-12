namespace ExceptionHandling
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(56, 46);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(147, 26);
            button1.TabIndex = 0;
            button1.Text = "Logging Logger";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(56, 76);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(147, 26);
            button2.TabIndex = 1;
            button2.Text = "Throw Error No Catch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(56, 106);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(147, 26);
            button3.TabIndex = 2;
            button3.Text = "Throw Error With Catch";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(218, 76);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(147, 26);
            button4.TabIndex = 3;
            button4.Text = "Stop Form Timer";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(218, 46);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(147, 26);
            button5.TabIndex = 4;
            button5.Text = "Start Form Timer";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button6
            // 
            button6.Location = new Point(381, 106);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(147, 26);
            button6.TabIndex = 5;
            button6.Text = "Stop System Timer";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(381, 76);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(147, 26);
            button7.TabIndex = 6;
            button7.Text = "Start System Timer";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(381, 46);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(147, 26);
            button8.TabIndex = 7;
            button8.Text = "Instantiate System Timer";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(381, 136);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(147, 26);
            button9.TabIndex = 8;
            button9.Text = "Dispose System Timer";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 351);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private System.Windows.Forms.Timer timer1;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}
