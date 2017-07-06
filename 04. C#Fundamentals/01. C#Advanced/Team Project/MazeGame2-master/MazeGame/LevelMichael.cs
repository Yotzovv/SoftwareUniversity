namespace MazeGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class LevelMichael : Form
    {
        int sec;
        int lifes;

        public LevelMichael()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(LevelMichael_KeyDown);
        }

        private void LevelMichael_KeyDown(object sender, KeyEventArgs key)
        {
            int x = StudentHero.Location.X;
            int y = StudentHero.Location.Y;

            if (key.KeyCode == Keys.Right) x += 20;
            else if (key.KeyCode == Keys.Left) x -= 20;
            else if (key.KeyCode == Keys.Up) y -= 20;
            else if (key.KeyCode == Keys.Down) y += 20;

            StudentHero.Location = new Point(x, y);

            if (StudentHero.Bounds.IntersectsWith(pictureBox2.Bounds) ||
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
                pictureBox1.Left = 95;
                pictureBox1.Top = 50;
                lifes -= 1;
                LifesLabel.Text = lifes.ToString();
            }

            //TODO: implement next Level StartUp
            //if (StudentHero.Bounds.IntersectsWith(FinishLabel.Bounds))
            //{
            //    this.Hide();
            //    var Level2 = new Level2();
            //    Level2.Closed += (s, args) => this.Close();
            //    Level2.Show();
            //}
            if (lifes == 0 || StudentHero.Bounds.IntersectsWith(TrapLabel.Bounds))
            {
                this.Hide();
                var GameOver = new GameOver();
                GameOver.Closed += (s, args) => this.Close();
                GameOver.Show();
            }
        }

        public void LevelMichael_Load(object sender, EventArgs key)
        {
            sec = 15;
            lifes = 3;
            LifesLabel.Text = lifes.ToString();
            SecLabel.Text = sec.ToString();
        }
    }
}
