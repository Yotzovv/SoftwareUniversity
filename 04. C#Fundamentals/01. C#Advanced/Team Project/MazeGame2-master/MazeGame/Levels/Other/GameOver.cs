namespace MazeGame
{
    using System;
    using System.Windows.Forms;

    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Level1 = new Level1();
            Level1.Closed += (s, args) => this.Close();
            Level1.Show();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
    }
}
