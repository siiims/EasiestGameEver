using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class Level2 : Level
    {

        public Level2()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Right - 50, bounds.Bottom - 50, 50, 50);

            coinX = (bounds.Right - bounds.Left) / 2 + 55;
            coinY = (bounds.Bottom - bounds.Top) / 2 + 85;

            obstacles = new List<Ball>();
            int position = 130; //position of the obstacles - x coordinate
            for (int i = 0; i < 10; i++)
            {
                UpDownBall udb;
                if (i % 2 == 1)
                {
                    udb = new UpDownBall(new Point(position, bounds.Bottom - 15), 15, bounds);
                }
                else
                {
                    udb = new UpDownBall(new Point(position, bounds.Top + 15), 15, bounds);
                }
                obstacles.Add(udb);

                position += 45;
            }
        }
    }
}
