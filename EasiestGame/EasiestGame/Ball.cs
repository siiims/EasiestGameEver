using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public class Ball
    {
        //coordinates of the circle
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }

        public Rectangle bounds;

        protected Color color;

        protected Pen pen;
        protected SolidBrush solidBrush;

        //the speed of the ball
        protected static readonly int SPEED = 5;


        public Ball(Point center, float radius, Rectangle rec)
        {
            X = center.X;
            Y = center.Y;
            Radius = radius;
            bounds = rec;
            color = Color.DarkBlue;

            pen = new Pen(Color.Black);
            solidBrush = new SolidBrush(color);
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            g.FillEllipse(solidBrush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        public virtual void Move(bool isPaused) { }

        ~Ball()
        {
            pen.Dispose();
            solidBrush.Dispose();
        }
    }
}
