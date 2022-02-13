using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdProject1
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
 
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {

            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text =($"You reached {score} this game");

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 450;
                score++;
            }
            if ( pipeTop.Left < -180)
            {
                pipeTop.Left = 500;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -80
                )
            {
                endGame();
            }
            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!! ";

        }
    }
}
