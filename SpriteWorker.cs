using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BricksInSpace
{
    public class SpriteWorker
    {
        // FIELDS
        // 
        private Graphics graphics;
        private SolidBrush brush;
        private Color color;
        private Rectangle rectangle;

        public int xPos { get; set; }
        public int yPos { get; set; }
        public int xDir { get; set; }
        public int yDir { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int speed { get; set; }

        public bool missileHitEnemy { get; set; }
        public bool enemyHitPlayer { get; set; }

        public int colorIndex { get; set; }
        private Color[] colors = new Color[14]
        {
            Color.LightGreen, // 0 = player
            Color.Yellow, // 1 = missile
            Color.LightGray, // 2 = comet
            Color.LightSlateGray, // 3 = comet
            Color.SlateGray, // 4 = comet
            Color.Gray, // 5 = comet
            Color.DimGray, // 6 = comet
            Color.DarkSlateGray, // 7 = comet
            Color.OrangeRed, // 8 = enemy
            Color.Indigo, // 9 = enemy
            Color.DarkMagenta, // 10 = enemy
            Color.DeepSkyBlue, // 11 = enemy
            Color.Tomato, // 12 = enemy
            Color.BlueViolet // 13 = enemy
        };

        // CONSTRUCTOR
        //
        public SpriteWorker(int colorIndex, int xPos, int yPos, int width, int speed)
        {
            color = colors[colorIndex];

            this.xPos = xPos;
            this.yPos = yPos;
            this.width = width;
            height = width;
            this.speed = speed;

            InitializeGraphics();
        }

        // GRAPHICS
        //
        private void InitializeGraphics()
        {
            brush = new SolidBrush(color);
            rectangle = new Rectangle(xPos, yPos, width, height);
        }

        public void PaintSprite(PaintEventArgs e)
        {
            rectangle.X = xPos;
            rectangle.Y = yPos;
            graphics = e.Graphics;
            graphics.FillRectangle(brush, rectangle);
        }

        // ANIMATION
        //
        public void MoveSpriteSideways()
        {
            xPos += xDir;
        }

        public void MoveSpriteUp()
        {
            yPos -= speed;
        }

        public void MoveSpriteDown()
        {
            yPos += speed;
        }

        // RETURN RECTANGLE OBJECTS FOR HIT DETECTION
        //
        public Rectangle GetRectangle()
        {
            rectangle = new Rectangle();

            rectangle.Height = height;
            rectangle.Width = height;
            rectangle.X = xPos;
            rectangle.Y = yPos;

            return rectangle;
        }

    }
}
