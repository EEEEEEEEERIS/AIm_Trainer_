namespace Aim_Trainer
{
    partial class StartScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            startScreenBackground = new PictureBox();
            startButton = new Button();
            SettingsButton = new Button();
            howToPlayButton = new Button();
            showRankinglistButton = new Button();
            secretButton = new Button();
            ((System.ComponentModel.ISupportInitialize)startScreenBackground).BeginInit();
            SuspendLayout();
            // 
            // startScreenBackground
            // 
            startScreenBackground.Image = Properties.Resources._4283880_2827;
            startScreenBackground.Location = new Point(0, 0);
            startScreenBackground.Name = "startScreenBackground";
            startScreenBackground.Size = new Size(897, 474);
            startScreenBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            startScreenBackground.TabIndex = 0;
            startScreenBackground.TabStop = false;
            // 
            // startButton
            // 
            startButton.Location = new Point(211, 145);
            startButton.Name = "startButton";
            startButton.Size = new Size(115, 27);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(223, 218);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(90, 23);
            SettingsButton.TabIndex = 6;
            SettingsButton.Text = "Einstellungen";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // howToPlayButton
            // 
            howToPlayButton.Location = new Point(223, 247);
            howToPlayButton.Name = "howToPlayButton";
            howToPlayButton.Size = new Size(88, 24);
            howToPlayButton.TabIndex = 7;
            howToPlayButton.Text = "How to play";
            howToPlayButton.UseVisualStyleBackColor = true;
            howToPlayButton.Click += HowToPlayButton_Click;
            // 
            // showRankinglistButton
            // 
            showRankinglistButton.Location = new Point(225, 188);
            showRankinglistButton.Name = "showRankinglistButton";
            showRankinglistButton.Size = new Size(88, 24);
            showRankinglistButton.TabIndex = 8;
            showRankinglistButton.Text = "Rangliste";
            showRankinglistButton.UseVisualStyleBackColor = true;
            showRankinglistButton.Click += ShowRankingListButton_Click;
            // 
            // secretButton
            // 
            secretButton.BackColor = SystemColors.ActiveCaptionText;
            secretButton.BackgroundImage = (Image)resources.GetObject("secretButton.BackgroundImage");
            secretButton.Image = (Image)resources.GetObject("secretButton.Image");
            secretButton.Location = new Point(836, 445);
            secretButton.Name = "secretButton";
            secretButton.Size = new Size(26, 14);
            secretButton.TabIndex = 9;
            secretButton.UseVisualStyleBackColor = false;
            secretButton.Click += SecretButton_Click;
            // 
            // StartScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(secretButton);
            Controls.Add(showRankinglistButton);
            Controls.Add(howToPlayButton);
            Controls.Add(SettingsButton);
            Controls.Add(startButton);
            Controls.Add(startScreenBackground);
            Name = "StartScreen";
            Size = new Size(970, 544);
            ((System.ComponentModel.ISupportInitialize)startScreenBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox startScreenBackground;
        private Button startButton;
        private Button SettingsButton;
        private Button howToPlayButton;
        private Button showRankinglistButton;
        private Button secretButton;
    }
}
