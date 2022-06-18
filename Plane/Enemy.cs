using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plane
{
    class Enemy
    {
        public int left, top;
        public int health=5;
        
        private int speed = 1;
        public PictureBox enemy = new PictureBox();
        public Timer enemyTimer = new Timer();
        

        public void makeEnemy(Form form)
        {
            
            enemy.Image = Properties.Resources.enemy;
            enemy.Tag = "enemy";
            enemy.Left = left;
            enemy.Top = top;
            enemy.Size = new Size(40, 43);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy.BringToFront();

            form.Controls.Add(enemy);

        }

        public void secondEnemy(Form form)
        {
            enemy.Image = Properties.Resources.enemy;
            enemy.Tag = "secondEnemy";
            enemy.Left = left;
            enemy.Top = top;
            enemy.Size = new Size(80, 83);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy.BringToFront();

            form.Controls.Add(enemy);
        }
        
    }
}
