namespace Plane
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.over = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.PictureBox();
            this.enemyBar = new System.Windows.Forms.ProgressBar();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.enemyShoot = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // enemyTimer
            // 
            this.enemyTimer.Enabled = true;
            this.enemyTimer.Interval = 1;
            this.enemyTimer.Tick += new System.EventHandler(this.enemyTimerEvent);
            // 
            // over
            // 
            this.over.BackColor = System.Drawing.Color.Fuchsia;
            this.over.Cursor = System.Windows.Forms.Cursors.Hand;
            this.over.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.over.ForeColor = System.Drawing.Color.Aqua;
            this.over.Location = new System.Drawing.Point(412, 307);
            this.over.Name = "over";
            this.over.Size = new System.Drawing.Size(120, 43);
            this.over.TabIndex = 4;
            this.over.Text = "Play Again";
            this.over.UseVisualStyleBackColor = false;
            this.over.Visible = false;
            this.over.Click += new System.EventHandler(this.restart);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelScore);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.enemyBar);
            this.panel1.Controls.Add(this.healthBar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 34);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Plane.Properties.Resources.coin;
            this.pictureBox1.Location = new System.Drawing.Point(165, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(196, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(18, 18);
            this.labelScore.TabIndex = 5;
            this.labelScore.Text = "0";
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Image = global::Plane.Properties.Resources.x;
            this.exit.Location = new System.Drawing.Point(769, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(39, 31);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exit.TabIndex = 4;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.exit_Click_1);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // enemyBar
            // 
            this.enemyBar.Location = new System.Drawing.Point(640, 12);
            this.enemyBar.Name = "enemyBar";
            this.enemyBar.Size = new System.Drawing.Size(110, 10);
            this.enemyBar.TabIndex = 1;
            this.enemyBar.Value = 100;
            this.enemyBar.Visible = false;
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(11, 11);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(110, 10);
            this.healthBar.TabIndex = 1;
            this.healthBar.Value = 100;
            // 
            // enemyShoot
            // 
            this.enemyShoot.Interval = 1500;
            this.enemyShoot.Tick += new System.EventHandler(this.shootEnemy);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Plane.Properties.Resources.plane;
            this.player.Location = new System.Drawing.Point(358, 540);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(80, 83);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Fuchsia;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Aqua;
            this.close.Location = new System.Drawing.Point(286, 307);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(120, 43);
            this.close.TabIndex = 4;
            this.close.Text = "End Game";
            this.close.UseVisualStyleBackColor = false;
            this.close.Visible = false;
            this.close.Click += new System.EventHandler(this.button1_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.ForeColor = System.Drawing.Color.White;
            this.result.Location = new System.Drawing.Point(281, 143);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 25);
            this.result.TabIndex = 8;
            this.result.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(810, 635);
            this.Controls.Add(this.result);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.close);
            this.Controls.Add(this.over);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Button over;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Timer enemyShoot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ProgressBar enemyBar;
        private System.Windows.Forms.Label result;
    }
}

