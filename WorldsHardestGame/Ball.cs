using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsHardestGame
{
    internal class Ball
    {
        //angle variable
        public int size, x, y, xSpeed, ySpeed;

        public Ball(int x, int y, int xSpeed, int ySpeed)
        {
            this.x = x;
            this.y = y;
            //this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;

            size = 20;
        }

        public void Move()
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
        }
    }
}
