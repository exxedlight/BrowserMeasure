using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Diagnostics;
using UIAutomationClient;
using System.Windows.Forms.Automation;
using BrowserMeasure.Entities;

namespace BrowserMeasure
{
    public partial class Form1 : Form
    {

        UrlGetter urlGetter;        //  monitoring module
        bool startedFlag = false;   //  getter are ranning?
        bool hand_finish = false;   //  manual finish program

        public Form1()
        {
            InitializeComponent();
            urlGetter = new UrlGetter(logTextBox);
        }



        private void startPauseButton_Click(object sender, EventArgs e)
        {
            startedFlag = !startedFlag;

            if (startedFlag)
            {   //  run monitoring
                startPauseButton.Text = "Stop";
                startPauseButton.ForeColor = Color.Red;
                startPauseButton.FlatAppearance.MouseOverBackColor = Color.DarkRed;
                urlGetter.Start();
            }
            else
            {   //  stop monitoring
                startPauseButton.Text = "Start";
                startPauseButton.ForeColor = Color.ForestGreen;
                startPauseButton.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
                urlGetter.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {   //  not close, but hide in tray
            if (!hand_finish)
            {
                e.Cancel = true;
            }
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
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }

        private void FinishLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   //  exit program
            hand_finish = true;
            Application.Exit();
        }
    }
}
