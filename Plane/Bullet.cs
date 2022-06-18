using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plane
{
    class Bullet
    {
        public int left;
        public int top;

        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        public Timer bulletTimer = new Timer();
        public Timer enemyBulletTimer = new Timer();

        public void createBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5,5);
            bullet.Tag = "bullet";
            bullet.Left = left;
            bullet.Top = top;
            bullet.BringToFront();
            
            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(bulletEvent);
            bulletTimer.Start();
        }

        private void bulletEvent(object sender,EventArgs e)
        {
            bullet.Top -= speed;

            if (bullet.Top<0)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bullet = null;
                bulletTimer = null;
            }
        }

        public void enemyBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(3, 3);
            bullet.Tag = "enemyBullet";
            bullet.Left = left;
            bullet.Top = top;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            enemyBulletTimer.Interval = speed;
            enemyBulletTimer.Tick += new EventHandler(enemyBulletEvent);
            enemyBulletTimer.Start();
        }

        private void enemyBulletEvent(object sender, EventArgs e)
        {
            bullet.Top += speed;

            if (bullet.Top > 600)
            {
                enemyBulletTimer.Stop();
                enemyBulletTimer.Dispose();
                bullet.Dispose();
                bullet = null;
                bulletTimer = null;
            }
        }


        public void secondEnemyBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "secondEnemyBullet";
            bullet.Left = left;
            bullet.Top = top;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            enemyBulletTimer.Interval = speed;
            enemyBulletTimer.Tick += new EventHandler(secondEnemyBulletEvent);
            enemyBulletTimer.Start();
        }

        private void secondEnemyBulletEvent(object sender, EventArgs e)
        {
            bullet.Top += 30;

            if (bullet.Top > 600)
            {
                enemyBulletTimer.Stop();
                enemyBulletTimer.Dispose();
                bullet.Dispose();
                bullet = null;
                bulletTimer = null;
            }
        }


    }
}
