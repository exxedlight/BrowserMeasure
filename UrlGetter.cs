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
using System.Text.Json;

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
            LoadPrevLog();
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



        public async Task SaveCurrentLogAsync()
        {
            string logText = null;

            if (logBox.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    logBox.Invoke(new Action(() =>
                    {
                        logText = logBox.Text;
                    }));
                });
            }
            else
            {
                logText = logBox.Text;
            }

            if (logText != null) await File.WriteAllTextAsync("logBox.log", logText);

            await File.WriteAllTextAsync("logStruct.json", JsonSerializer.Serialize(lastAdresses, new JsonSerializerOptions { WriteIndented = true }));
        }
        public void LoadPrevLog()
        {
            string? logText = null;
            if (File.Exists("logBox.log")) logText = File.ReadAllText("logBox.log");

            if (logText != null)
            {
                logBox.BeginInvoke(new Action(() =>
                {
                    logBox.Text = logText;
                }));
            }

            if (File.Exists("logStruct.json"))
            {
                try
                {
                    lastAdresses = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("logStruct.json"));
                }
                catch
                {
                    File.Delete("logStruct.json");
                    lastAdresses = new List<string>();
                }
            }
        }
        public void ClearAllLog()
        {
            if (File.Exists("logBox.log")) File.Delete("logBox.log");
            if (File.Exists("logStruct.json")) File.Delete("logStruct.json");

            lastAdresses = new List<string>();
            if (logBox.InvokeRequired)
            {
                logBox.BeginInvoke(new Action(() =>
                {
                    logBox.Text = string.Empty;
                }));
            }
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

                    checkCurrentWindow(activeWindowTitle, currentWindow);
                }
                else if (string.IsNullOrEmpty(activeWindowTitle) && !string.IsNullOrEmpty(previousWindowTitle))
                {
                    previousWindowTitle = string.Empty;
                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Passive: No active window\r\n");

                    StaticData.BrowserFinished();
                }

                Thread.Sleep(1500); // monitore every 1 second
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
                case "Chrome":
                    return "chrome";

                //  case "another browsers":

                default:
                    return "Unknown";
            }
        }

        public void checkCurrentWindow(string? fullName, string? currentWindow)
        {   //  if current windows is browser window

            if (currentWindow == "Opera" ||
                currentWindow == "Edge" ||
                currentWindow == "Chrome"
               // || currentWindow == "another browsers"
               )
            {
                string process_name = getProcessNameByTitle(currentWindow);
                string? url = GetBrowserUrl(process_name);
                if (!string.IsNullOrEmpty(url))
                {
                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Application: {fullName}\r\n" +
                        $"URL: {url}\r\n");

                    StaticData.pushApplication(currentWindow);
                    StaticData.pushUrl(url);
                }
            }

            //  other application
            else
            {
                UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Application: {fullName}\r\n");
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

                    lastAdresses.Insert(0, text + "\r\n");
                    
                    if(logBox.Text.Length + lastAdresses[0].Length > Int32.MaxValue-5000)
                    {
                        File.WriteAllText($"log_{DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss.ff")}.log", logBox.Text);
                        File.WriteAllTextAsync($"logStruct_{DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss.ff")}.json", JsonSerializer.Serialize(lastAdresses, new JsonSerializerOptions { WriteIndented = true }));

                        lastAdresses.RemoveRange(1, lastAdresses.Count-2);

                        logBox.Text = "[Overflow] Log overflowed, prev log saved to file in program directory, current log cleaned\n\r";
                        logBox.Text = lastAdresses[0] + logBox.Text;
                    }
                    else
                        logBox.Text = lastAdresses[0] + logBox.Text;

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
                        if (addressBar != null && inputs != null)
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
