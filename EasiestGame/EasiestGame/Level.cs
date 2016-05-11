using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasiestGame.Properties;

namespace EasiestGame
{
    public abstract class Level
    {
        //defining the square, it's bounds and where it will start and where is the goal
        protected Square square;
        protected Rectangle bounds;
        protected Rectangle start;
        protected Rectangle end;

        protected Pen pen;
        protected SolidBrush sBrush;


        protected List<Ball> obstacles;

        public bool LevelPassed { get; set; }
        public bool isFirst { get; set; }

        protected bool coinCollected;

        //the coin and it's coordinates
        public Image coin;
        protected float coinX;
        protected float coinY;

        //sounds used in the game
        protected SoundPlayer coinSound;
        protected SoundPlayer dieSound;
        public SoundPlayer endLevel;

        //indentation fo the rectangle bounds
        private static readonly int indentationWidth = 120;
        private static readonly int indentationHeight = 140;

        private static readonly int UP = 38;
        private static readonly int DOWN = 40;
        private static readonly int LEFT = 37;
        private static readonly int RIGHT = 39;

        //keyboard input
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);


        public Level()
        {
            square = new Square();
            bounds = new Rectangle(50, 50, 720 - indentationWidth, 480 - indentationHeight);
            square.Bounds = bounds;

            pen = new Pen(Color.Black, 2);
            sBrush = new SolidBrush(Color.Lime);

            coin = Resources.coin;
            coinSound = new SoundPlayer(Resources.coinSound);
            dieSound = new SoundPlayer(Resources.dieSound);
            endLevel = new SoundPlayer(Resources.winSound);

            LevelPassed = false;
            coinCollected = false;
        }

        //check if rect1 and rect2 has collided in the plane
        protected bool rectangleCollisionDetection(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.X < rect2.X + rect2.Width && rect1.X + rect1.Width > rect2.X && rect1.Y < rect2.Y + rect2.Height && rect1.Height + rect1.Y > rect2.Y)
            {
                return true;
            }
            return false;
        }

        public virtual void Draw(Graphics canvas)
        {
            canvas.FillRectangle(sBrush, start);
            canvas.FillRectangle(sBrush, end);
            square.Draw(canvas);
            canvas.DrawRectangle(pen, bounds);

            if (!coinCollected)
            {
                canvas.DrawImage(coin, coinX, coinY);
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].Draw(canvas);
            }
        }

        public void Move()
        {
            //if the game is not paused and arrow key is pressed move the square
            if (GetAsyncKeyState(UP) != 0)
            {
                square.Move(Movement.Up, !Form1.isPaused);
            }
            if (GetAsyncKeyState(LEFT) != 0)
            {
                square.Move(Movement.Left, !Form1.isPaused);
            }
            if (GetAsyncKeyState(RIGHT) != 0)
            {
                square.Move(Movement.Right, !Form1.isPaused);
            }
            if (GetAsyncKeyState(DOWN) != 0)
            {
                square.Move(Movement.Down, !Form1.isPaused);
            }
        }

        public virtual void MoveObstacles()
        {
            foreach (Ball ball in obstacles)
            {
                ball.Move(Form1.isPaused);
            }
        }

        public virtual void CollisionDetection()
        {
            //express the square and coin as rectangles
            Rectangle sq = new Rectangle(square.Point, new Size((int)square.side, (int)square.side));
            Rectangle coinRectangle = new Rectangle((int)coinX, (int)coinY, 30, 40);

            //if the square is colliding with the coin collect it and play the appropriate sound
            if (rectangleCollisionDetection(sq, coinRectangle) && !coinCollected)
            {
                coinCollected = true;
                if (!Form1.isMuted)
                {
                    coinSound.Play();
                }
            }
            //check if the square is colliding with any of the obstacles or the end rectangle
            foreach (Ball ball in obstacles)
            {
                Rectangle obstacle = new Rectangle((int)(ball.X - ball.Radius), (int)(ball.Y - ball.Radius), (int)(2 * ball.Radius), (int)(2 * ball.Radius));
                if (rectangleCollisionDetection(obstacle, sq))
                {
                    coinCollected = false;
                    square.Point = new Point(52, 52);
                    Form1.deaths++;
                    if (!Form1.isMuted)
                    {
                        dieSound.Play();
                    }
                    break;
                }
                if (rectangleCollisionDetection(sq, end) && coinCollected)
                {
                    LevelPassed = true;
                    if (!Form1.isMuted)
                    {
                        endLevel.Play();
                    }
                    break;
                }
            }
        }

        ~Level()
        {
            pen.Dispose();
            sBrush.Dispose();
        }
    }
}