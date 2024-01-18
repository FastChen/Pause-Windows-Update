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
        const string TITLE = "[��ͣWindows����]";
        const string PREFIX_DAY = "��������ͣ��ֱ�� ";
        const string PREFIX_DAY_APPLY = "����ͣ���£�ֱ�� ";

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
                Label_Day.Text = PREFIX_DAY_APPLY + expityTime.ToString("yyyy/MM/dd") + " Ϊֹ";
                Label_Day.ForeColor = Color.DarkRed;
                //MessageBox.Show($"��ǰ��������ͣʱ��Ϊ {expityTime.ToString("yyyy/MM/dd")} �Ƿ�Ҫ�������ã�");
            }
        }

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��Ҫ��ͣ Windows Update?", "ȷ�ϲ�����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

            Label_Day.Text = "������ȡ���¡�";
            Label_Day.ForeColor = Color.Green;

            MessageBox.Show($"�ѽ� Windows Update �ָ���������״̬��", "״̬��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                Label_Day.Text = PREFIX_DAY_APPLY + timeAddDays.ToString("yyyy/MM/dd") + " Ϊֹ";
                Label_Day.ForeColor = Color.DarkRed;

                MessageBox.Show($"�ɹ���ͣ Windows ���и��¡�\r\n\r\n��ʼʱ�䣺{timeNowDays.ToString("yyyy/MM/dd")}\r\nֱ����{timeAddDays.ToString("yyyy/MM/dd")} Ϊֹ", "״̬��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("���ִ���" + ex.Message);
            }
        }

        private void NumericUpDown_Week_ValueChanged(object sender, EventArgs e)
        {
            Label_Day.Text = PREFIX_DAY + DateTimeHelper.GetUTCDateTime().AddDays((int)NumericUpDown_Day.Value).ToString("yyyy/MM/dd") + " Ϊֹ";
        }

        private void Button_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"���������\r\n������ߣ�FASTCHEN\r\n���ͣ�https://fastchen.com\r\nGithub��https://github.com/fastchen\r\n\r\n���ܽ��ܣ�\r\nͨ���Զ�����ͣ��������ʵ�ֻ������õĸ��½��ã�\r\nͬʱ��Ӱ�� Microsoft Store (΢���̵�)�� Xbox ��Ϸ���������ʹ�á�\r\n\r\n�˹����ѿ�Դ��", "���ڴ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
