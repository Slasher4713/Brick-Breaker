using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Brick_Breaker
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(275, 300, 30, 5);
        Rectangle ball = new Rectangle(285, 250, 8, 8);
        Rectangle yellow = new Rectangle(100, 50, 30, 20);
        Rectangle blue = new Rectangle(100, 100, 30, 20);
        Rectangle gray = new Rectangle(100, 150, 30, 20);


        List<Rectangle> yellowBlock = new List<Rectangle>();
        List<Rectangle> blueBlock = new List<Rectangle>();
        List<Rectangle> grayBlock = new List<Rectangle>();

        int blockSizeX = 30;
        int blockSizeY = 20;

        int ballSpeedX = 5;
        int ballSpeedY = 5;
        int lvl = 1;

        int blocksX = 100;
        int line1Y = 50;
        int line2Y = 100;
        int line3Y = 150;
        int line4Y = 200;
        int changerX;
        int score = 0;
        int life = 3;

        bool left = false;
        bool right = false;
        bool up = false;   
        bool down = false;


        int heroSpeed = 8;
        bool leftPressed = false;
        bool rightPressed = false;

        Random randGen = new Random();


        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);

        SoundPlayer hit = new SoundPlayer(Properties.Resources.hit);
        SoundPlayer loseLife = new SoundPlayer(Properties.Resources.life);
        SoundPlayer level = new SoundPlayer(Properties.Resources.level);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.lose);
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle upBox = new Rectangle(ball.X + 1, ball.Y - 1, 3, 2);
            Rectangle downBox = new Rectangle(ball.X + 1, ball.Y + ball.Height - 1, 3, 2);
            Rectangle leftBox = new Rectangle(ball.X - 3, ball.Y + 1, 2, 3);
            Rectangle rightBox = new Rectangle(ball.X - 1 + ball.Width, ball.Y + 1, 2, 3);
            if (leftPressed && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }

            if (rightPressed && hero.X < this.Width - hero.Width - 20)
            {
                hero.X += heroSpeed;
            }

            if (ball.X < 0)
            {
                ballSpeedX = ballSpeedX * -1;
            }

            if (ball.X > this.Width - ball.Width - 20)
            {
                ballSpeedX = ballSpeedX * -1;
            }

            if (ball.Y < 0)
            {
                ballSpeedY = ballSpeedY * -1;
            }

            if (ball.Y > this.Height - ball.Height - 20)
            {
                loseLife.Play();
                life--;
                ball.Y = 250;
                ball.X = 285;
                ballSpeedX = -5;
                ballSpeedY = 5;
            }
            if (ball.IntersectsWith(hero))
            {
                hit.Play();
                ball.Y = ball.Y - ball.Height;
                ballSpeedY = ballSpeedY * -1;
                if ((leftPressed && ballSpeedX < 0) || (rightPressed && ballSpeedX > 0))
                {
                    ballSpeedX = ballSpeedX * -1;
                    ball.X = ball.X + 10;
                }
            }

            for (int i = 0; i < blueBlock.Count; i++)
            {
                
                if (leftBox.IntersectsWith(blueBlock[i]) && right == false && up == false && down == false)
                {
                    left = true;
                }
                if (rightBox.IntersectsWith(blueBlock[i]) && left == false && up == false && down == false)
                {
                    right = true;
                }
                if (upBox.IntersectsWith(blueBlock[i]) && right == false && left == false && down == false)
                {
                    up = true;
                }
                if (downBox.IntersectsWith(blueBlock[i]) && right == false && up == false && left == false)
                {
                    down = true;
                }
                if (ball.IntersectsWith(blueBlock[i]))
                {
                    hit.Play();
                    if (left == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        left = false;
                        ball.X = ball.X + 5;
                    }
                    else if (right == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        right = false;
                        ball.X = ball.X - 5;
                    }
                    else if (up == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        up = false;
                        ball.Y = ball.Y + 5;
                    }
                    else if (down == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        down = false;
                        ball.Y = ball.Y - 5;
                    }
                    blueBlock.RemoveAt(i);
                    score = score + 100;
                    if (ballSpeedY < 0)
                    {
                        ball.Y = ball.Y + ball.Height;
                    }
                    else
                    {
                        ball.Y = ball.Y - ball.Height;
                    }
                }
            }

            for (int i = 0; i < yellowBlock.Count; i++)
            {
                if (leftBox.IntersectsWith(yellowBlock[i]) && right == false && up == false && down == false)
                {
                    left = true;
                }
                if (rightBox.IntersectsWith(yellowBlock[i]) && left == false && up == false && down == false)
                {
                    right = true;
                }
                if (upBox.IntersectsWith(yellowBlock[i]) && right == false && left == false && down == false)
                {
                    up = true;
                }
                if (downBox.IntersectsWith(yellowBlock[i]) && right == false && up == false && left == false)
                {
                    down = true;
                }
                    if (ball.IntersectsWith(yellowBlock[i]))
                {
                    hit.Play();
                    if (left == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        left = false;
                        ball.X = ball.X + 5;
                    }
                    else if (right == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        right = false;
                        ball.X = ball.X - 5;
                    }
                    else if (up == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        up = false;
                        ball.Y = ball.Y + 5;
                    }
                    else if (down == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        down = false;
                        ball.Y = ball.Y - 5;
                    }
                    yellowBlock.RemoveAt(i);
                    score = score + 100;
                    if (ballSpeedY < 0)
                    {
                        ball.Y = ball.Y + ball.Height;
                    }
                    else
                    {
                        ball.Y = ball.Y - ball.Height;
                    }
                }
            }

            for (int i = 0; i < grayBlock.Count; i++)
            {
                if (leftBox.IntersectsWith(grayBlock[i]) && right == false && up == false && down == false)
                {
                    left = true;
                }
                if (rightBox.IntersectsWith(grayBlock[i]) && left == false && up == false && down == false)
                {
                    right = true;
                }
                if (upBox.IntersectsWith(grayBlock[i]) && right == false && left == false && down == false)
                {
                    up = true;
                }
                if (downBox.IntersectsWith(grayBlock[i]) && right == false && up == false && left == false)
                {
                    down = true;
                }
                if (ball.IntersectsWith(grayBlock[i]))
                {
                    hit.Play();
                    if (left == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        left = false;
                        ball.X = ball.X + 5;
                    }
                    else if (right == true)
                    {
                        ballSpeedX = ballSpeedX * -1;
                        right = false;
                        ball.X = ball.X - 5;
                    }
                    else if (up == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        up = false;
                        ball.Y = ball.Y + 5;
                    }
                    else if (down == true)
                    {
                        ballSpeedY = ballSpeedY * -1;
                        down = false;
                        ball.Y = ball.Y - 5;
                    }
                }
            }

            scoreOutput.Text = $"Score: {score}     Level: {lvl}    Lives: {life}";

            ball.X -= ballSpeedX;
            ball.Y -= ballSpeedY;

            if (life == 0)
            {
                lose.Play();
                gameTimer.Stop();
            }

            if (yellowBlock.Count == 0 && blueBlock.Count == 0 && lvl == 1)
            {
                level.Play();
                lvl++;
                changerX = 0;
                for (int i = 0; i < 8; i++)
                {
                    Rectangle yellow = new Rectangle(blocksX + changerX, line1Y, blockSizeX, blockSizeY);
                    yellowBlock.Add(yellow);
                    Rectangle blue = new Rectangle(blocksX + changerX, line2Y, blockSizeX, blockSizeY);
                    blueBlock.Add(blue);
                    Rectangle gray = new Rectangle(blocksX + changerX, line3Y, blockSizeX, blockSizeY);
                    grayBlock.Add(gray);
                    changerX = changerX + 50;
                }
            }

            if (yellowBlock.Count == 0 && blueBlock.Count == 0 && lvl >= 2)
            {
                level.Play();
                grayBlock.Clear();
                lvl++;
                changerX = 0;
                for (int i = 0; i < 8; i++)
                {
                    int h = randGen.Next(0, 100);
                    if (h <= 33)
                    {
                        Rectangle yellow = new Rectangle(blocksX + changerX, line1Y, blockSizeX, blockSizeY);
                        yellowBlock.Add(yellow);
                    }
                    else if (h <= 66)
                    {
                        Rectangle blue = new Rectangle(blocksX + changerX, line1Y, blockSizeX, blockSizeY);
                        blueBlock.Add(blue);
                    }
                    else
                    {
                        Rectangle gray = new Rectangle(blocksX + changerX, line1Y, blockSizeX, blockSizeY);
                        grayBlock.Add(gray);
                    }
                    changerX = changerX + 50;

                }
                changerX = 0;
                for (int i = 0; i < 8; i++)
                {
                    int h = randGen.Next(0, 100);
                    if (h <= 33)
                    {
                        Rectangle yellow = new Rectangle(blocksX + changerX, line2Y, blockSizeX, blockSizeY);
                        yellowBlock.Add(yellow);
                    }
                    else if (h <= 66)
                    {
                        Rectangle blue = new Rectangle(blocksX + changerX, line2Y, blockSizeX, blockSizeY);
                        blueBlock.Add(blue);
                    }
                    else
                    {
                        Rectangle gray = new Rectangle(blocksX + changerX, line2Y, blockSizeX, blockSizeY);
                        grayBlock.Add(gray);
                    }
                    changerX = changerX + 50;
                }
                changerX = 0;
                for (int i = 0; i < 8; i++)
                {
                    int h = randGen.Next(0, 100);
                    if (h <= 33)
                    {
                        Rectangle yellow = new Rectangle(blocksX + changerX, line3Y, blockSizeX, blockSizeY);
                        yellowBlock.Add(yellow);
                    }
                    else if (h <= 66)
                    {
                        Rectangle blue = new Rectangle(blocksX + changerX, line3Y, blockSizeX, blockSizeY);
                        blueBlock.Add(blue);
                    }
                    else
                    {
                        Rectangle gray = new Rectangle(blocksX + changerX, line3Y, blockSizeX, blockSizeY);
                        grayBlock.Add(gray);
                    }
                    changerX = changerX + 50;
                }
                changerX = 0;
                for (int i= 0; i < 8; i++)
                {
                    Rectangle gray = new Rectangle(blocksX + changerX, line4Y, blockSizeX, blockSizeY);
                    grayBlock.Add(gray);
                    changerX = changerX + 50;
                }
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, hero);
            e.Graphics.FillEllipse(whiteBrush, ball);
            if (lvl == 1)
            {
                for (int i = 0; i < yellowBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, yellowBlock[i]);
                }
                for (int i = 0; i < blueBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(blueBrush, blueBlock[i]);
                }
            }
            if (lvl == 2)
            {
                for (int i = 0; i < yellowBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, yellowBlock[i]);
                }
                for (int i = 0; i < blueBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(blueBrush, blueBlock[i]);
                }
                for (int i = 0; i < grayBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(grayBrush, grayBlock[i]);
                }
            }
            if (lvl >= 3)
            {
                for (int i = 0; i < yellowBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, yellowBlock[i]);
                }
                for (int i = 0; i < blueBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(blueBrush, blueBlock[i]);
                }
                for (int i = 0; i < grayBlock.Count; i++)
                {
                    e.Graphics.FillRectangle(grayBrush, grayBlock[i]);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            changerX = 0;
            for (int i = 0; i < 8; i++)
            {
                Rectangle yellow = new Rectangle(blocksX + changerX, line1Y, blockSizeX, blockSizeY);
                yellowBlock.Add(yellow);
                Rectangle blue = new Rectangle(blocksX + changerX, line2Y, blockSizeX, blockSizeY);
                blueBlock.Add(blue);
                changerX = changerX + 50;
            }
        }
    }
}
