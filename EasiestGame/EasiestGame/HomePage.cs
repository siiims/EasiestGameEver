using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasiestGame.Properties;
namespace EasiestGame
{
    public class HomePage : Level // a.k.a Level0
    {
        private Rectangle play;
        private Rectangle exit;

        private Font drawFontButtons;
        private Font drawHeadText;
        private Font drawFontText;
        private Font drawFontTitle;
        private Font drawHintText;

        private SolidBrush drawBrush;
        private SolidBrush redBrush;

        private readonly static string titleText = "EASIEST GAME EVER";
        private readonly static string playText = "PLAY";
        private readonly static string exitText = "EXIT";
        private readonly static string hintText = "Use your arrow keys to move to the desired location!";
        private readonly static string headText = "INSTRUCTIONS:";
        private readonly static string instText = "You are the red square. Avoid the blue circles and collect the coins. \nOnce you have collected all coins, move to the green beacon to complete the level.\nSome levels consist of more then one beacon; the intermediatery beacons act as check points.";
        private readonly static string optiText = "You can pause/unpause the game by pressing P and mute/unmute the sound by pressing M.";


        public HomePage()
        {
            start = new Rectangle(50, 50, 50, 50);
            play = new Rectangle(bounds.Left + 150, bounds.Bottom - 223, 100, 50);
            exit = new Rectangle(bounds.Left + 350, bounds.Bottom - 223, 100, 50);

            drawFontButtons = new Font("Castellar", 20);
            drawHeadText = new Font("Rockwell Condensed", 17, FontStyle.Underline);
            drawFontText = new Font("Rockwell Condensed", 14, FontStyle.Regular);
            drawFontTitle = new Font("Castellar", 36, FontStyle.Bold);
            drawHintText = new Font("Rockwell Condensed", 14, FontStyle.Bold);

            drawBrush = new SolidBrush(Color.Black);
            redBrush = new SolidBrush(Color.Red);
        }

        public override void Draw(Graphics canvas)
        {
            //draw all rectangles including the square
            canvas.FillRectangle(sBrush, start);
            canvas.FillRectangle(sBrush, play);
            canvas.FillRectangle(sBrush, exit);
            square.Draw(canvas);
            canvas.DrawRectangle(pen, bounds);

            //draw the title 
            canvas.DrawString(titleText, drawFontTitle, drawBrush, 80, 80);

            //draw buttons and text inside
            canvas.DrawString(playText, drawFontButtons, drawBrush, 205, 177);
            canvas.DrawString(exitText, drawFontButtons, drawBrush, 415, 177);
            canvas.DrawString(headText, drawHeadText, drawBrush, 70, 237);
            canvas.DrawString(instText, drawFontText, drawBrush, 55, 265);
            canvas.DrawString(optiText, drawFontText, drawBrush, 55, 330);
            canvas.DrawString(hintText, drawHintText, drawBrush, 55, 355);
        }

        public override void CollisionDetection()
        {
            Rectangle sq = new Rectangle(square.Point, new Size((int)square.side, (int)square.side));

            if (rectangleCollisionDetection(sq, play))
            {
                LevelPassed = true;
            }
            if (rectangleCollisionDetection(sq, exit))
            {
                Form1.endGame = true;
            }
        }

        //we don't have any obstacles at the home screen
        public override void MoveObstacles() { }

        //destroy everything after you finish
        ~HomePage()
        {
            drawFontButtons.Dispose();
            drawFontText.Dispose();
            drawFontTitle.Dispose();
            drawBrush.Dispose();
            redBrush.Dispose();
        }
    }
}