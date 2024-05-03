using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Diagnostics;
using UIAutomationClient;
using System.Windows.Forms.Automation;

namespace BrowserMeasure
{
    public partial class Form1 : Form
    {


        UrlGetter urlGetter;

        public Form1()
        {
            InitializeComponent();
            urlGetter = new UrlGetter(logTextBox);
        }

        bool startedFlag = false;

        private void startPauseButton_Click(object sender, EventArgs e)
        {

            startedFlag = !startedFlag;

            if (startedFlag)
            {
                startPauseButton.Text = "Stop";
                startPauseButton.FlatAppearance.BorderColor = Color.Red;
                cancellationTokenSource = new CancellationTokenSource();
                activeWindowTitleThread = new Thread(() => HandleActiveWindow(cancellationTokenSource.Token));
                activeWindowTitleThread.IsBackground = true;
                activeWindowTitleThread.Start();
            }
            else
            {
                startPauseButton.Text = "Start";
                startPauseButton.FlatAppearance.BorderColor = Color.Lime;
                cancellationTokenSource.Cancel();
            }


        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            trayIcon.Visible = true;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }
    }
}
