using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldsHardestGame
{
    public partial class GameScreen : UserControl
    {
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        List<Ball> enemies = new List<Ball>();

        Player hero;
        public static int width, height;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();        }

        public void InitializeGame()
        {
            width = this.Width;
            height = this.Height;
            hero = new Player(100, 100);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
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
            Refresh();

        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(redBrush, hero.x, hero.y, hero.width, hero.height);

            foreach (Ball enemy in enemies)
            {
                e.Graphics.FillEllipse(blueBrush, enemy.x, enemy.y, enemy.size, enemy.size);
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Player hero;
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
    }
}


