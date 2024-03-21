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

namespace WorldsHardestGame
{
    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        bool hitStar = false;

        List<Ball> enemies = new List<Ball>();
        List<star> stars = new List<star>();


        Player hero;
        public static int width, height;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            width = this.Width;
            height = this.Height;
            hero = new Player(10, this.Height / 2);
            CreateBall();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (hitStar == false)
            {
                //move the player
                if (upArrowDown)
                {
                    hero.Move("up");
                }

                if (downArrowDown)
                {
                    hero.Move("down");
                }

                if (rightArrowDown)
                {
                    hero.Move("right");
                }

                if (leftArrowDown)
                {
                    hero.Move("left");
                }

                //move all the enemy balls
                foreach (Ball enemy in enemies)
                {
                    enemy.Move();

                    if (hero.Collision(enemy))
                    {
                        Form1.ChangeScreen(this, new Died());
                        gameTimer.Stop();
                    }
                }

                foreach (star stars in stars)
                {
                    stars.MoveStar();

                    if (hero.Collision(stars))
                    {
                        hitStar = true;
                        stars.spriteNumber = 0;
                        //Form1.ChangeScreen(this, new Died());
                        //gameTimer.Stop();
                    }
                }

                if (hero.x + hero.width > GameScreen.width)
                {
                    gameTimer.Enabled = false;
                    Form1.ChangeScreen(this, new Win());
                }
            }
            else
            {
                foreach (star star in stars)
                {
                    star.BoomBoom();
                }
            }
            Refresh();
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(redBrush, hero.x, hero.y, hero.width, hero.height);
            e.Graphics.DrawImage(hero.currentSprite, hero.x, hero.y, hero.width + 20, hero.height + 20);
            foreach (Ball enemy in enemies)
            {
                e.Graphics.DrawImage(enemy.currentSprite, enemy.x, enemy.y, enemy.size + 25, enemy.size + 25);
            }

            foreach (star stars in stars)
            {
                e.Graphics.DrawImage(stars.currentSprite, stars.x, stars.y, stars.size + 25, stars.size + 25);
                if (hitStar == true)
                {
                    e.Graphics.DrawImage(stars.currentSprite, stars.x, stars.y, stars.size + 70, stars.size + 70);

                }
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void CreateBall()
        {
            int x, y, xSpeed, ySpeed;
            for (int i = 0; i < 7; i++)
            {
                x = randGen.Next(30, width - 20);
                y = randGen.Next(10, height - 20);
                xSpeed = randGen.Next(5, 10);
                ySpeed = randGen.Next(5, 10);

                Ball newBall = new Ball(x, y, xSpeed, ySpeed);
                enemies.Add(newBall);

            }


            x = randGen.Next(30, width - 20);
            y = randGen.Next(10, height - 20);
            xSpeed = randGen.Next(5, 10);
            ySpeed = randGen.Next(5, 10);

            star newStar = new star(x, y, xSpeed, ySpeed);

            stars.Add(newStar);


        }
    }
}


