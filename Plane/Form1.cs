using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Plane
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        WindowsMediaPlayer wplayer2 = new WindowsMediaPlayer();

        //read scores from a file
        StreamReader f2;

        //write scores to a file
        StreamWriter f;
        

        PictureBox heart = new PictureBox();
        bool heartOn = false;

        bool level1 = true;
        int level2 = 0;

        int second = 0;

        int speed=20;
        int health = 100;
        int enemyHealth = 100;
        int score = 0;

        bool gameOver = false;

        int enemyNumber = 0;
        //List<PictureBox> enemyList = new List<PictureBox>();
        
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            wplayer.URL = @"Ignite.mp3";
            wplayer.settings.volume = 20;
            wplayer.controls.play();

            //wplayer2.URL = @"bullet.wav";
            player.BringToFront();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            if (e.KeyCode==Keys.Left&& player.Left>0)
            {
                player.Left -= speed;
            }

            if (e.KeyCode == Keys.Right&& player.Left <(this.ClientSize.Width-player.Width))
            {
                player.Left += speed;
            }

            if (e.KeyCode==Keys.Up&&player.Top>0)
            {
                player.Top -= speed;
            }

            if (e.KeyCode == Keys.Down&&player.Top<(this.ClientSize.Height-player.Height))
            {
                player.Top += speed;
                
            }

            if (e.KeyCode == Keys.Space)
            {
                wplayer2.URL = @"bullet.wav";
                wplayer2.controls.stop();
                shootBullet();
                wplayer2.controls.play();
            }

        }

        private void shootBullet()
        {
            Bullet shoot = new Bullet();
            shoot.left = player.Left + (player.Width/2);
            shoot.top = player.Top + (player.Height/2);
            shoot.createBullet(this);
        }


        private void makeEnemy()
        {
            Enemy enemy = new Enemy();
            enemy.left = rand.Next(0,780);
            enemy.top = rand.Next(-60,0);
            enemy.makeEnemy(this);
            //enemyList.Add(enemy.enemy);
            
        }

        private void secondEnemy()
        {
            Enemy enemy = new Enemy();
            enemy.left = rand.Next(0, 780);
            enemy.top = 40;
            enemy.secondEnemy(this);
        }

        private void makeHeart()
        {
            heart.Image = Properties.Resources.heart;
            heart.Tag = "heart";
            heart.Size = new Size(30,30);
            //heart.Left = rand.Next(0,700);
            heart.SizeMode = PictureBoxSizeMode.StretchImage;
            heart.BringToFront();
            this.Controls.Add(heart);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (health>0)
            {
                healthBar.Value = health;
            }
            else
            {
                result.Text = "You lost\r\n";
                endGame();
                hideEnemy();
            }

            //when you win the game
            enemyBar.Value = enemyHealth;
            if (enemyHealth<1)
            {
                result.Text = "You Win\r\n";
                endGame();
            }


            second += 1;
            if (second>=500&&enemyShoot.Enabled==false)
            {
                enemyShoot.Start();
            }

            if (second >= 1000  )
            {
                level1 = false;
                
            }

            if (enemyNumber<=5 && level1) {
                makeEnemy();
                enemyNumber++;
            }

            //to show the second enemy
            if (!level1 && level2 == 0)
            {
                hideEnemy();
                enemyBar.Visible = true;
                secondEnemy();
                level2 = 1;
            }

            if (heartOn)
            {
                if (player.Bounds.IntersectsWith(heart.Bounds))
                {
                    //this.Controls.Remove(heart);
                    heart.Dispose();
                    health += 20;
                    heartOn = false;
                    heart = new PictureBox();
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag=="enemy")
                {
                    if (((PictureBox)x).Top>this.ClientSize.Height)
                    {
                        enemyNumber--;
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();

                        //enemyList.Remove(((PictureBox)x));
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        health -= 25;
                        enemyNumber--;
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                    }

                    if (health <= 1)
                    {
                        
                    }
                }


                //when Enemy Bullet crash the player
                if (x is PictureBox && (string)x.Tag == "enemyBullet")
                {
                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        health -= 5;
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                    }
                }


                //when secondEnemyBullet crash the player
                if (x is PictureBox && (string)x.Tag == "secondEnemyBullet")
                {
                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        health -= 15;
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "enemy")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            ++score;
                            labelScore.Text = score+"";

                            if (enemyNumber > 0)
                            {
                                enemyNumber--;
                            }


                            //show the heart when your about to die
                            if (health<=20 && !heartOn)
                            {
                                makeHeart();
                                //heart.Left = ((PictureBox)x).Left;
                                //heart.Top = ((PictureBox)x).Top;
                                heart.Left = rand.Next(0,800);
                                heart.Top = rand.Next(500, 600);
                                heartOn = true;
                            }

                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            //enemyList.Remove(((PictureBox)x));

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                        }
                         
                    }

                    //when bullet crash the second enemy
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "secondEnemy")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            ++score;
                            labelScore.Text = score + "";
                            enemyHealth -= 10;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                        }
                    }
                }
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        // enemy timer
        private void enemyTimerEvent(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag=="enemy")
                {
                    ((PictureBox)x).Top += 1;

                    

                    // to move into the player
                    if (((PictureBox)x).Left<player.Left)
                    {
                        ((PictureBox)x).Left += 1;
                    }

                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= 1;
                    }
                }


                if (x is PictureBox && (string)x.Tag == "secondEnemy")
                {
                    // to move into the player
                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += 3;
                    }

                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= 3;
                    }
                }
            }
        }



        private Point MouseDownLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void hideEnemy()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {

                    this.Controls.Remove(x);
                    ((PictureBox)x).Dispose();
                }

                if (x is PictureBox && (string)x.Tag == "secondEnemy")
                {

                    this.Controls.Remove(x);
                    ((PictureBox)x).Dispose();
                }
            }
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = Color.Transparent;
        }

        private void restart(object sender, EventArgs e)
        {
            if (gameOver)
            {
                timer1.Start();
                enemyTimer.Start();
                wplayer.controls.play();
                this.Controls.Clear();
                this.InitializeComponent();
                second = 0;
                level1 = true;
                level2 = 0;
                result.Text = null;
                result.Visible = false;
                heartOn = false;
                speed = 20;
                health = 100;
                enemyHealth = 100;
                gameOver = false;
                enemyNumber = 0;
                score = 0;
                over.Visible = false;
                player.Left = this.ClientSize.Width / 2 - player.Width / 2;
                player.Top = this.ClientSize.Height - player.Height;

                /////////////
                over.Visible = false;
                close.Visible = false;
                //f2 = File.OpenText(@"score.txt");
            }
        }
        
        private void endGame()
        {
            hideEnemy();

            player.Left = this.ClientSize.Width / 2 - player.Width / 2;
            player.Top = this.ClientSize.Height - player.Height;

            enemyShoot.Stop();
            enemyShoot.Dispose();
            over.Visible = true;
            close.Visible = true;
            healthBar.Value = 0;
            gameOver = true;
            timer1.Stop();
            enemyTimer.Stop();
            wplayer.controls.stop();
            second = 0;
            f2 = File.OpenText(@"score.txt");
            if (score>Convert.ToInt32(f2.ReadLine()))
            {
                f2.Close();
                f = File.CreateText("score.txt");
                f.WriteLine(labelScore.Text);
                f.Close();
            }

            f2 = File.OpenText(@"score.txt");
            result.Visible = true;
            result.Text += "Your Score: " + score;
            result.Text += "\r\nBest Score: " + f2.ReadLine();
            f2.Close();

        }
        private void exit_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        //enemy bullets 
        private void shootEnemy(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    ((PictureBox)x).Top += 1;


                    Bullet shoot = new Bullet();
                    shoot.left = ((PictureBox)x).Left;
                    shoot.top = ((PictureBox)x).Top;
                    shoot.enemyBullet(this);
                }

                if (x is PictureBox && (string)x.Tag == "secondEnemy")
                {
                    Bullet shoot = new Bullet();
                    shoot.left = ((PictureBox)x).Left+ ((PictureBox)x).Width/2;
                    shoot.top = ((PictureBox)x).Top+ ((PictureBox)x).Height;
                    shoot.secondEnemyBullet(this);
                }


            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            enemyTimer.Stop();
            enemyShoot.Stop();
            if (MessageBox.Show("Do you want to exit game","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
            {
                e.Cancel = true;
                timer1.Start();
                enemyTimer.Start();
                enemyShoot.Start();
            }
            else
            {
                Application.Exit();
                endGame();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
