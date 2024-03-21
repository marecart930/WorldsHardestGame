using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Media;
namespace WorldsHardestGame
{
    internal class Player
    {

        int spriteNumber = 0;
        public Image currentSprite = Properties.Resources.mario1;

        public int x, y;
        public int width = 20;
        public int height = 20;
        public int speed = 3;


        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= speed;

                if (y < 0)
                {
                    y = 0;
                }
            }
            else if (direction == "down")
            {
                y += speed;

                if (y + height > GameScreen.height)
                {
                    y = GameScreen.height - height;
                }
            }
            else if (direction == "left")
            {
                x -= speed;

                if (x < 0)
                {
                    x = 0;
                }
            }
            else
            {
                x += speed;
            }

            currentSprite = Form1.mario[spriteNumber];
            spriteNumber++;

            if (spriteNumber > 7)
            {
                spriteNumber = 0;
            }
        }

        public bool Collision(Ball ball)
        {
            Rectangle playerRec = new Rectangle(x, y, width, height);
            Rectangle ballRec = new Rectangle(ball.x, ball.y, ball.size, ball.size);


            if (playerRec.IntersectsWith(ballRec))
            {
                return true;
            }
            return false;
        }
        public bool Collision(star star)
        {
            Rectangle playerRec = new Rectangle(x, y, width, height);
            Rectangle starRec = new Rectangle(star.x, star.y, star.size, star.size);

            if (playerRec.IntersectsWith(starRec))
            {
                return true;
            }
            return false;
        }
    }
}
