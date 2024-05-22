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
            StaticData.SaveBrowserTime();
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
                StaticData.SaveBrowserTime();
            }
        }

        private async void FinishLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   //  exit program
            if (MessageBox.Show("Really want to close program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hand_finish = true;
                StaticData.SaveBrowserTime();
                await urlGetter.SaveCurrentLogAsync();
                Application.Exit();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticData.SaveBrowserTime();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            StaticData.LoadBrowserTime();
            startPauseButton.PerformClick();
        }

        private void resetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are use sure?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticData.ResetAllData();
            }

            SitesTimeGrid.Rows.Clear();
            HLabel.Text = "00";
            MLabel.Text = "00";
            SLabel.Text = "00";
            urlGetter.ClearAllLog();
        }

        private void ShowLogButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 703;
            ShowLogButton.Visible = false;
            SitesTimeGrid.Height = 591;
        }
        private void closeLogButton_Click(object sender, EventArgs e)
        {
            this.Height = 359;
            ShowLogButton.Visible = true;
            SitesTimeGrid.Height = 254;
        }

        //  min size 659; 359

        private void showSitesStatButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Width = 1145;
            showSitesStatButton.Visible = false;
        }

        private void closeSitesStatsButton_Click(object sender, EventArgs e)
        {
            this.Width = 659;
            showSitesStatButton.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            urlGetter = new UrlGetter(logTextBox, HLabel, MLabel, SLabel, SitesTimeGrid);
        }
    }
}
