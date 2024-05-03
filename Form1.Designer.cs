namespace BrowserMeasure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            logTextBox = new TextBox();
            startPauseButton = new Button();
            trayIcon = new NotifyIcon(components);
            SuspendLayout();
            // 
            // logTextBox
            // 
            logTextBox.BackColor = SystemColors.InactiveCaptionText;
            logTextBox.BorderStyle = BorderStyle.None;
            logTextBox.Font = new Font("Comic Sans MS", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            logTextBox.ForeColor = Color.ForestGreen;
            logTextBox.Location = new Point(12, 12);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.Size = new Size(493, 426);
            logTextBox.TabIndex = 0;
            // 
            // startPauseButton
            // 
            startPauseButton.FlatAppearance.BorderColor = Color.Lime;
            startPauseButton.FlatStyle = FlatStyle.Flat;
            startPauseButton.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startPauseButton.Location = new Point(511, 12);
            startPauseButton.Name = "startPauseButton";
            startPauseButton.Size = new Size(277, 124);
            startPauseButton.TabIndex = 1;
            startPauseButton.Text = "Start";
            startPauseButton.UseVisualStyleBackColor = true;
            startPauseButton.Click += startPauseButton_Click;
            // 
            // trayIcon
            // 
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "Track browsers screen time";
            trayIcon.BalloonTipTitle = "Browser tracking";
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "BrowserTime";
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(startPauseButton);
            Controls.Add(logTextBox);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox logTextBox;
        private Button startPauseButton;
        private NotifyIcon trayIcon;
    }
}
