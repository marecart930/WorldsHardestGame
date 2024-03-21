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
    public partial class Form1 : Form
    {
        public static List<Image> fireBall = new List<Image>();
        public static List<Image> mario = new List<Image>();
        public static List<Image> star = new List<Image>();
        public static List<Image> boom = new List<Image>();
        SoundPlayer walk = new SoundPlayer(Properties.Resources.mr_krabs_walking__1_);


        public static int width, height;
        public Form1()
        {
            InitializeComponent();
            #region sprites
            fireBall.Add(Properties.Resources.Fire1);
            fireBall.Add(Properties.Resources.Fire1);
            fireBall.Add(Properties.Resources.Fire1);
            fireBall.Add(Properties.Resources.Fire1);
            fireBall.Add(Properties.Resources.Fire1);

            fireBall.Add(Properties.Resources.Fire2);
            fireBall.Add(Properties.Resources.Fire2);
            fireBall.Add(Properties.Resources.Fire2);
            fireBall.Add(Properties.Resources.Fire2);
            fireBall.Add(Properties.Resources.Fire2);

            fireBall.Add(Properties.Resources.Fire3);
            fireBall.Add(Properties.Resources.Fire3);
            fireBall.Add(Properties.Resources.Fire3);
            fireBall.Add(Properties.Resources.Fire3);
            fireBall.Add(Properties.Resources.Fire3);

            fireBall.Add(Properties.Resources.FIre4);
            fireBall.Add(Properties.Resources.FIre4);
            fireBall.Add(Properties.Resources.FIre4);
            fireBall.Add(Properties.Resources.FIre4);
            fireBall.Add(Properties.Resources.FIre4);

            mario.Add(Properties.Resources.mario1);
            mario.Add(Properties.Resources.mario1);
            mario.Add(Properties.Resources.mario1);
            mario.Add(Properties.Resources.mario1);

            mario.Add(Properties.Resources.mario2);
            mario.Add(Properties.Resources.mario2);
            mario.Add(Properties.Resources.mario2);
            mario.Add(Properties.Resources.mario2);

            star.Add(Properties.Resources.star1);
            star.Add(Properties.Resources.star1);
            star.Add(Properties.Resources.star1);
            star.Add(Properties.Resources.star1);

            star.Add(Properties.Resources.star2);
            star.Add(Properties.Resources.star2);
            star.Add(Properties.Resources.star2);
            star.Add(Properties.Resources.star2);

            star.Add(Properties.Resources.star3);
            star.Add(Properties.Resources.star3);
            star.Add(Properties.Resources.star3);
            star.Add(Properties.Resources.star3);

            star.Add(Properties.Resources.star4);
            star.Add(Properties.Resources.star4);
            star.Add(Properties.Resources.star4);
            star.Add(Properties.Resources.star4);

            boom.Add(Properties.Resources.boom1);
            boom.Add(Properties.Resources.boom2);
            boom.Add(Properties.Resources.boom3);
            boom.Add(Properties.Resources.boom4);
            boom.Add(Properties.Resources.boom5);
            boom.Add(Properties.Resources.boom6);
            boom.Add(Properties.Resources.boom7);
            boom.Add(Properties.Resources.boom8);
            boom.Add(Properties.Resources.boom9);
            boom.Add(Properties.Resources.boom10);
            boom.Add(Properties.Resources.boom11);
            boom.Add(Properties.Resources.boom12);
            boom.Add(Properties.Resources.boom13);
            boom.Add(Properties.Resources.boom14);





            #endregion

            ChangeScreen(this, new MenuScreen()); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;                          //f is sender
            }
            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender
                f = current.FindForm();                     //find Form UserControl is on
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }
    }
}
