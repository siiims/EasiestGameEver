using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace EasiestGame
{
    public class Level1 : Level
    {

        public Level1()
        {
            start = new Rectangle(50, 50, 50, 50);
            end = new Rectangle(bounds.Left, bounds.Bottom - 50, 50, 50);

            coinX = bounds.Right - 40;
            coinY = 45 + (bounds.Bottom - bounds.Top) / 2;

            obstacles = new List<Ball>();
            int position = 130; //position of the obstacles - x coordinate
            for (int i = 0; i < 6; i++)
            {
                UpDownBall udb = new UpDownBall(new Point(position, bounds.Bottom - 15), 15, bounds);
                obstacles.Add(udb);

                position += 85;
            }
        }
    }
}
