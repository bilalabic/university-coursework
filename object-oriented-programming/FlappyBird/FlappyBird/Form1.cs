using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        int pipeTimerCounter = 39;

        int velocity = 0;
        int gravity = 1;
        int jumpForce = -12;
        int score = 0;
        Boolean gameOver = false;

        
        List<PictureBox> scoredPipes = new List<PictureBox>();


        Region regionKanatYukari;
        Region regionKanatAsagi;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            regionKanatYukari = CreateRegionFromBitmap(Properties.Resources.KanatYukari);
            regionKanatAsagi = CreateRegionFromBitmap(Properties.Resources.KanatAsagi);
        }

        private void timerFlyingTimer_Tick(object sender, EventArgs e)
        {
            pctBird.Image = (velocity < 0) ? Properties.Resources.KanatYukari : Properties.Resources.KanatAsagi;
        }

        private void timerFallDown_Tick(object sender, EventArgs e)
        {
            velocity += gravity;
            pctBird.Top += velocity;
            if (pctBird.Bottom > this.ClientSize.Height)
            {
                pctBird.Top = this.ClientSize.Height + 5 - pctBird.Height;
                GameOver();
            }
            if (pctBird.Top < 0)
            {
                GameOver();
            }
        }

        private void pctBird_Click(object sender, EventArgs e)
        {
            Jump();
        }

        public void CreateUpperNLowerPipes()
        {

            const int PIPE_HEAD_HEIGHT = 60;
            const int PIPE_GAP = 280;

            int upperBodyHeight = random.Next(50, 351);

            int pipeStartX = this.ClientSize.Width;


            var pipePart1 = new PictureBox();
            pipePart1.BackColor = Color.DarkGreen;
            pipePart1.BorderStyle = BorderStyle.None;
            pipePart1.Size = new Size(150, PIPE_HEAD_HEIGHT);
            pipePart1.Location = new Point(pipeStartX, upperBodyHeight);
            pipePart1.Image = Properties.Resources.EngelBas;
            pipePart1.Visible = true;
            this.Controls.Add(pipePart1);

            var pipePart2 = new PictureBox();

            pipePart2.BackColor = Color.DarkGreen;
            pipePart2.BorderStyle = BorderStyle.None;
            pipePart2.Size = new Size(130, upperBodyHeight);
            pipePart2.Location = new Point(pipeStartX + 10, 0);
            pipePart2.BackgroundImage = Properties.Resources.EngelGovde;
            pipePart2.BackgroundImageLayout = ImageLayout.Tile;
            pipePart2.Visible = true;
            this.Controls.Add(pipePart2);


            var pipePart3 = new PictureBox();

            pipePart3.BackColor = Color.DarkGreen;
            pipePart3.BorderStyle = BorderStyle.None;
            pipePart3.Size = new Size(150, PIPE_HEAD_HEIGHT);
            int lowerHeadTopY = upperBodyHeight + PIPE_HEAD_HEIGHT + PIPE_GAP;
            pipePart3.Location = new Point(pipeStartX, lowerHeadTopY);
            pipePart3.Image = Properties.Resources.EngelBas;
            pipePart3.Visible = true;
            this.Controls.Add(pipePart3);

            var pipePart4 = new PictureBox();

            pipePart4.BackColor = Color.DarkGreen;
            pipePart4.BorderStyle = BorderStyle.None;
            int lowerBodyTopY = lowerHeadTopY + PIPE_HEAD_HEIGHT;
            int lowerBodyHeight = this.ClientSize.Height - lowerBodyTopY;
            pipePart4.Size = new Size(130, lowerBodyHeight);
            pipePart4.Location = new Point(pipeStartX + 10, lowerBodyTopY);
            pipePart4.BackgroundImage = Properties.Resources.EngelGovde;
            pipePart4.BackgroundImageLayout = ImageLayout.Tile;
            pipePart4.Visible = true;
            this.Controls.Add(pipePart4);

            pipePart1.BringToFront();
            pipePart2.BringToFront();
            pipePart3.BringToFront();
            pipePart4.BringToFront();

        }


        public static Region RegionFromImage(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
                return null;

            Point screenPoint = pictureBox.PointToScreen(new Point(0, 0));
            Point formPoint = pictureBox.FindForm().PointToScreen(new Point(0, 0));
            int offsetX = screenPoint.X - formPoint.X - pictureBox.FindForm().ClientRectangle.X;
            int offsetY = screenPoint.Y - formPoint.Y - pictureBox.FindForm().ClientRectangle.Y;

            GraphicsPath path = new GraphicsPath();
            Bitmap bmp = new Bitmap(pictureBox.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y).A > 0)
                    {
                        path.AddRectangle(new Rectangle(x + pictureBox.Left, y + pictureBox.Top, 1, 1));
                    }
                }
            }
            return new Region(path);
        }




        private Region CreateRegionFromBitmap(Bitmap bmp)
        {
            GraphicsPath path = new GraphicsPath();
            // Resmin her pikselini tara
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Sadece şeffaf olmayan (görünür) pikselleri dikkate al
                    if (bmp.GetPixel(x, y).A > 0)
                    {
                        // 1x1 piksellik bir dikdörtgen ekle
                        path.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            return new Region(path);
        }




        private void timerMovingPipes_Tick(object sender, EventArgs e)
        {
            pipeTimerCounter++;
            if (pipeTimerCounter >= 40)
            {
                CreateUpperNLowerPipes();
                pipeTimerCounter = 0;
            }
            Region currentBirdRegionTemplate = (velocity < 0) ? regionKanatYukari : regionKanatAsagi;
            Region birdCollisionRegion = currentBirdRegionTemplate.Clone();
            birdCollisionRegion.Translate(pctBird.Left, pctBird.Top);
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.BackColor == Color.DarkGreen)
                {
                    PictureBox pipe = c as PictureBox;
                    pipe.Left -= 10;
                    if (birdCollisionRegion.IsVisible(pipe.Bounds))
                    {
                        Region tempRegion = birdCollisionRegion.Clone();
                        tempRegion.Intersect(pipe.Bounds);

                        if (!tempRegion.IsEmpty(this.CreateGraphics()))
                        {
                            GameOver();
                            return;
                        }
                    }

                    if (pipe.Left < -170)
                    {
                        pipe.Dispose();
                    }
                    if (pipe.Image != null && pipe.Top < 400)
                    {
                        // Eğer borunun sağ tarafı, kuşun solunu geçtiyse VE bu borudan daha önce puan almadıysak...
                        if (pipe.Right < pctBird.Left && !scoredPipes.Contains(pipe))
                        {
                            score += 10; // Skora 10 ekle
                            lbnScore.Text = score.ToString();
                            scoredPipes.Add(pipe); // Bu boruyu "puan alındı" listesine ekle ki bir daha puan vermesin.
                        }
                    }
                }
            }
        }
        public void GameOver()
        {
            gameOver = true;
            timerMovingPipes.Enabled = false;
            timerFallDown.Enabled = false;
            timerFlyingTimer.Enabled = false;
            lbnFinalScore.Text = "YOUR SCORE: " + score.ToString();
            lbnFinalScore.Visible = true;
            lbnNewGame.BringToFront();
            lbnGameOver.BringToFront();
            lbnFinalScore.BringToFront();
            lbnGameOver.Visible = true;
            lbnNewGame.Visible = true;
        }

        private void lbnNewGame_MouseHover(object sender, EventArgs e)
        {
            lbnNewGame.BackColor = Color.Violet;
        }

        private void lbnNewGame_MouseLeave(object sender, EventArgs e)
        {
            lbnNewGame.BackColor = Color.OrangeRed;
        }

        private void lbnNewGame_Click(object sender, EventArgs e)
        {
            List<Control> pipesToRemove = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.BackColor == Color.DarkGreen)
                {
                    pipesToRemove.Add(c);
                }
            }
            foreach (Control pipe in pipesToRemove)
            {
                this.Controls.Remove(pipe);
                pipe.Dispose();
            }
            pipeTimerCounter = 39;
            score = 0;
            lbnScore.Text = "0";
            lbnFinalScore.Text = "YOUR SCORE: 0";
            gameOver = false;
            pctBird.Location = new Point(120, 280);
            lbnGameOver.Visible = false;
            lbnNewGame.Visible = false;
            lbnFinalScore.Visible = false;
            timerFlyingTimer.Enabled = true;
            timerFallDown.Enabled = true;
            timerMovingPipes.Enabled = true;

        }

        private void Jump()
        {
            if (!gameOver)
            {
                velocity = jumpForce;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Jump();
            }
        }


    }
}
