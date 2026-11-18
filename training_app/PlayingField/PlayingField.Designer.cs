namespace Aim_Trainer
{
    partial class PlayingField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayingField));
            startButton = new Button();
            label1 = new Label();
            PointsCounter = new Label();
            playtimeTimer = new System.Windows.Forms.Timer(components);
            showsTimeAslabel = new Label();
            backgroundImagePlayingField = new PictureBox();
            splitContainer1 = new SplitContainer();
            backToStartButton = new Button();
            menu = new Label();
            menuBackground = new PictureBox();
            laughingGIF = new PictureBox();
            crownGIF = new PictureBox();
            noGIF = new PictureBox();
            contextMenuSettings = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            schwierigkeitToolStripMenuItem = new ToolStripMenuItem();
            easyToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            hardToolStripMenuItem = new ToolStripMenuItem();
            modiToolStripMenuItem = new ToolStripMenuItem();
            normalToolStripMenuItem = new ToolStripMenuItem();
            trackingToolStripMenuItem = new ToolStripMenuItem();
            wackaMoleToolStripMenuItem = new ToolStripMenuItem();
            colorChangeToolStripMenuItem = new ToolStripMenuItem();
            userHistoryToolStripMenuItem = new ToolStripMenuItem();
            ranglistenEinträgeSortierenToolStripMenuItem = new ToolStripMenuItem();
            heutigeEinträgeToolStripMenuItem = new ToolStripMenuItem();
            diieseWocheToolStripMenuItem = new ToolStripMenuItem();
            nachTrefferquoteToolStripMenuItem = new ToolStripMenuItem();
            ranglisteToolStripMenuItem = new ToolStripMenuItem();
            easToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem1 = new ToolStripMenuItem();
            hardToolStripMenuItem1 = new ToolStripMenuItem();
            gesamteRanglisteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)backgroundImagePlayingField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)laughingGIF).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crownGIF).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noGIF).BeginInit();
            contextMenuSettings.SuspendLayout();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Azure;
            startButton.ForeColor = Color.Black;
            startButton.Location = new Point(12, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(150, 23);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += Start_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 88);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // PointsCounter
            // 
            PointsCounter.AutoSize = true;
            PointsCounter.ForeColor = Color.Cornsilk;
            PointsCounter.Image = Properties.Resources._4283880_2821;
            PointsCounter.Location = new Point(180, 16);
            PointsCounter.Name = "PointsCounter";
            PointsCounter.Size = new Size(47, 15);
            PointsCounter.TabIndex = 2;
            PointsCounter.Text = "Punkte:";
            // 
            // showsTimeAslabel
            // 
            showsTimeAslabel.AutoSize = true;
            showsTimeAslabel.ForeColor = Color.Cornsilk;
            showsTimeAslabel.Image = Properties.Resources._4283880_2822;
            showsTimeAslabel.Location = new Point(243, 16);
            showsTimeAslabel.Name = "showsTimeAslabel";
            showsTimeAslabel.Size = new Size(30, 15);
            showsTimeAslabel.TabIndex = 3;
            showsTimeAslabel.Text = "Zeit:";
            // 
            // backgroundImagePlayingField
            // 
            backgroundImagePlayingField.ErrorImage = (Image)resources.GetObject("backgroundImagePlayingField.ErrorImage");
            backgroundImagePlayingField.Image = Properties.Resources.Spiel_3biild;
            backgroundImagePlayingField.Location = new Point(570, 38);
            backgroundImagePlayingField.Name = "backgroundImagePlayingField";
            backgroundImagePlayingField.Size = new Size(175, 127);
            backgroundImagePlayingField.TabIndex = 4;
            backgroundImagePlayingField.TabStop = false;
            backgroundImagePlayingField.Paint += PlayingField_Paint;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(backToStartButton);
            splitContainer1.Panel1.Controls.Add(startButton);
            splitContainer1.Panel1.Controls.Add(menu);
            splitContainer1.Panel1.Controls.Add(PointsCounter);
            splitContainer1.Panel1.Controls.Add(menuBackground);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(backgroundImagePlayingField);
            splitContainer1.Panel2.Controls.Add(laughingGIF);
            splitContainer1.Panel2.Controls.Add(crownGIF);
            splitContainer1.Panel2.Controls.Add(noGIF);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 43;
            splitContainer1.TabIndex = 8;
            // 
            // backToStartButton
            // 
            backToStartButton.Location = new Point(666, 12);
            backToStartButton.Name = "backToStartButton";
            backToStartButton.Size = new Size(122, 22);
            backToStartButton.TabIndex = 8;
            backToStartButton.Text = "Back to Start";
            backToStartButton.UseVisualStyleBackColor = true;
            backToStartButton.Click += Return_to_Startscreen_Click;
            // 
            // menu
            // 
            menu.AutoSize = true;
            menu.ForeColor = SystemColors.ButtonHighlight;
            menu.Image = Properties.Resources._4283880_2823;
            menu.Location = new Point(291, 16);
            menu.Name = "menu";
            menu.Size = new Size(41, 15);
            menu.TabIndex = 5;
            menu.Text = "Menü:";
            menu.Click += GameMenuOpen;
            // 
            // menuBackground
            // 
            menuBackground.Dock = DockStyle.Fill;
            menuBackground.Image = Properties.Resources._4283880_282;
            menuBackground.Location = new Point(0, 0);
            menuBackground.Name = "menuBackground";
            menuBackground.Size = new Size(800, 43);
            menuBackground.SizeMode = PictureBoxSizeMode.AutoSize;
            menuBackground.TabIndex = 0;
            menuBackground.TabStop = false;
            // 
            // laughingGIF
            // 
            laughingGIF.Image = Properties.Resources.el_risitas_juan_joya_borja;
            laughingGIF.Location = new Point(111, 65);
            laughingGIF.Name = "laughingGIF";
            laughingGIF.Size = new Size(95, 82);
            laughingGIF.TabIndex = 5;
            laughingGIF.TabStop = false;
            // 
            // crownGIF
            // 
            crownGIF.Image = Properties.Resources.giphy;
            crownGIF.Location = new Point(268, 95);
            crownGIF.Name = "crownGIF";
            crownGIF.Size = new Size(81, 93);
            crownGIF.TabIndex = 6;
            crownGIF.TabStop = false;
            // 
            // noGIF
            // 
            noGIF.Image = Properties.Resources.no_nope;
            noGIF.Location = new Point(440, 208);
            noGIF.Name = "noGIF";
            noGIF.Size = new Size(109, 88);
            noGIF.SizeMode = PictureBoxSizeMode.StretchImage;
            noGIF.TabIndex = 7;
            noGIF.TabStop = false;
            // 
            // contextMenuSettings
            // 
            contextMenuSettings.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, schwierigkeitToolStripMenuItem, modiToolStripMenuItem, colorChangeToolStripMenuItem, userHistoryToolStripMenuItem, ranglistenEinträgeSortierenToolStripMenuItem, ranglisteToolStripMenuItem });
            contextMenuSettings.Name = "contextMenuStrip1";
            contextMenuSettings.RenderMode = ToolStripRenderMode.System;
            contextMenuSettings.Size = new Size(306, 158);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(305, 22);
            toolStripMenuItem1.Text = "time";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(86, 22);
            toolStripMenuItem3.Text = "10";
            toolStripMenuItem3.Click += PlayTime10SecondsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(86, 22);
            toolStripMenuItem4.Text = "20";
            toolStripMenuItem4.Click += PlayTime20SecondsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(86, 22);
            toolStripMenuItem5.Text = "30";
            toolStripMenuItem5.Click += PlayTime30SecondsToolStripMenuItem_Click;
            // 
            // schwierigkeitToolStripMenuItem
            // 
            schwierigkeitToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { easyToolStripMenuItem, mediumToolStripMenuItem, hardToolStripMenuItem });
            schwierigkeitToolStripMenuItem.Name = "schwierigkeitToolStripMenuItem";
            schwierigkeitToolStripMenuItem.Size = new Size(305, 22);
            schwierigkeitToolStripMenuItem.Text = "Schwierigkeit";
            // 
            // easyToolStripMenuItem
            // 
            easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            easyToolStripMenuItem.Size = new Size(119, 22);
            easyToolStripMenuItem.Text = "Easy";
            easyToolStripMenuItem.Click += EasyToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem
            // 
            mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            mediumToolStripMenuItem.Size = new Size(119, 22);
            mediumToolStripMenuItem.Text = "Medium";
            mediumToolStripMenuItem.Click += MediumToolStripMenuItem_Click;
            // 
            // hardToolStripMenuItem
            // 
            hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            hardToolStripMenuItem.Size = new Size(119, 22);
            hardToolStripMenuItem.Text = "Hard";
            hardToolStripMenuItem.Click += HardToolStripMenuItem_Click;
            // 
            // modiToolStripMenuItem
            // 
            modiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { normalToolStripMenuItem, trackingToolStripMenuItem, wackaMoleToolStripMenuItem });
            modiToolStripMenuItem.Name = "modiToolStripMenuItem";
            modiToolStripMenuItem.Size = new Size(305, 22);
            modiToolStripMenuItem.Text = "Modi";
            // 
            // normalToolStripMenuItem
            // 
            normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            normalToolStripMenuItem.Size = new Size(146, 22);
            normalToolStripMenuItem.Text = "Normal";
            normalToolStripMenuItem.Click += NormalToolStripMenuItem_Click;
            // 
            // trackingToolStripMenuItem
            // 
            trackingToolStripMenuItem.Name = "trackingToolStripMenuItem";
            trackingToolStripMenuItem.Size = new Size(146, 22);
            trackingToolStripMenuItem.Text = "Tracking";
            trackingToolStripMenuItem.Click += TrackingToolStripMenuItem_Click;
            // 
            // wackaMoleToolStripMenuItem
            // 
            wackaMoleToolStripMenuItem.Name = "wackaMoleToolStripMenuItem";
            wackaMoleToolStripMenuItem.Size = new Size(146, 22);
            wackaMoleToolStripMenuItem.Text = "Wack_a_Mole";
            wackaMoleToolStripMenuItem.Click += WackaMoleToolStripMenuItem_Click;
            // 
            // colorChangeToolStripMenuItem
            // 
            colorChangeToolStripMenuItem.Name = "colorChangeToolStripMenuItem";
            colorChangeToolStripMenuItem.Size = new Size(305, 22);
            colorChangeToolStripMenuItem.Text = "Color Change";
            colorChangeToolStripMenuItem.Click += ColorChangeToolStripMenuItem_Click;
            // 
            // userHistoryToolStripMenuItem
            // 
            userHistoryToolStripMenuItem.Name = "userHistoryToolStripMenuItem";
            userHistoryToolStripMenuItem.Size = new Size(305, 22);
            userHistoryToolStripMenuItem.Text = "User History";
            userHistoryToolStripMenuItem.Click += UserHistoryToolStripMenuItem_Click;
            // 
            // ranglistenEinträgeSortierenToolStripMenuItem
            // 
            ranglistenEinträgeSortierenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { heutigeEinträgeToolStripMenuItem, diieseWocheToolStripMenuItem, nachTrefferquoteToolStripMenuItem });
            ranglistenEinträgeSortierenToolStripMenuItem.Name = "ranglistenEinträgeSortierenToolStripMenuItem";
            ranglistenEinträgeSortierenToolStripMenuItem.Size = new Size(305, 22);
            ranglistenEinträgeSortierenToolStripMenuItem.Text = "Ranglisten Einträge Sortieren nach Zeitraum";
            // 
            // heutigeEinträgeToolStripMenuItem
            // 
            heutigeEinträgeToolStripMenuItem.Name = "heutigeEinträgeToolStripMenuItem";
            heutigeEinträgeToolStripMenuItem.Size = new Size(170, 22);
            heutigeEinträgeToolStripMenuItem.Text = "Heutige Einträge";
            heutigeEinträgeToolStripMenuItem.Click += PlayersTodayToolStripMenuItem_Click;
            // 
            // diieseWocheToolStripMenuItem
            // 
            diieseWocheToolStripMenuItem.Name = "diieseWocheToolStripMenuItem";
            diieseWocheToolStripMenuItem.Size = new Size(170, 22);
            diieseWocheToolStripMenuItem.Text = "Diiese Woche";
            diieseWocheToolStripMenuItem.Click += PlayersThisWeekToolStripMenuItem_Click;
            // 
            // nachTrefferquoteToolStripMenuItem
            // 
            nachTrefferquoteToolStripMenuItem.Name = "nachTrefferquoteToolStripMenuItem";
            nachTrefferquoteToolStripMenuItem.Size = new Size(170, 22);
            nachTrefferquoteToolStripMenuItem.Text = "Nach Trefferquote";
            nachTrefferquoteToolStripMenuItem.Click += RankingAccordingToHitScoreInPercentegeToolStripMenuItem_Click;
            // 
            // ranglisteToolStripMenuItem
            // 
            ranglisteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { easToolStripMenuItem, mediumToolStripMenuItem1, hardToolStripMenuItem1, gesamteRanglisteToolStripMenuItem });
            ranglisteToolStripMenuItem.Name = "ranglisteToolStripMenuItem";
            ranglisteToolStripMenuItem.Size = new Size(305, 22);
            ranglisteToolStripMenuItem.Text = "Rangliste Sortieren nach Schwierigkeit";
            // 
            // easToolStripMenuItem
            // 
            easToolStripMenuItem.Name = "easToolStripMenuItem";
            easToolStripMenuItem.Size = new Size(168, 22);
            easToolStripMenuItem.Text = "Easy";
            easToolStripMenuItem.Click += RankingEasyToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem1
            // 
            mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            mediumToolStripMenuItem1.Size = new Size(168, 22);
            mediumToolStripMenuItem1.Text = "Medium";
            mediumToolStripMenuItem1.Click += RankingMediumToolStripMenuItem1_Click;
            // 
            // hardToolStripMenuItem1
            // 
            hardToolStripMenuItem1.Name = "hardToolStripMenuItem1";
            hardToolStripMenuItem1.Size = new Size(168, 22);
            hardToolStripMenuItem1.Text = "Hard";
            hardToolStripMenuItem1.Click += RankingHardToolStripMenuItem1_Click;
            // 
            // gesamteRanglisteToolStripMenuItem
            // 
            gesamteRanglisteToolStripMenuItem.Name = "gesamteRanglisteToolStripMenuItem";
            gesamteRanglisteToolStripMenuItem.Size = new Size(168, 22);
            gesamteRanglisteToolStripMenuItem.Text = "GesamteRangliste";
            gesamteRanglisteToolStripMenuItem.Click += WholeRankingListToolStripMenuItem_Click;
            // 
            // SpielFeld
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showsTimeAslabel);
            Controls.Add(label1);
            Controls.Add(splitContainer1);
            Name = "SpielFeld";
            Text = "SpielFeld";
            ((System.ComponentModel.ISupportInitialize)backgroundImagePlayingField).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)menuBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)laughingGIF).EndInit();
            ((System.ComponentModel.ISupportInitialize)crownGIF).EndInit();
            ((System.ComponentModel.ISupportInitialize)noGIF).EndInit();
            contextMenuSettings.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label label1;
        public Label PointsCounter;
        public System.Windows.Forms.Timer playtimeTimer;
        public Label showsTimeAslabel;
        public PictureBox backgroundImagePlayingField;
        private SplitContainer splitContainer1;
        private PictureBox menuBackground;
        public ContextMenuStrip contextMenuSettings;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label menu;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem schwierigkeitToolStripMenuItem;
        private ToolStripMenuItem easyToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem hardToolStripMenuItem;
        public PictureBox laughingGIF;
        public PictureBox crownGIF;
        public PictureBox noGIF;
        public Button backToStartButton;
        private ToolStripMenuItem userHistoryToolStripMenuItem;
        private ToolStripMenuItem colorChangeToolStripMenuItem;
        private ToolStripMenuItem ranglistenEinträgeSortierenToolStripMenuItem;
        private ToolStripMenuItem heutigeEinträgeToolStripMenuItem;
        private ToolStripMenuItem diieseWocheToolStripMenuItem;
        private ToolStripMenuItem nachTrefferquoteToolStripMenuItem;
        private ToolStripMenuItem ranglisteToolStripMenuItem;
        private ToolStripMenuItem easToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem1;
        private ToolStripMenuItem hardToolStripMenuItem1;
        private ToolStripMenuItem gesamteRanglisteToolStripMenuItem;
        private ToolStripMenuItem modiToolStripMenuItem;
        private ToolStripMenuItem normalToolStripMenuItem;
        private ToolStripMenuItem trackingToolStripMenuItem;
        private ToolStripMenuItem wackaMoleToolStripMenuItem;
    }
}
