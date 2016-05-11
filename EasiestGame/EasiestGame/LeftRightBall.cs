using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{

    public class LeftRightBall : Ball
    {
        //keep track of the ball's direction
        private bool isDirectionRight;


        public LeftRightBall(Point center, float radius, Rectangle rec) : base(center, radius, rec)
        {
            isDirectionRight = true;
        }

        public override void Move(bool isPaused)
        {
            if (!isPaused)
            {
                if (isDirectionRight)
                {
                    if (X + Radius + SPEED > bounds.Right)
                    {
                        isDirectionRight = false;
                    }
                    else
                    {
                        X += SPEED;
                    }
                }
                else
                {
                    if (X - Radius - SPEED < bounds.Top)
                    {
                        isDirectionRight = true;
                    }
                    else
                    {
                        X -= SPEED;
                    }
                }
            }
        }
    }
}
