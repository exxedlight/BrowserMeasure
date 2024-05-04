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
            FinishLink = new LinkLabel();
            label1 = new Label();
            HLabel = new Label();
            SLabel = new Label();
            MLabel = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
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
            startPauseButton.FlatAppearance.BorderSize = 0;
            startPauseButton.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            startPauseButton.FlatStyle = FlatStyle.Flat;
            startPauseButton.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startPauseButton.ForeColor = Color.ForestGreen;
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
            // FinishLink
            // 
            FinishLink.AutoSize = true;
            FinishLink.LinkColor = Color.FromArgb(192, 255, 255);
            FinishLink.Location = new Point(711, 426);
            FinishLink.Name = "FinishLink";
            FinishLink.Size = new Size(77, 15);
            FinishLink.TabIndex = 2;
            FinishLink.TabStop = true;
            FinishLink.Text = "Finish service";
            FinishLink.LinkClicked += FinishLink_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 24F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(511, 220);
            label1.Name = "label1";
            label1.Size = new Size(260, 39);
            label1.TabIndex = 4;
            label1.Text = "Total browser time";
            // 
            // HLabel
            // 
            HLabel.AutoSize = true;
            HLabel.Font = new Font("Impact", 24F, FontStyle.Underline);
            HLabel.ForeColor = Color.DarkCyan;
            HLabel.Location = new Point(511, 259);
            HLabel.Name = "HLabel";
            HLabel.Size = new Size(51, 39);
            HLabel.TabIndex = 5;
            HLabel.Text = "00";
            // 
            // SLabel
            // 
            SLabel.AutoSize = true;
            SLabel.Font = new Font("Impact", 24F, FontStyle.Underline);
            SLabel.ForeColor = Color.DarkCyan;
            SLabel.Location = new Point(685, 259);
            SLabel.Name = "SLabel";
            SLabel.Size = new Size(51, 39);
            SLabel.TabIndex = 6;
            SLabel.Text = "00";
            // 
            // MLabel
            // 
            MLabel.AutoSize = true;
            MLabel.Font = new Font("Impact", 24F, FontStyle.Underline);
            MLabel.ForeColor = Color.DarkCyan;
            MLabel.Location = new Point(596, 259);
            MLabel.Name = "MLabel";
            MLabel.Size = new Size(51, 39);
            MLabel.TabIndex = 7;
            MLabel.Text = "00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 24F);
            label5.ForeColor = Color.FromArgb(81, 81, 81);
            label5.Location = new Point(556, 259);
            label5.Name = "label5";
            label5.Size = new Size(34, 39);
            label5.TabIndex = 8;
            label5.Text = "h";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 24F);
            label6.ForeColor = Color.FromArgb(81, 81, 81);
            label6.Location = new Point(637, 259);
            label6.Name = "label6";
            label6.Size = new Size(42, 39);
            label6.TabIndex = 9;
            label6.Text = "m";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Impact", 24F);
            label7.ForeColor = Color.FromArgb(81, 81, 81);
            label7.Location = new Point(727, 259);
            label7.Name = "label7";
            label7.Size = new Size(32, 39);
            label7.TabIndex = 10;
            label7.Text = "s";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(MLabel);
            Controls.Add(SLabel);
            Controls.Add(HLabel);
            Controls.Add(label1);
            Controls.Add(FinishLink);
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
        private LinkLabel FinishLink;
        private Label label1;
        private Label HLabel;
        private Label SLabel;
        private Label MLabel;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
