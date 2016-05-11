using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    class Level3 : Level
    {

        public Level3()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Right - 50, bounds.Bottom - 50, 50, 50);

            coinX = 55;
            coinY = bounds.Bottom - 40;

            obstacles = new List<Ball>();
            Random randomness = new Random();
            for (int i = 0; i < 5; i++)
            {
                Point center = new Point(52 + (bounds.Right - bounds.Left) / 2, 52 + (bounds.Bottom - bounds.Top) / 2);
                float velocity = 5;

                RandomBall randomBall = new RandomBall(center, 15, bounds, velocity, (float)(randomness.NextDouble() * (3 * Math.PI)));
                obstacles.Add(randomBall);
            }
        }
    }
}
