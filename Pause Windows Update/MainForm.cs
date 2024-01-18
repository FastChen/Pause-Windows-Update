using Microsoft.Win32;

namespace Pause_Windows_Update
{
    /// <summary>
    /// AUTHOR: FASTCHEN
    /// WEBSITE: https://fastchen.com
    /// ProjectCrateTIME: 2024-01-18
    /// GITHUB: https://github.com/FastChen/Pause-Windows-Update
    /// </summary>
    public partial class MainForm : Form
    {
        const string TITLE = "[暂停Windows更新]";
        const string PREFIX_DAY = "将更新暂停，直到 ";
        const string PREFIX_DAY_APPLY = "已暂停更新，直到 ";

        //REG_DWORD
        //FlightSettingsMaxPauseDays 9999

        //REG_SZ
        //PauseFeatureUpdatesEndTime 2031-10-04T11:33:45Z
        //PauseFeatureUpdatesStartTime  2024-01-18T11:33:45Z
        //PauseQualityUpdatesEndTime 2031-10-04T11:33:45Z
        //PauseQualityUpdatesStartTime 2024-01-18T11:33:45Z
        //PauseUpdatesExpiryTime 2031-10-04T11:33:45Z
        //PauseUpdatesStartTime 2024-01-18T11:33:45Z

        public MainForm()
        {
            InitializeComponent();
            this.Text = TITLE + $"  - v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NumericUpDown_Day.Value = 1000;

            string regExpiryTime = RegistryHelper.GetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseUpdatesExpiryTime");

            if (!string.IsNullOrEmpty(regExpiryTime))
            {
                DateTime expityTime = Convert.ToDateTime(regExpiryTime);
                Label_Day.Text = PREFIX_DAY_APPLY + expityTime.ToString("yyyy/MM/dd") + " 为止";
                Label_Day.ForeColor = Color.DarkRed;
                //MessageBox.Show($"当前已设置暂停时间为 {expityTime.ToString("yyyy/MM/dd")} 是否要继续设置？");
            }
        }

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要暂停 Windows Update?", "确认操作。", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ApplyTime();
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "FlightSettingsMaxPauseDays");

            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseFeatureUpdatesEndTime");
            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseFeatureUpdatesStartTime");

            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseQualityUpdatesEndTime");
            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseQualityUpdatesStartTime");

            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseUpdatesExpiryTime");
            RegistryHelper.DeleteValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseUpdatesStartTime");

            Label_Day.Text = "正常获取更新。";
            Label_Day.ForeColor = Color.Green;

            MessageBox.Show($"已将 Windows Update 恢复正常更新状态。", "状态提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyTime()
        {
            int addDays = (int)NumericUpDown_Day.Value;

            DateTime timeNowDays = DateTimeHelper.GetUTCDateTime();
            DateTime timeAddDays = DateTimeHelper.GetUTCDateTime().AddDays(addDays);

            string startTime = timeNowDays.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string endTime = timeAddDays.ToString("yyyy-MM-ddTHH:mm:ssZ");

            try
            {
                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "FlightSettingsMaxPauseDays", addDays * 7);

                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseFeatureUpdatesEndTime", endTime);
                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseFeatureUpdatesStartTime", startTime);

                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseQualityUpdatesEndTime", endTime);
                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseQualityUpdatesStartTime", startTime);

                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseUpdatesExpiryTime", endTime);
                RegistryHelper.SetValue(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\WindowsUpdate\UX\Settings", "PauseUpdatesStartTime", startTime);

                Label_Day.Text = PREFIX_DAY_APPLY + timeAddDays.ToString("yyyy/MM/dd") + " 为止";
                Label_Day.ForeColor = Color.DarkRed;

                MessageBox.Show($"成功暂停 Windows 所有更新。\r\n\r\n开始时间：{timeNowDays.ToString("yyyy/MM/dd")}\r\n直到：{timeAddDays.ToString("yyyy/MM/dd")} 为止", "状态提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误：" + ex.Message);
            }
        }

        private void NumericUpDown_Week_ValueChanged(object sender, EventArgs e)
        {
            Label_Day.Text = PREFIX_DAY + DateTimeHelper.GetUTCDateTime().AddDays((int)NumericUpDown_Day.Value).ToString("yyyy/MM/dd") + " 为止";
        }

        private void Button_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"关于软件：\r\n软件作者：FASTCHEN\r\n博客：https://fastchen.com\r\nGithub：https://github.com/fastchen\r\n\r\n功能介绍：\r\n通过自定义暂停更新天数实现基本永久的更新禁用，\r\n同时不影响 Microsoft Store (微软商店)与 Xbox 游戏服务的正常使用。\r\n\r\n此工具已开源。", "关于此软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
