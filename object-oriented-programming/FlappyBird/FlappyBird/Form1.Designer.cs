namespace FlappyBird
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerFlyingTimer = new System.Windows.Forms.Timer(this.components);
            this.timerFallDown = new System.Windows.Forms.Timer(this.components);
            this.pctBird = new System.Windows.Forms.PictureBox();
            this.timerMovingPipes = new System.Windows.Forms.Timer(this.components);
            this.lbnGameOver = new System.Windows.Forms.Label();
            this.lbnNewGame = new System.Windows.Forms.Label();
            this.lbnFinalScore = new System.Windows.Forms.Label();
            this.lbnScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctBird)).BeginInit();
            this.SuspendLayout();
            // 
            // timerFlyingTimer
            // 
            this.timerFlyingTimer.Enabled = true;
            this.timerFlyingTimer.Tick += new System.EventHandler(this.timerFlyingTimer_Tick);
            // 
            // timerFallDown
            // 
            this.timerFallDown.Enabled = true;
            this.timerFallDown.Tick += new System.EventHandler(this.timerFallDown_Tick);
            // 
            // pctBird
            // 
            this.pctBird.BackColor = System.Drawing.Color.SkyBlue;
            this.pctBird.Image = ((System.Drawing.Image)(resources.GetObject("pctBird.Image")));
            this.pctBird.Location = new System.Drawing.Point(120, 280);
            this.pctBird.Name = "pctBird";
            this.pctBird.Size = new System.Drawing.Size(130, 120);
            this.pctBird.TabIndex = 0;
            this.pctBird.TabStop = false;
            this.pctBird.Click += new System.EventHandler(this.pctBird_Click);
            // 
            // timerMovingPipes
            // 
            this.timerMovingPipes.Enabled = true;
            this.timerMovingPipes.Tick += new System.EventHandler(this.timerMovingPipes_Tick);
            // 
            // lbnGameOver
            // 
            this.lbnGameOver.AutoSize = true;
            this.lbnGameOver.BackColor = System.Drawing.Color.White;
            this.lbnGameOver.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnGameOver.ForeColor = System.Drawing.Color.Black;
            this.lbnGameOver.Location = new System.Drawing.Point(423, 234);
            this.lbnGameOver.Name = "lbnGameOver";
            this.lbnGameOver.Size = new System.Drawing.Size(267, 53);
            this.lbnGameOver.TabIndex = 1;
            this.lbnGameOver.Text = "GAME OVER";
            this.lbnGameOver.Visible = false;
            // 
            // lbnNewGame
            // 
            this.lbnNewGame.AutoSize = true;
            this.lbnNewGame.BackColor = System.Drawing.Color.OrangeRed;
            this.lbnNewGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbnNewGame.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnNewGame.ForeColor = System.Drawing.Color.White;
            this.lbnNewGame.Location = new System.Drawing.Point(423, 345);
            this.lbnNewGame.Name = "lbnNewGame";
            this.lbnNewGame.Size = new System.Drawing.Size(248, 55);
            this.lbnNewGame.TabIndex = 2;
            this.lbnNewGame.Text = "NEW GAME";
            this.lbnNewGame.Visible = false;
            this.lbnNewGame.Click += new System.EventHandler(this.lbnNewGame_Click);
            this.lbnNewGame.MouseLeave += new System.EventHandler(this.lbnNewGame_MouseLeave);
            this.lbnNewGame.MouseHover += new System.EventHandler(this.lbnNewGame_MouseHover);
            // 
            // lbnFinalScore
            // 
            this.lbnFinalScore.AutoSize = true;
            this.lbnFinalScore.BackColor = System.Drawing.Color.White;
            this.lbnFinalScore.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnFinalScore.ForeColor = System.Drawing.Color.Black;
            this.lbnFinalScore.Location = new System.Drawing.Point(423, 287);
            this.lbnFinalScore.Name = "lbnFinalScore";
            this.lbnFinalScore.Size = new System.Drawing.Size(350, 53);
            this.lbnFinalScore.TabIndex = 3;
            this.lbnFinalScore.Text = "YOUR SCORE: 0";
            this.lbnFinalScore.Visible = false;
            // 
            // lbnScore
            // 
            this.lbnScore.AutoSize = true;
            this.lbnScore.BackColor = System.Drawing.Color.Transparent;
            this.lbnScore.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnScore.ForeColor = System.Drawing.Color.Black;
            this.lbnScore.Location = new System.Drawing.Point(934, 9);
            this.lbnScore.Name = "lbnScore";
            this.lbnScore.Size = new System.Drawing.Size(52, 53);
            this.lbnScore.TabIndex = 4;
            this.lbnScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(999, 761);
            this.Controls.Add(this.lbnScore);
            this.Controls.Add(this.lbnFinalScore);
            this.Controls.Add(this.lbnNewGame);
            this.Controls.Add(this.lbnGameOver);
            this.Controls.Add(this.pctBird);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flappy Bird";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctBird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBird;
        private System.Windows.Forms.Timer timerFlyingTimer;
        private System.Windows.Forms.Timer timerFallDown;
        private System.Windows.Forms.Timer timerMovingPipes;
        private System.Windows.Forms.Label lbnGameOver;
        private System.Windows.Forms.Label lbnNewGame;
        private System.Windows.Forms.Label lbnFinalScore;
        private System.Windows.Forms.Label lbnScore;
    }
}

