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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
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
            SitesTimeGrid = new DataGridView();
            Site = new DataGridViewTextBoxColumn();
            TotalTime = new DataGridViewTextBoxColumn();
            resetLinkLabel = new LinkLabel();
            label2 = new Label();
            showSitesStatButton = new LinkLabel();
            ShowLogButton = new LinkLabel();
            closeLogButton = new Button();
            closeSitesStatsButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)SitesTimeGrid).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // logTextBox
            // 
            logTextBox.BackColor = SystemColors.InactiveCaptionText;
            logTextBox.BorderStyle = BorderStyle.None;
            logTextBox.Font = new Font("Comic Sans MS", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            logTextBox.ForeColor = Color.ForestGreen;
            logTextBox.Location = new Point(8, 53);
            logTextBox.MaxLength = int.MaxValue;
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(617, 282);
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
            startPauseButton.Location = new Point(22, 57);
            startPauseButton.Name = "startPauseButton";
            startPauseButton.Size = new Size(351, 129);
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
            FinishLink.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FinishLink.LinkBehavior = LinkBehavior.HoverUnderline;
            FinishLink.LinkColor = Color.FromArgb(192, 255, 255);
            FinishLink.Location = new Point(22, 228);
            FinishLink.Name = "FinishLink";
            FinishLink.Size = new Size(135, 19);
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
            label1.Location = new Point(379, 57);
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
            HLabel.Location = new Point(384, 105);
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
            SLabel.Location = new Point(558, 105);
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
            MLabel.Location = new Point(469, 105);
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
            label5.Location = new Point(429, 105);
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
            label6.Location = new Point(510, 105);
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
            label7.Location = new Point(600, 105);
            label7.Name = "label7";
            label7.Size = new Size(32, 39);
            label7.TabIndex = 10;
            label7.Text = "s";
            // 
            // SitesTimeGrid
            // 
            SitesTimeGrid.AllowUserToAddRows = false;
            SitesTimeGrid.AllowUserToDeleteRows = false;
            SitesTimeGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(224, 224, 224);
            SitesTimeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            SitesTimeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SitesTimeGrid.BackgroundColor = Color.FromArgb(80, 80, 80);
            SitesTimeGrid.BorderStyle = BorderStyle.None;
            SitesTimeGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            SitesTimeGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.Info;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            SitesTimeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            SitesTimeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SitesTimeGrid.Columns.AddRange(new DataGridViewColumn[] { Site, TotalTime });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.InfoText;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ButtonFace;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            SitesTimeGrid.DefaultCellStyle = dataGridViewCellStyle9;
            SitesTimeGrid.GridColor = Color.FromArgb(80, 80, 80);
            SitesTimeGrid.Location = new Point(3, 50);
            SitesTimeGrid.Name = "SitesTimeGrid";
            SitesTimeGrid.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            SitesTimeGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            SitesTimeGrid.RowHeadersVisible = false;
            SitesTimeGrid.ScrollBars = ScrollBars.Vertical;
            SitesTimeGrid.Size = new Size(437, 593);
            SitesTimeGrid.TabIndex = 11;
            // 
            // Site
            // 
            dataGridViewCellStyle8.BackColor = Color.Black;
            dataGridViewCellStyle8.ForeColor = Color.White;
            Site.DefaultCellStyle = dataGridViewCellStyle8;
            Site.HeaderText = "Site";
            Site.Name = "Site";
            Site.ReadOnly = true;
            // 
            // TotalTime
            // 
            TotalTime.HeaderText = "TotalTime";
            TotalTime.Name = "TotalTime";
            TotalTime.ReadOnly = true;
            // 
            // resetLinkLabel
            // 
            resetLinkLabel.AutoSize = true;
            resetLinkLabel.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            resetLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            resetLinkLabel.LinkColor = Color.FromArgb(192, 255, 255);
            resetLinkLabel.Location = new Point(384, 167);
            resetLinkLabel.Name = "resetLinkLabel";
            resetLinkLabel.Size = new Size(146, 19);
            resetLinkLabel.TabIndex = 12;
            resetLinkLabel.TabStop = true;
            resetLinkLabel.Text = "↺ Reset timer ↺";
            resetLinkLabel.LinkClicked += resetLinkLabel_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(3, 25);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 13;
            label2.Text = "Log:";
            // 
            // showSitesStatButton
            // 
            showSitesStatButton.AutoSize = true;
            showSitesStatButton.Font = new Font("Consolas", 15F);
            showSitesStatButton.LinkBehavior = LinkBehavior.HoverUnderline;
            showSitesStatButton.LinkColor = Color.FromArgb(192, 255, 255);
            showSitesStatButton.Location = new Point(339, 294);
            showSitesStatButton.Name = "showSitesStatButton";
            showSitesStatButton.Size = new Size(298, 23);
            showSitesStatButton.TabIndex = 14;
            showSitesStatButton.TabStop = true;
            showSitesStatButton.Text = "Show sites staticstics >⤕>";
            showSitesStatButton.LinkClicked += showSitesStatButton_LinkClicked;
            // 
            // ShowLogButton
            // 
            ShowLogButton.AutoSize = true;
            ShowLogButton.Font = new Font("Consolas", 15F);
            ShowLogButton.LinkBehavior = LinkBehavior.HoverUnderline;
            ShowLogButton.LinkColor = Color.FromArgb(192, 255, 255);
            ShowLogButton.Location = new Point(22, 294);
            ShowLogButton.Name = "ShowLogButton";
            ShowLogButton.Size = new Size(142, 23);
            ShowLogButton.TabIndex = 15;
            ShowLogButton.TabStop = true;
            ShowLogButton.Text = "↨ Show log ↨";
            ShowLogButton.LinkClicked += ShowLogButton_LinkClicked;
            // 
            // closeLogButton
            // 
            closeLogButton.FlatAppearance.BorderColor = Color.Lime;
            closeLogButton.FlatAppearance.BorderSize = 0;
            closeLogButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            closeLogButton.FlatStyle = FlatStyle.Flat;
            closeLogButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            closeLogButton.ForeColor = Color.Gray;
            closeLogButton.Location = new Point(528, 8);
            closeLogButton.Margin = new Padding(0);
            closeLogButton.Name = "closeLogButton";
            closeLogButton.Padding = new Padding(1);
            closeLogButton.Size = new Size(97, 42);
            closeLogButton.TabIndex = 16;
            closeLogButton.Text = "⛌";
            closeLogButton.UseVisualStyleBackColor = true;
            closeLogButton.Click += closeLogButton_Click;
            // 
            // closeSitesStatsButton
            // 
            closeSitesStatsButton.FlatAppearance.BorderColor = Color.Lime;
            closeSitesStatsButton.FlatAppearance.BorderSize = 0;
            closeSitesStatsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            closeSitesStatsButton.FlatStyle = FlatStyle.Flat;
            closeSitesStatsButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            closeSitesStatsButton.ForeColor = Color.Gray;
            closeSitesStatsButton.Location = new Point(343, 2);
            closeSitesStatsButton.Margin = new Padding(0);
            closeSitesStatsButton.Name = "closeSitesStatsButton";
            closeSitesStatsButton.Padding = new Padding(1);
            closeSitesStatsButton.Size = new Size(97, 42);
            closeSitesStatsButton.TabIndex = 17;
            closeSitesStatsButton.Text = "⛌";
            closeSitesStatsButton.UseVisualStyleBackColor = true;
            closeSitesStatsButton.Click += closeSitesStatsButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(logTextBox);
            panel1.Controls.Add(closeLogButton);
            panel1.Location = new Point(22, 320);
            panel1.Name = "panel1";
            panel1.Size = new Size(638, 421);
            panel1.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(SitesTimeGrid);
            panel2.Controls.Add(closeSitesStatsButton);
            panel2.Location = new Point(681, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(616, 702);
            panel2.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(643, 320);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ShowLogButton);
            Controls.Add(showSitesStatButton);
            Controls.Add(resetLinkLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(MLabel);
            Controls.Add(SLabel);
            Controls.Add(HLabel);
            Controls.Add(label1);
            Controls.Add(FinishLink);
            Controls.Add(startPauseButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Shown += Form1_Shown;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)SitesTimeGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
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
        private DataGridViewTextBoxColumn Site;
        private DataGridViewTextBoxColumn TotalTime;
        private DataGridView SitesTimeGrid;
        private LinkLabel resetLinkLabel;
        private Label label2;
        private LinkLabel showSitesStatButton;
        private LinkLabel ShowLogButton;
        private Button closeLogButton;
        private Button closeSitesStatsButton;
        private Panel panel1;
        private Panel panel2;
    }
}
