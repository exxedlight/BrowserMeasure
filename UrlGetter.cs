using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;
using System.Windows.Forms.Automation;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using BrowserMeasure.Entities;

namespace BrowserMeasure
{
    internal class UrlGetter
    {
        TextBox logBox;                                         //  mainform log textbox
        Label HLabel, MLabel, SLabel;
        DataGridView sGrid;

        Thread activeWindowTitleThread;                         //  monitoring thread
        CancellationTokenSource cancellationTokenSource;        //  cancel tread

        //  UI elements identifiers
        private const int UIA_ControlTypePropertyId = 30003;
        private const int UIA_EditControlTypeId = 50004;

        //  
        List<string> lastAdresses = new List<string>();

        //  use windows-api dll`s
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);


        //  ===========================================================================================================

        public UrlGetter(TextBox logTextBox, Label hlabel, Label mlabel, Label slabel, DataGridView sitesGrid)
        {
            logBox = logTextBox;
            HLabel = hlabel;
            MLabel = mlabel;
            SLabel = slabel;
            sGrid = sitesGrid;
        }

        

        public void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();
            activeWindowTitleThread = new Thread(() => HandleActiveWindow(logBox, cancellationTokenSource.Token));
            activeWindowTitleThread.IsBackground = true;
            activeWindowTitleThread.Start();
        }
        public void Stop()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }





        public void updateSitesGrid()
        {
            InvokeGrid(sGrid, StaticData.siteStats);
        }







        public void HandleActiveWindow(TextBox logTextBox, CancellationToken cancellationToken)
        {
            string previousWindowTitle = string.Empty;
            string currentWindow = string.Empty;

            while (!cancellationToken.IsCancellationRequested)
            {
                string activeWindowTitle = GetActiveWindowTitle();

                if (!string.IsNullOrEmpty(activeWindowTitle) && !activeWindowTitle.Equals(previousWindowTitle))
                {
                    previousWindowTitle = activeWindowTitle;
                    List<string> parts = activeWindowTitle.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    currentWindow = parts.Last();

                    checkCurrentWindow(currentWindow);
                }
                else if (string.IsNullOrEmpty(activeWindowTitle) && !string.IsNullOrEmpty(previousWindowTitle))
                {
                    previousWindowTitle = string.Empty;
                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Passive: No active window\r\n");

                    StaticData.BrowserFinished();
                }

                Thread.Sleep(1000); // monitore every 1 second
            }

        }

        private string getProcessNameByTitle(string name)
        {
            switch (name)
            {
                case "Opera":
                    return "opera";
                case "Edge":
                    return "msedge";

                //  case "another browsers":

                default:
                    return "Unknown";
            }
        }

        public void checkCurrentWindow(string? currentWindow)
        {   //  if current windows is browser window

            if (currentWindow == "Opera" ||
                currentWindow == "Edge"
               // || currentWindow == "another browsers"
               )
            {
                string process_name = getProcessNameByTitle(currentWindow);
                string? url = GetBrowserUrl(process_name);
                if (!string.IsNullOrEmpty(url))
                {
                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Application: {currentWindow}\r\n" +
                        $"URL: {url}\r\n");

                    StaticData.pushApplication(currentWindow);
                    StaticData.pushUrl(url);
                }
            }

            //  other application
            else
            {
                UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Application: {currentWindow}\r\n");
                StaticData.BrowserFinished();

                updateTime(StaticData.getAllBrowserTime());
                updateSitesGrid();
            }
        }

        //  put time value in some label
        private void InvokeTimeLabel(Label label, int value)
        {
            if (label.InvokeRequired)
            {
                label.BeginInvoke(new Action(() =>
                {
                    label.Text = value.ToString("00");
                }));
            }
        }
        private void InvokeGrid(DataGridView grid, List<URLStat> site_stats)
        {
            if (grid.InvokeRequired)
            {
                grid.BeginInvoke(new Action(() =>
                {
                    grid.Rows.Clear();

                    foreach (URLStat stat in site_stats)
                    {
                        sGrid.Rows.Add(stat.site, 
                            new string($"{stat.elapsedTime.Hours:00}:{stat.elapsedTime.Minutes:00}:{stat.elapsedTime.Seconds:00}"));
                    }
                }));
            }
        }
        //  update time labels on the form
        private void updateTime(TimeSpan time)
        {
            InvokeTimeLabel(HLabel, time.Hours);
            InvokeTimeLabel(MLabel, time.Minutes);
            InvokeTimeLabel(SLabel, time.Seconds);
        }

        //  push new messages on log textbox in realtime
        private void UpdateLogTextBox(string text)
        {
            if (logBox.InvokeRequired)
            {
                logBox.BeginInvoke(new Action(() =>
                {
                    lastAdresses.Add(text + "\r\n");
                    if (lastAdresses.Count > 7) lastAdresses.RemoveAt(0);
                    logBox.Text = "";
                    lastAdresses.ForEach(x => logBox.Text += x);
                }));

            }
        }


        //  get URL from UI adres line, if adres line exist
        public string? GetBrowserUrl(string processName)
        {
            Process[] operaGXProcesses = Process.GetProcessesByName(processName);

            foreach (Process process in operaGXProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    IUIAutomation automation = new CUIAutomation();

                    IUIAutomationElement mainWindow = automation.ElementFromHandle(process.MainWindowHandle);
                    if (mainWindow != null)
                    {
                        IUIAutomationCondition editCondition = automation.CreatePropertyCondition(UIA_ControlTypePropertyId, UIA_EditControlTypeId);
                        var addressBar = mainWindow.FindFirst(TreeScope.TreeScope_Descendants, editCondition);
                        IUIAutomationElementArray inputs = mainWindow.FindAll(TreeScope.TreeScope_Descendants, editCondition);
                        if (addressBar != null)
                        {
                            // Получаем паттерн значения для текущего элемента
                            string url = null;
                            for (int i = 0; i < inputs.Length; i++)
                            {
                                if ((inputs.GetElement(i).GetCurrentPattern(10002) as IUIAutomationValuePattern).CurrentValue.StartsWith("http") && inputs.GetElement(i) != null)
                                {
                                    url = (inputs.GetElement(i).GetCurrentPattern(10002) as IUIAutomationValuePattern).CurrentValue;
                                    break;
                                }
                            }

                            // Получаем текстовое значение элемента
                            return url;

                        }
                    }

                }
            }

            return null;
        }


        //  get current active window title, if title exist
        static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = GetForegroundWindow();
            StringBuilder Buff = new StringBuilder(nChars);
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
    }
}
