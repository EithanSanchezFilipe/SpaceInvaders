using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ZombieApocalypse
{
    internal class Zombie
    {
        public int _x = 0;
        public int _y = 0;
        public PictureBox PictureBox;

        public Zombie(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public void PlayerMove()
        {
        }
        public void LoadImage()
        {

        }
        private void InitialiserPictureBox()
        {
            PictureBox = new PictureBox
            {
                Size = new Size(100, 100),
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox.Image = Properties.Resources.zombie;
        }
    }
}
