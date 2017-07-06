namespace MazeGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Level3 : Form
    {
        int sec;
        int lifes;

        public Level3()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(LevelMichael_KeyDown);
        }

        private void LevelMichael_KeyDown(object sender, KeyEventArgs key)
        {
            int x = StudentHero.Location.X;
            int y = StudentHero.Location.Y;

            if (key.KeyCode == Keys.Right) x += 10;
            else if (key.KeyCode == Keys.Left) x -= 10;
            else if (key.KeyCode == Keys.Up) y -= 10;
            else if (key.KeyCode == Keys.Down) y += 10;

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
                StudentHero.Left = 3;
                StudentHero.Top = 30;
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
                Timer3.Enabled = false;
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                this.Hide();
                var Level4 = new Level4();
                Level4.Closed += (s, args) => this.Close();
                Level4.Show();
            }

            if (lifes == 0)
            {
                sec = 60;
                lifes = 3;
                LifesLabel.Text = lifes.ToString();
                SecLabel.Text = sec.ToString();
                Timer3.Enabled = false;

                StudentHero.Left = 95;
                StudentHero.Top = 50;

                this.Hide();
                var GameOver = new GameOver();
                GameOver.Closed += (s, args) => this.Close();
                GameOver.Show();
            }
        }

        public void LevelMichael_Load(object sender, EventArgs key)
        {
            sec = 60;
            lifes = 3;
            LifesLabel.Text = lifes.ToString();
            SecLabel.Text = sec.ToString();
            Timer3.Enabled = true;

        }

        private void Timer3_Tick(object sender, EventArgs key)
        {
            sec = sec - 1;
            SecLabel.Text = sec.ToString();
            if (sec == 0)
            {
                Timer3.Enabled = false;
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
