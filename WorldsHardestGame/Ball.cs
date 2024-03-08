using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsHardestGame
{
    internal class Ball
    {
        public int size, x, y, xSpeed, ySpeed;

        public Ball(int x)
        {
            this.y = y;
            this.ySpeed = ySpeed;

            size = 10;
        }
            public void Move()
            {
                y += ySpeed;

                if (y < 0 || y > GameScreen.height - size)
                {
                    ySpeed *= -1;
                }
            }
    }
}
