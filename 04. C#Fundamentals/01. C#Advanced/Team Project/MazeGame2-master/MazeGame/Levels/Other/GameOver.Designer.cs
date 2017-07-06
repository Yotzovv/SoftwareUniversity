namespace MazeGame
{
    partial class GameOver
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
            System.Windows.Forms.Label textLabel;
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.playAgainButton = new System.Windows.Forms.Button();
            textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameOverLabel.Location = new System.Drawing.Point(121, 50);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(263, 46);
            this.GameOverLabel.TabIndex = 0;
            this.GameOverLabel.Text = "GAME OVER";
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Enabled = false;
            textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textLabel.Location = new System.Drawing.Point(157, 108);
            textLabel.Name = "textLabel";
            textLabel.Size = new System.Drawing.Size(192, 25);
            textLabel.TabIndex = 1;
            textLabel.Text = "Better luck next time!";
            //textLabel.Click += new System.EventHandler(this.textLabel_Click);
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.playAgainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playAgainButton.Location = new System.Drawing.Point(194, 155);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(126, 46);
            this.playAgainButton.TabIndex = 2;
            this.playAgainButton.Text = "Play Again!";
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 223);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(textLabel);
            this.Controls.Add(this.GameOverLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GameOver";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.Button playAgainButton;
    }
}