using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsHardestGame
{
    internal class Player
    {
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
                    y  = GameScreen.height - height;
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

                if (x + width > GameScreen.width)
                {
                    x = GameScreen.width - width;
                }
            }
        }
    }
}
