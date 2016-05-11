using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class UpDownBall : Ball
    {
        // keep track of the ball's direction
        private bool isDirectionDown;


        public UpDownBall(Point center, float radius, Rectangle rec) : base(center, radius, rec)
        {
            isDirectionDown = true;
        }

        public override void Move(bool isPaused)
        {
            if (!isPaused)
            {
                if (isDirectionDown)
                {
                    if (Y + Radius + SPEED > bounds.Bottom)
                    {
                        isDirectionDown = false;
                    }
                    else
                    {
                        Y += SPEED;
                    }
                }
                else
                {
                    if (Y - Radius - SPEED < bounds.Top)
                    {
                        isDirectionDown = true;
                    }
                    else
                    {
                        Y -= SPEED;
                    }
                }
            }
        }
    }
}
