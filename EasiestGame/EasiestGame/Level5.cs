using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    class Level5 : Level
    {

        public Level5()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Left, bounds.Bottom - 50, 50, 50);

            coinX = 45 + (bounds.Right - bounds.Left) - 30;
            coinY = 55;

            obstacles = new List<Ball>();
            for (int x = bounds.Left + 70; x < bounds.Right - 15; x += 30)
            {
                for (int y = bounds.Top + 20; y < bounds.Bottom - 35; y += 30)
                {
                    if (x + y < 650 || x + y > 720)
                    {
                        Ball staticBall = new Ball(new Point(x, y), 10, bounds);
                        obstacles.Add(staticBall);
                    }
                }
            }
            int position = 130; //position of the obstacles - x coordinate
            for (int i = 0; i < 3; i++)
            {
                UpDownBall udb = new UpDownBall(new Point(position, bounds.Bottom - 15), 20, bounds);
                obstacles.Add(udb);

                position += 85;
            }
        }
    }
}
