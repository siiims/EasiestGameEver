using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class RandomBall : Ball
    {
        private float Velocity;
        private float Angle;

        //these are used to convert the velocity to 2 different x and y velocities
        private float velocityX;
        private float velocityY;


        public RandomBall(Point center, float radius, Rectangle rec, float velocity, float angle) : base(center, radius, rec)
        {
            Velocity = velocity;
            Angle = angle;
            velocityX = (float)Math.Cos(Angle) * Velocity;
            velocityY = (float)Math.Sin(Angle) * Velocity;
        }

        public override void Move(bool isPaused)
        {
            //if the game is not paused try to move the ball, check if the move is valid and do it or multiple the velocity accordingly
            if (!isPaused)
            {
                float nextX = X + velocityX;
                float nextY = Y + velocityY;
                if ((nextX - Radius <= bounds.Left) || (nextX + Radius >= bounds.Right))
                {
                    velocityX = -velocityX;
                }
                if ((nextY - Radius <= bounds.Top) || (nextY + Radius >= bounds.Bottom))
                {
                    velocityY = -velocityY;
                }
                X += velocityX;
                Y += velocityY;
            }
        }
    }
}
