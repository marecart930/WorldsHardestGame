using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;

namespace WorldsHardestGame
{
    internal class star
    {
        public int spriteNumber = 0;
        public Image currentSprite = Properties.Resources.star1;
        public Image currentBoomSprite = Properties.Resources.boom1;

        //angle variable
        public int size, x, y, xSpeed, ySpeed;

        public star(int x, int y, int xSpeed, int ySpeed)
        {
            this.x = x;
            this.y = y;
            //this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.xSpeed = xSpeed;

            size = 20;
        }

        public void MoveStar()
        {
            x += xSpeed;
            y += ySpeed;

            if (x < 0 || x > GameScreen.width - size)
            {
                xSpeed *= -1;
            }

            if (y < 0 || y > GameScreen.height - size)
            {
                ySpeed *= -1;
            }
            currentSprite = Form1.star[spriteNumber];
            spriteNumber++;
            if (spriteNumber > 15)
            {
                spriteNumber = 0;
            }
        }
        public void BoomBoom()
        {
            currentSprite = Form1.boom[spriteNumber];
            spriteNumber++;

            if (spriteNumber > 13)
            {
                spriteNumber = 0;
            }
        }
    }
}
