namespace CombinedTasks
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            resultLabel = new Label();
            label1 = new Label();
            clearButton = new Button();
            calculateButton = new Button();
            inputTextBox = new RichTextBox();
            tabPage2 = new TabPage();
            timeLabel = new Label();
            label4 = new Label();
            label2 = new Label();
            timeStepCounter = new NumericUpDown();
            timeCounter = new NumericUpDown();
            label3 = new Label();
            timeLeftLabel = new Label();
            stopButton = new Button();
            startTimerButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeStepCounter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeCounter).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-1, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1459, 781);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(resultLabel);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(clearButton);
            tabPage1.Controls.Add(calculateButton);
            tabPage1.Controls.Add(inputTextBox);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1451, 743);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Equation Solver";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resultLabel.Location = new Point(106, 114);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(0, 32);
            resultLabel.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 114);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 4;
            label1.Text = "Result:";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(149, 6);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(138, 34);
            clearButton.TabIndex = 3;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(9, 6);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(134, 34);
            calculateButton.TabIndex = 2;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // inputTextBox
            // 
            inputTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputTextBox.Location = new Point(9, 46);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(278, 46);
            inputTextBox.TabIndex = 0;
            inputTextBox.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(timeLabel);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(timeStepCounter);
            tabPage2.Controls.Add(timeCounter);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(timeLeftLabel);
            tabPage2.Controls.Add(stopButton);
            tabPage2.Controls.Add(startTimerButton);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1451, 743);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Timer";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLabel.Location = new Point(205, 147);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(0, 45);
            timeLabel.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 62);
            label4.Name = "label4";
            label4.Size = new Size(47, 25);
            label4.TabIndex = 7;
            label4.Text = "Step";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 62);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 6;
            label2.Text = "Time";
            // 
            // timeStepCounter
            // 
            timeStepCounter.Location = new Point(157, 90);
            timeStepCounter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timeStepCounter.Name = "timeStepCounter";
            timeStepCounter.Size = new Size(110, 31);
            timeStepCounter.TabIndex = 5;
            timeStepCounter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // timeCounter
            // 
            timeCounter.Location = new Point(29, 90);
            timeCounter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timeCounter.Name = "timeCounter";
            timeCounter.Size = new Size(110, 31);
            timeCounter.TabIndex = 4;
            timeCounter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 147);
            label3.Name = "label3";
            label3.Size = new Size(170, 45);
            label3.TabIndex = 3;
            label3.Text = "Time Left:";
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLeftLabel.Location = new Point(205, 147);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(0, 45);
            timeLeftLabel.TabIndex = 2;
            timeLeftLabel.Click += label2_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(155, 21);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(112, 34);
            stopButton.TabIndex = 1;
            stopButton.Text = "Stop Timer";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startTimerButton
            // 
            startTimerButton.Location = new Point(27, 21);
            startTimerButton.Name = "startTimerButton";
            startTimerButton.Size = new Size(112, 34);
            startTimerButton.TabIndex = 0;
            startTimerButton.Text = "Start Timer";
            startTimerButton.UseVisualStyleBackColor = true;
            startTimerButton.Click += startTimerButton_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 778);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeStepCounter).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeCounter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label resultLabel;
        private Label label1;
        private Button clearButton;
        private Button calculateButton;
        private RichTextBox inputTextBox;
        private TabPage tabPage2;
        private Label label3;
        private Label timeLeftLabel;
        private Button stopButton;
        private Button startTimerButton;
        private Label label4;
        private Label label2;
        private NumericUpDown timeStepCounter;
        private NumericUpDown timeCounter;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
