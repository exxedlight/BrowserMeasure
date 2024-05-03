using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;
using System.Windows.Forms.Automation;
using System.Runtime.InteropServices;

namespace BrowserMeasure
{
    internal class UrlGetter
    {
        TextBox logBox;
        public UrlGetter(TextBox logTextBox)
        {
            logBox = logTextBox;
            cancellationTokenSource = new CancellationTokenSource();
            activeWindowTitleThread = new Thread(() => HandleActiveWindow(logTextBox, cancellationTokenSource.Token));
            activeWindowTitleThread.IsBackground = true;
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
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);


        Thread activeWindowTitleThread;
        CancellationTokenSource cancellationTokenSource;



        private const int UIA_ControlTypePropertyId = 30003;
        private const int UIA_EditControlTypeId = 50004;



        List<string> lastAdresses = new List<string>();



        public void HandleActiveWindow(TextBox logTextBox, CancellationToken cancellationToken)
        {
            /*string previousWindowTitle = string.Empty;
            string currentSite = string.Empty;

            while (!cancellationToken.IsCancellationRequested)
            {
                string activeWindowTitle = GetActiveWindowTitle();

                if (!string.IsNullOrEmpty(activeWindowTitle) && !activeWindowTitle.Equals(previousWindowTitle))
                {
                    previousWindowTitle = activeWindowTitle;
                    List<string> parts = activeWindowTitle.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    currentSite = parts.Last();

                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Active: {activeWindowTitle}\r\n" +
                        $"Title: {currentSite}\r\n");

                }
                else if (string.IsNullOrEmpty(activeWindowTitle) && !string.IsNullOrEmpty(previousWindowTitle))
                {
                    previousWindowTitle = string.Empty;
                    UpdateLogTextBox($"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Passive: No active window\r\n");
                }

                Thread.Sleep(1000); // Пауза 1 секунда
            }*/

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

                    if (currentWindow.Equals("Opera"))
                    {
                        string? url = GetBrowserUrl("opera");
                        if (!string.IsNullOrEmpty(url))
                        {
                            UpdateLogTextBox(logTextBox, $"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                                //$"Active: {activeWindowTitle}\r\n" +
                                $"Title: {currentWindow}\r\n" +
                                $"URL: {url}\r\n");
                        }
                    }
                    if (currentWindow.Equals("Edge"))
                    {
                        string? url = GetBrowserUrl("msedge");
                        if (!string.IsNullOrEmpty(url))
                        {
                            UpdateLogTextBox(logTextBox, $"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                                //$"Active: {activeWindowTitle}\r\n" +
                                $"Title: {currentWindow}\r\n" +
                                $"URL: {url}\r\n");
                        }
                    }

                    else
                    {
                        UpdateLogTextBox(logTextBox, $"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                            //$"Active: {activeWindowTitle}\r\n" +
                            $"Title: {currentWindow}\r\n");
                    }
                }
                else if (string.IsNullOrEmpty(activeWindowTitle) && !string.IsNullOrEmpty(previousWindowTitle))
                {
                    previousWindowTitle = string.Empty;
                    UpdateLogTextBox(logTextBox, $"{DateTime.Now.ToString("HH:mm:ss")}\r\n" +
                        $"Passive: No active window\r\n");
                }

                Thread.Sleep(1000); // Пауза 1 секунда
            }

        }
        private void UpdateLogTextBox(TextBox logTextBox, string text)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.BeginInvoke(new Action(() =>
                {
                    lastAdresses.Add(text + "\r\n");
                    if (lastAdresses.Count > 7) lastAdresses.RemoveAt(0);
                    logTextBox.Text = "";
                    lastAdresses.ForEach(x => logTextBox.Text += x);
                }));

            }
        }
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
                                    url = url.Split('/').ElementAt(2);
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
