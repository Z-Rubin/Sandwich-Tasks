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
            button12 = new Button();
            button13 = new Button();
            button10 = new Button();
            button11 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(80, 77);
            button1.Name = "button1";
            button1.Size = new Size(210, 43);
            button1.TabIndex = 0;
            button1.Text = "Logging Logger";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(80, 127);
            button2.Name = "button2";
            button2.Size = new Size(210, 43);
            button2.TabIndex = 1;
            button2.Text = "Throw Error No Catch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(80, 177);
            button3.Name = "button3";
            button3.Size = new Size(210, 43);
            button3.TabIndex = 2;
            button3.Text = "Throw Error With Catch";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(311, 127);
            button4.Name = "button4";
            button4.Size = new Size(210, 43);
            button4.TabIndex = 3;
            button4.Text = "Stop Form Timer";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(311, 77);
            button5.Name = "button5";
            button5.Size = new Size(210, 43);
            button5.TabIndex = 4;
            button5.Text = "Start Form Timer";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // button6
            // 
            button6.Location = new Point(544, 177);
            button6.Name = "button6";
            button6.Size = new Size(210, 43);
            button6.TabIndex = 5;
            button6.Text = "Stop System Timer";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(544, 127);
            button7.Name = "button7";
            button7.Size = new Size(210, 43);
            button7.TabIndex = 6;
            button7.Text = "Start System Timer";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(544, 77);
            button8.Name = "button8";
            button8.Size = new Size(210, 43);
            button8.TabIndex = 7;
            button8.Text = "Instantiate System Timer";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(544, 227);
            button9.Name = "button9";
            button9.Size = new Size(210, 43);
            button9.TabIndex = 8;
            button9.Text = "Dispose System Timer";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button12
            // 
            button12.Location = new Point(781, 77);
            button12.Name = "button12";
            button12.Size = new Size(210, 43);
            button12.TabIndex = 10;
            button12.Text = "Start  Threading Timer";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(781, 127);
            button13.Name = "button13";
            button13.Size = new Size(210, 43);
            button13.TabIndex = 9;
            button13.Text = "Stop Thread Timer";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button10
            // 
            button10.Location = new Point(80, 227);
            button10.Name = "button10";
            button10.Size = new Size(210, 43);
            button10.TabIndex = 11;
            button10.Text = "Divide by Zero";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(80, 277);
            button11.Name = "button11";
            button11.Size = new Size(210, 43);
            button11.TabIndex = 12;
            button11.Text = "Call Task Sync";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click_1;
            // 
            // button14
            // 
            button14.Location = new Point(80, 327);
            button14.Name = "button14";
            button14.Size = new Size(210, 43);
            button14.TabIndex = 13;
            button14.Text = "Call Task Async";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(80, 377);
            button15.Name = "button15";
            button15.Size = new Size(210, 43);
            button15.TabIndex = 14;
            button15.Text = "Cascading Methods";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(80, 427);
            button16.Name = "button16";
            button16.Size = new Size(210, 43);
            button16.TabIndex = 15;
            button16.Text = "Catch Outside Task.Run";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(80, 477);
            button17.Name = "button17";
            button17.Size = new Size(210, 43);
            button17.TabIndex = 16;
            button17.Text = "Catch Inside Task.Run";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button19
            // 
            button19.Location = new Point(781, 427);
            button19.Name = "button19";
            button19.Size = new Size(237, 43);
            button19.TabIndex = 18;
            button19.Text = "Toggle Text without Invoke";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button20
            // 
            button20.Location = new Point(781, 477);
            button20.Name = "button20";
            button20.Size = new Size(237, 43);
            button20.TabIndex = 19;
            button20.Text = "On";
            button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            button21.Location = new Point(544, 427);
            button21.Name = "button21";
            button21.Size = new Size(210, 43);
            button21.TabIndex = 20;
            button21.Text = "Toggle Text with Invoke";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 585);
            Controls.Add(button21);
            Controls.Add(button20);
            Controls.Add(button19);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button12);
            Controls.Add(button13);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button12;
        private Button button13;
        private Button button10;
        private Button button11;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button19;
        private Button button20;
        private Button button21;
    }
}
