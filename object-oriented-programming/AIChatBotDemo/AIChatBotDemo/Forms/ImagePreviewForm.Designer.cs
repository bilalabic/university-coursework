namespace AIChatBotDemo.Forms
{
    partial class ImagePreviewForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.panelTools = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.panelTools.SuspendLayout();
            this.SuspendLayout();

            // picImage
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // panelTools
            this.panelTools.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelTools.Controls.Add(this.btnZoomIn);
            this.panelTools.Controls.Add(this.btnZoomOut);
            this.panelTools.Controls.Add(this.btnFit);
            this.panelTools.Controls.Add(this.lblInfo);
            this.panelTools.Controls.Add(this.btnClose);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTools.Location = new System.Drawing.Point(0, 510);
            this.panelTools.Size = new System.Drawing.Size(784, 50);

            // btnZoomIn
            this.btnZoomIn.Location = new System.Drawing.Point(12, 10);
            this.btnZoomIn.Size = new System.Drawing.Size(40, 30);
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);

            // btnZoomOut
            this.btnZoomOut.Location = new System.Drawing.Point(58, 10);
            this.btnZoomOut.Size = new System.Drawing.Size(40, 30);
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);

            // btnFit
            this.btnFit.Location = new System.Drawing.Point(104, 10);
            this.btnFit.Size = new System.Drawing.Size(80, 30);
            this.btnFit.Text = "Sığdır";
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);

            // lblInfo
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.Location = new System.Drawing.Point(300, 15);
            this.lblInfo.Size = new System.Drawing.Size(200, 20);
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(692, 10);
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ImagePreviewForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.panelTools);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ImagePreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Görsel Önizleme";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.panelTools.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnClose;
    }
}
