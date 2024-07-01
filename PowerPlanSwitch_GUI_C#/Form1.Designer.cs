namespace PowerSwitch_GUI_C_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            planLabel = new Label();
            comboBoxSetPowePlan = new ComboBox();
            countdownLabel = new Label();
            progressBar = new ProgressBar();
            stopButton = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // planLabel
            // 
            planLabel.Font = new Font("Microsoft YaHei UI", 16F);
            planLabel.Location = new Point(200, 40);
            planLabel.Name = "planLabel";
            planLabel.Size = new Size(400, 41);
            planLabel.TabIndex = 0;
            planLabel.Text = "电源计划：未知";
            planLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxSetPowePlan
            // 
            comboBoxSetPowePlan.CausesValidation = false;
            comboBoxSetPowePlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSetPowePlan.FormattingEnabled = true;
            comboBoxSetPowePlan.ImeMode = ImeMode.NoControl;
            comboBoxSetPowePlan.Items.AddRange(new object[] { "节能", "平衡", "高性能", "卓越性能" });
            comboBoxSetPowePlan.Location = new Point(325, 150);
            comboBoxSetPowePlan.Name = "comboBoxSetPowePlan";
            comboBoxSetPowePlan.Size = new Size(150, 32);
            comboBoxSetPowePlan.TabIndex = 1;
            comboBoxSetPowePlan.Tag = "请选择电源计划";
            comboBoxSetPowePlan.SelectedIndexChanged += ComboboxSelectedIndexChanged;
            comboBoxSetPowePlan.Click += StopCountdown;
            // 
            // countdownLabel
            // 
            countdownLabel.BackColor = SystemColors.Control;
            countdownLabel.Font = new Font("Microsoft YaHei UI", 10F);
            countdownLabel.Location = new Point(275, 225);
            countdownLabel.Name = "countdownLabel";
            countdownLabel.Size = new Size(250, 40);
            countdownLabel.TabIndex = 2;
            countdownLabel.Text = "程序将在15秒后自动关闭";
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(100, 300);
            progressBar.MarqueeAnimationSpeed = 10;
            progressBar.Maximum = 1500;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(600, 40);
            progressBar.Step = 1;
            progressBar.TabIndex = 3;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(488, 400);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(112, 34);
            stopButton.TabIndex = 4;
            stopButton.Text = "停止倒计时";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopCountdown;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(200, 400);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(112, 34);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "退出切换器";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += FormExit;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(778, 544);
            Controls.Add(countdownLabel);
            Controls.Add(buttonExit);
            Controls.Add(stopButton);
            Controls.Add(progressBar);
            Controls.Add(comboBoxSetPowePlan);
            Controls.Add(planLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "电源选计划切换器";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Label planLabel;
        private ComboBox comboBoxSetPowePlan;
        private Label countdownLabel;
        private ProgressBar progressBar;
        private Button stopButton;
        private Button buttonExit;
    }
}
