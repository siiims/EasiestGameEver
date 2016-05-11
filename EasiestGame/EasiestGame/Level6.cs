using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    class Level6 : Level
    {
        private Rectangle safePoint;
        private bool safePointReached;


        public Level6()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Left, bounds.Bottom - 50, 50, 50);
            safePoint = new Rectangle(bounds.Right - 35, 45 + (bounds.Bottom - bounds.Top) / 2, 35, 35);

            coinX = bounds.Left + 135;
            coinY = (bounds.Bottom - bounds.Top) - 90;

            safePointReached = false;

            obstacles = new List<Ball>();
            float cX = 202;
            float cY = 132;
            double speed = 0.025;

            for (int i = 0; i < 3; i++)
            {
                createCirclingBalls(cX, cY, speed);
                cX += 175;
            }
            cX -= 175;
            speed = 0.02;
            for (int i = 0; i < 3; i++)
            {
                createCirclingBalls(cX, cY + 175, speed);
                cX -= 175;
            }
            for (int x = bounds.Left + 15; x < bounds.Right - 35; x += 30)
            {
                for (int y = bounds.Top + 180; y < bounds.Bottom - 150; y += 30)
                {
                    Ball staticBall = new Ball(new Point(x, y), 9, bounds);
                    obstacles.Add(staticBall);
                }
            }
        }

        private void createCirclingBalls(float cX, float cY, double speed)
        {
            int circlingRadius = 0;
            for (int i = 1; i < 5; i++)
            {
                CirclingBall cb1 = new CirclingBall(new Point(), 9, bounds, circlingRadius, cX, cY, 0, speed);
                CirclingBall cb2 = new CirclingBall(new Point(), 9, bounds, -circlingRadius, cX, cY, 0, speed);
                CirclingBall cb3 = new CirclingBall(new Point(), 9, bounds, circlingRadius, cX, cY, Math.PI / 2, speed);
                CirclingBall cb4 = new CirclingBall(new Point(), 9, bounds, -circlingRadius, cX, cY, Math.PI / 2, speed);
                obstacles.Add(cb1);
                obstacles.Add(cb2);
                obstacles.Add(cb3);
                obstacles.Add(cb4);
                circlingRadius += 25;
            }
        }


        public override void Draw(Graphics canvas)
        {
            canvas.FillRectangle(sBrush, start);
            canvas.FillRectangle(sBrush, end);
            canvas.FillRectangle(sBrush, safePoint);
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

        public override void CollisionDetection()
        {
            //express the square and coin as rectangles
            Rectangle sq = new Rectangle(square.Point, new Size((int)square.side, (int)square.side));
            Rectangle coinRectangle = new Rectangle((int)coinX, (int)coinY, 30, 40);
            //if the square is colliding with the coin collect it and play the appropriate sound
            if (rectangleCollisionDetection(sq, coinRectangle) && !coinCollected)
            {
                coinCollected = true;
                if (Form1.isMuted)
                {
                    coinSound.Play();
                }
            }
            //check if the square is colliding with any of the obstacles or the end rectangle
            foreach (Ball ball in obstacles)
            {
                Rectangle obstacle = new Rectangle((int)(ball.X - ball.Radius - 1), (int)(ball.Y - ball.Radius - 1), (int)(2 * ball.Radius + 1), (int)(2 * ball.Radius + 1));
                if (rectangleCollisionDetection(obstacle, sq))
                {
                    coinCollected = false;
                    if (safePointReached)
                    {
                        square.Point = new Point(bounds.Right - 31, 49 + (bounds.Bottom - bounds.Top) / 2);
                    }
                    else
                    {
                        square.Point = new Point(52, 52);
                    }
                    Form1.deaths++;
                    if (!Form1.isMuted)
                    {
                        dieSound.Play();
                    }
                    break;
                }
                if (!safePointReached)
                {
                    if (rectangleCollisionDetection(sq, safePoint))
                    {
                        safePointReached = true;
                        break;
                    }
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

    }
}
