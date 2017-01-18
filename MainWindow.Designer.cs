namespace BricksInSpace
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStartGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveScore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadScores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.cometTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.gameBox = new System.Windows.Forms.PictureBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1086, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewPlayer,
            this.menuItemStartGame,
            this.menuItemSaveScore,
            this.menuItemLoadScores,
            this.menuItemQuit});
            this.menuItemMenu.Name = "menuItemMenu";
            this.menuItemMenu.Size = new System.Drawing.Size(50, 20);
            this.menuItemMenu.Text = "Menu";
            // 
            // menuItemNewPlayer
            // 
            this.menuItemNewPlayer.Name = "menuItemNewPlayer";
            this.menuItemNewPlayer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemNewPlayer.Size = new System.Drawing.Size(177, 22);
            this.menuItemNewPlayer.Text = "New Player";
            this.menuItemNewPlayer.Click += new System.EventHandler(this.menuItemNewPlayer_Click);
            // 
            // menuItemStartGame
            // 
            this.menuItemStartGame.Name = "menuItemStartGame";
            this.menuItemStartGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.menuItemStartGame.Size = new System.Drawing.Size(177, 22);
            this.menuItemStartGame.Text = "Start Game";
            this.menuItemStartGame.Click += new System.EventHandler(this.menuItemStartGame_Click);
            // 
            // menuItemSaveScore
            // 
            this.menuItemSaveScore.Name = "menuItemSaveScore";
            this.menuItemSaveScore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSaveScore.Size = new System.Drawing.Size(177, 22);
            this.menuItemSaveScore.Text = "Save Score";
            this.menuItemSaveScore.Click += new System.EventHandler(this.menuItemSaveScore_Click);
            // 
            // menuItemLoadScores
            // 
            this.menuItemLoadScores.Name = "menuItemLoadScores";
            this.menuItemLoadScores.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menuItemLoadScores.Size = new System.Drawing.Size(177, 22);
            this.menuItemLoadScores.Text = "Load Scores";
            this.menuItemLoadScores.Click += new System.EventHandler(this.menuItemLoadScores_Click);
            // 
            // menuItemQuit
            // 
            this.menuItemQuit.Name = "menuItemQuit";
            this.menuItemQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.menuItemQuit.Size = new System.Drawing.Size(177, 22);
            this.menuItemQuit.Text = "Quit";
            this.menuItemQuit.Click += new System.EventHandler(this.menuItemQuit_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // cometTimer
            // 
            this.cometTimer.Tick += new System.EventHandler(this.backgroundTimer_Tick);
            // 
            // enemyTimer
            // 
            this.enemyTimer.Tick += new System.EventHandler(this.enemyTimer_Tick);
            // 
            // countdownTimer
            // 
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // gameBox
            // 
            this.gameBox.BackColor = System.Drawing.Color.Black;
            this.gameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBox.Location = new System.Drawing.Point(0, 24);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(1086, 516);
            this.gameBox.TabIndex = 4;
            this.gameBox.TabStop = false;
            this.gameBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gameBox_Paint);
            // 
            // countdownLabel
            // 
            this.countdownLabel.BackColor = System.Drawing.Color.Transparent;
            this.countdownLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownLabel.ForeColor = System.Drawing.Color.White;
            this.countdownLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.countdownLabel.Location = new System.Drawing.Point(1014, 35);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.countdownLabel.Size = new System.Drawing.Size(60, 32);
            this.countdownLabel.TabIndex = 5;
            this.countdownLabel.Text = "120";
            this.countdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.countdownLabel.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(11, 67);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(90, 32);
            this.scoreLabel.TabIndex = 6;
            this.scoreLabel.Text = "Score";
            this.scoreLabel.Visible = false;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerNameLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.ForeColor = System.Drawing.Color.White;
            this.playerNameLabel.Location = new System.Drawing.Point(11, 35);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(105, 32);
            this.playerNameLabel.TabIndex = 7;
            this.playerNameLabel.Text = "Player";
            this.playerNameLabel.Visible = false;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(374, 245);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(347, 75);
            this.gameOverLabel.TabIndex = 8;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1086, 540);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.countdownLabel);
            this.Controls.Add(this.gameBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bricks in Space 0.1.0";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWin_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWin_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemStartGame;
        private System.Windows.Forms.Timer cometTimer;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.PictureBox gameBox;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label countdownLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveScore;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadScores;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewPlayer;
    }
}

