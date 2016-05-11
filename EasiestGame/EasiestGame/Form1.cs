using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasiestGame.Properties;

namespace EasiestGame
{
    public partial class Form1 : Form
    {
        List<Level> levels;

        int currentLevel;
        public static int deaths;

        Timer renderingTimer;
        Timer moveObstaclesTimer;

        public static bool isPaused { get; set; }
        public static bool isMuted { get; set; }
        public static bool endGame { get; set; }

        private static readonly int FPS = 30;


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //form specs
            Width = 720;
            Height = 480;
            Text = "Easiest Game Ever";
            BackgroundImage = Resources.lvls;
            BackgroundImageLayout = ImageLayout.Stretch;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;

            currentLevel = 0;
            deaths = 0;
            isPaused = false;
            isMuted = false;
            endGame = false;

            levels = new List<Level>();
            levels.Add(new HomePage());
            levels.Add(new Level1());
            levels.Add(new Level2());
            levels.Add(new Level3());
            levels.Add(new Level4());
            levels.Add(new Level5());
            levels.Add(new Level6());

            renderingTimer = new Timer();
            renderingTimer.Interval = 1000 / FPS;
            renderingTimer.Start();
            renderingTimer.Tick += RenderingTimer_Tick;

            moveObstaclesTimer = new Timer();
            moveObstaclesTimer.Interval = 15;
            moveObstaclesTimer.Start();
            moveObstaclesTimer.Tick += MoveObstaclesTimer_Tick;
        }

        private void MoveObstaclesTimer_Tick(object sender, EventArgs e)
        {
            if (!isGameOver())
            {
                levels[currentLevel].MoveObstacles();
                levels[currentLevel].CollisionDetection();
                if (levels[currentLevel].LevelPassed)
                {
                    currentLevel++;
                }
            }
        }

        private void RenderingTimer_Tick(object sender, EventArgs e)
        {
            if (!isGameOver())
            {
                levels[currentLevel].Move();
                Invalidate(true);
            }
            if (endGame)
            {
                this.Close();
            }
        }

        private bool isGameOver()
        {
            if (levels.Count <= currentLevel)
            {
                renderingTimer.Stop();
                renderingTimer.Dispose();
                moveObstaclesTimer.Stop();
                moveObstaclesTimer.Dispose();
                //all levels are passed
                MessageBox.Show("You have finished the game successfully.", "Game Over!");
                this.Close();
                return true;
            }
            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            levels[currentLevel].Draw(e.Graphics);
            lblDeaths.Text = string.Format("Deaths: {0}", deaths);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
            {
                isPaused = !isPaused;
            }
            if (e.KeyChar == 'm' || e.KeyChar == 'M')
            {
                if (isMuted)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
                isMuted = !isMuted;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "themeSong.mp3";
            axWindowsMediaPlayer1.settings.setMode("Loop", true);
        }
    }
}
