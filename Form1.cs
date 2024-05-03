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
                urlGetter.Start();
            }
            else
            {
                startPauseButton.Text = "Start";
                startPauseButton.FlatAppearance.BorderColor = Color.Lime;
                urlGetter.Stop();
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {   //  not close, but hide in tray
            e.Cancel = true;
            this.Hide();
            trayIcon.Visible = true;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {   //  restore on icon double click
            this.Show();
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {   //  hide in tray when minimize
            if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }
    }
}
