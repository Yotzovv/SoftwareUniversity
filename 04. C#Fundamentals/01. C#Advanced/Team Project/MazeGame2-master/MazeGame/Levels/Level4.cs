using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Level4 : Form
    {
        int sec;
        int lifes;

        public Level4()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            int x = StudentHero.Location.X;
            int y = StudentHero.Location.Y;

            if (e.KeyCode == Keys.Right) x += 10;
            else if (e.KeyCode == Keys.Left) x -= 10;
            else if (e.KeyCode == Keys.Up) y -= 10;
            else if (e.KeyCode == Keys.Down) y += 10;

            StudentHero.Location = new Point(x, y);

            if (StudentHero.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox2.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox3.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox4.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox6.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox7.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox8.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox9.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox10.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox11.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox12.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox13.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox14.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox15.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox16.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox17.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox18.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox19.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox20.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox21.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox22.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox23.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox24.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox25.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox26.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox27.Bounds) ||
                StudentHero.Bounds.IntersectsWith(pictureBox28.Bounds))
            {
                StudentHero.Left = 47;
                StudentHero.Top = 72;
                lifes -= 1;
                sec = 60;
                SecLabel.Text = sec.ToString();
                LifesLabel.Text = lifes.ToString();
            }

            if (StudentHero.Bounds.IntersectsWith(FinishLabel.Bounds))
            {
                sec = 60;
                lifes = 3;
                LifesLabel.Text = lifes.ToString();
                SecLabel.Text = sec.ToString();
                timer1.Enabled = false;
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                this.Hide();
                var Level5 = new Level5();
                Level5.Closed += (s, args) => this.Close();
                Level5.Show();
            }

            if (lifes <= 0)
            {
                this.Hide();
                var GameOver = new GameOver();
                GameOver.Closed += (s, args) => this.Close();
                GameOver.Show();
            }
        }

        private void Level4_Load(object sender, EventArgs e)
        {

        }

        private void Level4_Load_1(object sender, EventArgs e)
        {
            sec = 60;
            lifes = 3;
            LifesLabel.Text = lifes.ToString();
            SecLabel.Text = sec.ToString();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec - 1;
            SecLabel.Text = sec.ToString();
            if (sec == 0)
            {
                timer1.Enabled = false;
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                this.Hide();
                var GameOver = new GameOver();
                GameOver.Closed += (s, args) => this.Close();
                GameOver.Show();
                sec = 60;
                lifes = 3;
            }
        }
    }
}
