using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class CirclingBall : Ball
    {
        //coordinates of point around which the ball will rotate
        private float circlingX;
        private float circlingY;
        private int circlingRadius;

        private double angle;
        private double angleIncrement;


        public CirclingBall(Point center, float radius, Rectangle rec, int circlingRad, float cX, float cY, double ang, double angIncrement) : base(center, radius, rec)
        {
            X = center.X;
            Y = center.Y;
            Radius = radius;
            bounds = rec;
            color = Color.DarkBlue;
            circlingRadius = circlingRad;
            circlingX = cX;
            circlingY = cY;
            angle = ang;
            angleIncrement = angIncrement;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            g.FillEllipse(solidBrush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        //move the ball around Point(circlingX, circlingY)  from angle to angle + angleIncrement with radiusCircling
        public override void Move(bool isPaused)
        {
            if (!isPaused)
            {
                if (angle > 2 * Math.PI)
                {
                    angle = 0;
                }
                X = circlingRadius * (float)Math.Cos(angle) + circlingX;
                Y = circlingRadius * (float)Math.Sin(angle) + circlingY;
                angle += angleIncrement;
            }
        }
    }
}
