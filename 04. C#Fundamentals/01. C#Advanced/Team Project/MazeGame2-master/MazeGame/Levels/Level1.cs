namespace MazeGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Level1 : Form
    {
        int sec;
        int lifes;
        public Level1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
			//fdsf
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = StudentHero.Location.X;
            int y = StudentHero.Location.Y;

            if (e.KeyCode == Keys.Right) x += 10;
            else if (e.KeyCode == Keys.Left) x -= 10;
            else if (e.KeyCode == Keys.Up) y -= 10;
            else if (e.KeyCode == Keys.Down) y += 10;

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
                StudentHero.Bounds.IntersectsWith(pictureBox18.Bounds))
            {
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                lifes -= 1;
                sec = 60;
                SecLabel.Text = sec.ToString();
                LifesLabel.Text = lifes.ToString();
            }
            if (StudentHero.Bounds.IntersectsWith(KeyPicture.Bounds))
            {
                KeyPicture.Left = 800;
                KeyPicture.Visible = false;
                pictureBox18.Left = 800;
                pictureBox18.Visible = false;
            }
                if (StudentHero.Bounds.IntersectsWith(FinishLabel.Bounds))
            {
                sec = 60;
                lifes = 3;
                LifesLabel.Text = lifes.ToString();
                SecLabel.Text = sec.ToString();
                Timer1.Enabled = false;
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                this.Hide();
                var Level2 = new Level2();
                Level2.Closed += (s, args) => this.Close();
                Level2.Show();
            }
            if (lifes == 0)
            {
                sec = 60;
                lifes = 3;
                LifesLabel.Text = lifes.ToString();
                SecLabel.Text = sec.ToString();
                Timer1.Enabled = false;
                StudentHero.Left = 95;
                StudentHero.Top = 50;
                this.Hide();
                var GameOver = new GameOver();
                GameOver.Closed += (s, args) => this.Close();
                GameOver.Show();
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            sec = 60;
            lifes = 3;
            LifesLabel.Text = lifes.ToString();
            SecLabel.Text = sec.ToString();
            Timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            sec = sec - 1;
            SecLabel.Text = sec.ToString();
            if (sec == 0)
            {
                Timer1.Enabled = false;
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
