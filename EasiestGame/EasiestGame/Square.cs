using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasiestGame
{
    public enum Movement
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public class Square
    {
        //leftmost point of the square
        public Point Point { get; set; }
        //the size of the side of the square
        public float side { get; set; }

        //the bounds of the square
        public Rectangle Bounds { get; set; }

        Pen pen;
        SolidBrush sb;

        //size of units square will move after arrow is pressed on keyboard
        private static readonly int STEP = 5;


        public Square()
        {
            Point = new Point(52, 52);
            side = 25;

            Bounds = new Rectangle();

            pen = new Pen(Color.Black, 4);
            sb = new SolidBrush(Color.Red);
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(pen, Point.X, Point.Y, side, side);
            g.FillRectangle(sb, Point.X, Point.Y, side, side);
        }

        public void Move(Movement move, bool shouldMove)
        {
            if (shouldMove)
            {
                Point nextPoint;
                if (move == Movement.Right)
                {
                    nextPoint = new Point(Point.X + STEP, Point.Y);
                }
                else if (move == Movement.Left)
                {
                    nextPoint = new Point(Point.X - STEP, Point.Y);
                }
                else if (move == Movement.Up)
                {
                    nextPoint = new Point(Point.X, Point.Y - STEP);
                }
                else
                {
                    nextPoint = new Point(Point.X, Point.Y + STEP);
                }
                //check if nextPoint is still in the Bounds, if yes do the movement
                if (!(nextPoint.X < Bounds.Left || (nextPoint.X + side >= Bounds.Right) || (nextPoint.Y <= Bounds.Top) || nextPoint.Y + side > Bounds.Bottom))
                {
                    Point = new Point(nextPoint.X, nextPoint.Y);
                }
            }
        }

        ~Square()
        {
            pen.Dispose();
            sb.Dispose();
        }
    }
}
