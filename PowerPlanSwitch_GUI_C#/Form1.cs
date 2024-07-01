using System.Diagnostics;

namespace PowerSwitch_GUI_C_
{
    public partial class Form1 : Form
    {
        private Thread countdownThread;
        private bool stopCountdown = false;
        public Form1()
        {
            InitializeComponent();
            countdownThread = new Thread(new ThreadStart(AutoSwitch));
            countdownThread.Start();
        }
        private void AutoSwitch()
        {
            string balancedGuid = "381b4222-f694-41f0-9685-ff5bb260df2e";
            string powerSaverGuid = "a1841308-3541-4fab-bc81-f71556f20b4a";

            string currentPlan = GetPowerPlan();

            if (currentPlan.Contains(balancedGuid))
            {
                SetPowerPlan(powerSaverGuid);
                SetPlanText("当前电源计划：节能");
                SetComboBoxSelectedText(0);
            }
            else
            {
                SetPowerPlan(balancedGuid);
                SetPlanText("当前电源计划：平衡");
                SetComboBoxSelectedText(1);
            }

            // 显示15秒的退出倒计时
            for (int i = 1500; i > 0; i--)
            {
                if (stopCountdown)
                    break;
                SetCountdownText($"程序将在{i / 100}秒后自动关闭");
                SetCountdownProcess(1500 - i);
                Thread.Sleep(10);
            }
            if (!stopCountdown)
            {
                Application.Exit();
            }
        }

        private string GetPowerPlan()
        {
            Process process = new Process();
            process.StartInfo.FileName = "powercfg";
            process.StartInfo.Arguments = "/GETACTIVESCHEME";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        private void SetPowerPlan(string plan)
        {
            Process process = new Process();
            process.StartInfo.FileName = "powercfg";
            process.StartInfo.Arguments = $"/SETACTIVE {plan}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }

        private void SetCountdownProcess(int i)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action<int>(SetCountdownProcess), new object[] { i });
            }
            else
            {
                progressBar.Value = i;
            }
        }

        private void SetPlanText(string text)
        {
            if (planLabel.InvokeRequired)
            {
                planLabel.Invoke(new Action<string>(SetPlanText), new object[] { text });
            }
            else
            {
                planLabel.Text = text;
            }
        }

        private void SetCountdownText(string text)
        {
            if (countdownLabel.InvokeRequired)
            {
                countdownLabel.Invoke(new Action<string>(SetCountdownText), new object[] { text });
            }
            else
            {
                countdownLabel.Text = text;
            }
        }

        private void SetComboBoxSelectedText(int i)
        {
            if (comboBoxSetPowePlan.InvokeRequired)
            {
                comboBoxSetPowePlan.Invoke(new Action<int>(SetComboBoxSelectedText), new object[] { i });
            }
            else
            {
                comboBoxSetPowePlan.SelectedIndex = i;
            }
        }

        private void StopCountdown(object sender, EventArgs e)
        {
            stopCountdown = true;
            countdownLabel.Visible = false;
            progressBar.Visible = false;
            stopButton.Visible = false;
            buttonExit.Location = new Point(350, 250);
        }

        private void ComboboxSelectedIndexChanged(object sender, EventArgs e)
        {
            string powerSaverGuid = "a1841308-3541-4fab-bc81-f71556f20b4a";
            string balancedGuid = "381b4222-f694-41f0-9685-ff5bb260df2e";
            string highPerformanceGuid = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
            string ultimatePerformanceGuid = "ce8813a2-e89e-4257-bad2-92e9dace9818";
            int selectedIndex = comboBoxSetPowePlan.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    SetPowerPlan(powerSaverGuid);
                    SetPlanText("当前电源计划：节能");
                    break;
                case 1:
                    SetPowerPlan(balancedGuid);
                    SetPlanText("当前电源计划：平衡");
                    break;
                case 2:
                    SetPowerPlan(highPerformanceGuid);
                    SetPlanText("当前电源计划：高性能");
                    break;
                case 3:
                    SetPowerPlan(ultimatePerformanceGuid);
                    SetPlanText("当前电源计划：卓越性能");
                    break;
            }
        }

        private void FormExit(object sender, EventArgs e)
        {
            stopCountdown = true;
            Application.Exit();
        }
    }
}