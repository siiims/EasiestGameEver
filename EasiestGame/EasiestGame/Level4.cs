using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class Level4 : Level
    {

        public Level4()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Right - 50, bounds.Bottom - 50, 50, 50);

            coinX = (bounds.Right - bounds.Left) / 2 + 55;
            coinY = (bounds.Bottom - bounds.Top) / 2 + 150;

            obstacles = new List<Ball>();
            int circlingRadius = 0;
            double speed = 0.01;
            float cX = (bounds.Right - bounds.Left) / 2 + 52;
            float cY = (bounds.Bottom - bounds.Top) / 2 + 52;

            for (int i = 0; i < 5; i++)
            {
                CirclingBall cb1 = new CirclingBall(new Point(), 15, bounds, circlingRadius, cX, cY, 0, speed);
                CirclingBall cb2 = new CirclingBall(new Point(), 15, bounds, -circlingRadius, cX, cY, 0, speed);
                CirclingBall cb3 = new CirclingBall(new Point(), 15, bounds, circlingRadius, cX, cY, Math.PI / 2, speed);
                CirclingBall cb4 = new CirclingBall(new Point(), 15, bounds, -circlingRadius, cX, cY, Math.PI / 2, speed);
                obstacles.Add(cb1);
                obstacles.Add(cb2);
                obstacles.Add(cb3);
                obstacles.Add(cb4);

                circlingRadius += 50;
            }
            int position = 120; //position of the obstacles - x coordinate
            for (int i = 0; i < 4; i++)
            {
                LeftRightBall lrb = new LeftRightBall(new Point(bounds.Left + 15, position), 15, bounds);
                obstacles.Add(lrb);
                position += 70;
            }
        }
    }
}
