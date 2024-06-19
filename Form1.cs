namespace ARDOR_TRAY
{
    public partial class Form1 : Form
    {
        private System.Diagnostics.Process _ardorGamingProcess;
        private bool isNotificationsEnabled = false;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(1250, 268);
            TopMost = true;
            OpenArdorGamingAgile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "ARDOR GAMING Agile";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
            TopMost = true;
            OpenArdorGamingAgile();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
                if (_ardorGamingProcess != null && !_ardorGamingProcess.HasExited)
                {
                    _ardorGamingProcess.CloseMainWindow();
                    _ardorGamingProcess.WaitForExit();
                }
                if (isNotificationsEnabled)
                {
                    notifyIcon1.BalloonTipTitle = "ARDOR GAMING Agile";
                    notifyIcon1.BalloonTipText = "Приложение свернуто";
                    notifyIcon1.ShowBalloonTip(3000);
                }
            }
            else
            {
                base.OnFormClosing(e);
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OpenArdorGamingAgile()
        {
            try
            {
                // Replace "C:\Path\to\ArdorGamingAgile.exe" with the actual path to the ARDOR GAMING Agile executable
                _ardorGamingProcess = System.Diagnostics.Process.Start("C:\\Program Files (x86)\\ARDOR GAMING\\Agile Wired\\OemDrv.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening ARDOR GAMING Agile: {ex.Message}");
            }
        }

        private void включитьУведомленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isNotificationsEnabled = !isNotificationsEnabled;
            включитьУведомленияToolStripMenuItem.Checked = isNotificationsEnabled;
        }
    }
}