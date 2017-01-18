using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BricksInSpace
{
    public partial class MainWindow : Form
    {
        // PRIVATE FIELDS
        //
        private SpriteWorker playerSprite;
        private SpriteWorker missileSprite;
        private SpriteWorker cometSprite;
        private SpriteWorker enemySprite;

        private List<SpriteWorker> cometSprites;
        private List<SpriteWorker> enemySprites;
        
        private SoundPlayer audio;
        private Random rng;
        private ScoreLogger scoreLog;

        private Rectangle playerHitRect;
        private Rectangle missileHitRect;
        private Rectangle enemyHitRect;

        private const int GAMEAREA_WIDTH = 1100;
        private const int GAMEAREA_HEIGHT = 550;

        private bool missileAllowed;
        private bool missileVisible;
        private bool cometVisible;
        private bool enemyVisible;
        private bool gameStarted;

        // PROPERTIES
        //
        public int timeLeft { get; set; }

        // CONSTRUCTOR
        //
        public MainWindow()
        {
            gameStarted = false;
            missileVisible = false;
            missileAllowed = true;
            cometVisible = false;
            enemyVisible = false;

            timeLeft = 240;

            audio = new SoundPlayer();
            rng = new Random();
            cometSprites = new List<SpriteWorker>();
            enemySprites = new List<SpriteWorker>();

            InitializeComponent();
            InitAll();
        }

        // INITIALIZATIONS
        //
        private void InitAll()
        {
            InitWinSize();
            InitPanel();
            InitTimers();
        }

        private void InitWinSize()
        {
            Width = GAMEAREA_WIDTH;
            Height = GAMEAREA_HEIGHT;
        }

        private void InitPanel()
        {
            gameBox.BackColor = Color.Black;
            gameBox.Width = GAMEAREA_WIDTH;
            gameBox.Height = GAMEAREA_HEIGHT;
        }

        private void InitScoreLog()
        {
            scoreLog = new ScoreLogger();
            scoreLog.Name = NameInput.staticName;
            scoreLog.Score = 0;
        }

        // GAME STATES
        //
        private void GameOver()
        {
            gameStarted = false;

            gameOverLabel.Visible = true;

            gameBox.BackColor = Color.Black;
            gameOverLabel.BackColor = Color.OrangeRed;
            playerNameLabel.BackColor = Color.OrangeRed;
            scoreLabel.BackColor = Color.OrangeRed;
            countdownLabel.BackColor = Color.OrangeRed;

            DisableTimers();

            audio.PlayGameOverMusic();
        }

        // SET TIMERS
        //
        private void InitTimers()
        {
            mainTimer.Enabled = false;
            mainTimer.Interval = 18;

            cometTimer.Enabled = false;
            cometTimer.Interval = 300;

            enemyTimer.Enabled = false;
            enemyTimer.Interval = 1500;

            countdownTimer.Enabled = false;
            countdownTimer.Interval = 100;
        }

        private void EnableTimers()
        {
            mainTimer.Enabled = true;
            cometTimer.Enabled = true;
            enemyTimer.Enabled = true;
            countdownTimer.Enabled = true;
        }

        private void DisableTimers()
        {
            mainTimer.Enabled = false;
            cometTimer.Enabled = false;
            enemyTimer.Enabled = false;
            countdownTimer.Enabled = false;
        }

        // GENERATE SPRITES AND HIT BOXES
        //
        private void CreatePlayerSprite()
        {
            playerSprite = new SpriteWorker(0, 0, (GAMEAREA_HEIGHT - 90), 25, 20);
            playerHitRect = playerSprite.GetRectangle();
        }

        private void CreateMissileSprite()
        {
            missileVisible = true;
            missileAllowed = false;
            missileSprite = new SpriteWorker(1, (playerSprite.xPos + 7), (GAMEAREA_HEIGHT - 90), 10, 30);
            missileHitRect = missileSprite.GetRectangle();

            audio.PlayMissileSFX();
        }

        private void CreateCometSprite()
        {
            cometVisible = true;
            cometSprite = new SpriteWorker(rng.Next(2, 7), rng.Next(10, (GAMEAREA_WIDTH - 10)), (-10), rng.Next(1, 5), rng.Next(8, 30));
            cometSprites.Add(cometSprite);
        }

        private void CreateEnemySprite()
        {
            enemyVisible = true;
            enemySprite = new SpriteWorker(rng.Next(8, 13), rng.Next(40, (GAMEAREA_WIDTH - 100)), (-100), rng.Next(20, 80), rng.Next(5, 22));
            enemySprites.Add(enemySprite);
            enemyHitRect = enemySprite.GetRectangle();
        }

        //  GRAPHICS PAINTING & COLLISION DETECTIONS
        //
        private void gameBox_Paint(object sender, PaintEventArgs e)
        {
            // Increase difficulty before time runs out!
            if (timeLeft < 100)
            {
                playerNameLabel.BackColor = Color.OrangeRed;
                scoreLabel.BackColor = Color.OrangeRed;
                countdownLabel.BackColor = Color.OrangeRed;

                enemyTimer.Interval = 500;
            }

            // Game over when time runs out..
            if (timeLeft == -1) GameOver();

            if (gameStarted)
            {
                // Paint player sprite, show and update scores + coordinates.
                playerNameLabel.Visible = true;
                scoreLabel.Visible = true;
                countdownLabel.Visible = true;

                playerNameLabel.Text = scoreLog.Name;
                scoreLabel.Text = scoreLog.Score.ToString();
                countdownLabel.Text = timeLeft.ToString();

                playerSprite.PaintSprite(e);

                playerHitRect.X = playerSprite.xPos;
                playerHitRect.Y = playerSprite.yPos;

                // As long as comet timer has created comet objects..
                if (cometVisible)
                {
                    foreach (SpriteWorker cometSprite in cometSprites)
                    {
                        cometSprite.PaintSprite(e);
                    }
                }

                // Paint missile if it has been fired..
                if (missileVisible)
                {
                    missileSprite.PaintSprite(e);
                }

                // As long as enemy timer has created enemy objects..
                if (enemyVisible)
                {
                    foreach (SpriteWorker enemySprite in enemySprites)
                    {
                        // Paint enemies that aren't hit by missile..
                        if (!enemySprite.missileHitEnemy)
                        {
                            enemySprite.PaintSprite(e);

                            enemyHitRect.X = enemySprite.xPos;
                            enemyHitRect.Y = enemySprite.yPos;

                            // If missile is fired and visible on screen..
                            if (missileVisible)
                            {
                                missileHitRect.X = missileSprite.xPos;
                                missileHitRect.Y = missileSprite.yPos;

                                // If missile hit enemy.
                                if (missileHitRect.IntersectsWith(enemyHitRect))
                                {
                                    // Return so hit only register once.
                                    if (enemySprite.missileHitEnemy) return;

                                    enemySprite.missileHitEnemy = true;

                                    // Increase score by x, based on enemy speed.
                                    if (enemySprite.speed < 10) scoreLog.IncreaseScoreBy(2);
                                    else if (enemySprite.speed < 18) scoreLog.IncreaseScoreBy(4);
                                    else scoreLog.IncreaseScoreBy(8);

                                    // Increase score by x, based on enemy size.
                                    if (enemySprite.width < 25) scoreLog.IncreaseScoreBy(8);
                                    else if (enemySprite.width < 60) scoreLog.IncreaseScoreBy(4);
                                    else scoreLog.IncreaseScoreBy(2);

                                    // Allow for new missile fire.
                                    missileVisible = false;
                                    missileAllowed = true;

                                    audio.PlayEnemyHitSFX();
                                }
                            }

                            // Check if enemy hit player.
                            if (enemyHitRect.IntersectsWith(playerHitRect))
                            {
                                // Return so hit only register once.
                                if (playerSprite.enemyHitPlayer) return;

                                playerSprite.enemyHitPlayer = true;

                                // Stop the game.
                                GameOver();
                            }
                        }
                    }
                }
            }
        }

        // TIMER EVENTS, SPRITE CREATION & ANIMATION
        //
        private void backgroundTimer_Tick(object sender, EventArgs e)
        {
            CreateCometSprite();
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            CreateEnemySprite();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            // Refresh graphics painting each frame.
            Refresh();

            // Animate player sprite.
            playerSprite.MoveSpriteSideways();

            // If comet objects are created..
            if (cometVisible)
            {
                foreach (SpriteWorker cometSprite in cometSprites)
                {
                    if (cometSprite.yPos < GAMEAREA_HEIGHT)
                    {
                        // Animate comet sprite.
                        cometSprite.MoveSpriteDown();
                    }
                }
            }

            // If enemy objects are created..
            if (enemyVisible)
            {
                foreach (SpriteWorker enemy in enemySprites)
                {
                    if (enemy.yPos < GAMEAREA_HEIGHT)
                    {
                        // Animate enemy sprite.
                        enemy.MoveSpriteDown();
                    }

                }
            }

            // If missile object is created..
            if (missileVisible)
            {
                // Animate missile sprite.
                missileSprite.MoveSpriteUp();

                if (missileSprite.yPos < 0)
                {
                    // Return if missile already not visible.
                    if (!missileVisible) return;

                    // Allow for new missile fire.
                    missileVisible = false;
                    missileAllowed = true;
                }
            }
        }

        // KEY EVENTS, PLAYER CONTROLS
        //
        private void MainWin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gameStarted)
            {
                switch (e.KeyChar)
                {
                    case 'a':
                        playerSprite.xDir = -playerSprite.speed;
                        break;
                    case 'd':
                        playerSprite.xDir = playerSprite.speed;
                        break;
                    case 'k':
                        if (missileAllowed)
                        {
                            CreateMissileSprite();
                        }
                        break;
                }
            }
        }

        private void MainWin_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameStarted)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        playerSprite.xDir = -1;
                        break;
                    case Keys.D:
                        playerSprite.xDir = 1;
                        break;
                };
            }
        }

        // MENU CLICKS
        //
        private void menuItemStartGame_Click(object sender, EventArgs e)
        {
            gameBox.BackColor = Color.Black;
            audio.StopGameOverMusic();

            gameStarted = true;
            missileVisible = false;
            missileAllowed = true;
            cometVisible = false;
            enemyVisible = false;

            EnableTimers();
            CreatePlayerSprite();
            InitScoreLog();

            audio = new SoundPlayer();
            rng = new Random();
            cometSprites = new List<SpriteWorker>();
            enemySprites = new List<SpriteWorker>();
        }

        private void menuItemSaveScore_Click(object sender, EventArgs e)
        {
            scoreLog.DoWork();
        }

        private void menuItemQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemLoadScores_Click(object sender, EventArgs e)
        {
            Process.Start("scoresSorted.txt");
        }

        private void menuItemNewPlayer_Click(object sender, EventArgs e)
        {
            NameInput nInput = new NameInput();
            nInput.ShowDialog();
        }
    }
}
