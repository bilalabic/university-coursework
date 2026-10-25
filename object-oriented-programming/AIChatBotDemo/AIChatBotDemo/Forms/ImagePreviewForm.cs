using System;
using System.Drawing;
using System.Windows.Forms;

namespace AIChatBotDemo.Forms
{
    public partial class ImagePreviewForm : Form
    {
        private readonly Image _originalImage;
        private float _zoom = 1.0f;

        public ImagePreviewForm(Image image)
        {
            InitializeComponent();
            _originalImage = image;
            picImage.Image = image;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lblInfo.Text = $"{_originalImage.Width} x {_originalImage.Height} | Zoom: {_zoom:P0}";
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            _zoom = Math.Min(_zoom + 0.25f, 4.0f);
            ApplyZoom();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            _zoom = Math.Max(_zoom - 0.25f, 0.25f);
            ApplyZoom();
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.Image = _originalImage;
            _zoom = 1.0f;
            UpdateInfo();
        }

        private void ApplyZoom()
        {
            var newWidth = (int)(_originalImage.Width * _zoom);
            var newHeight = (int)(_originalImage.Height * _zoom);

            var zoomed = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(zoomed))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(_originalImage, 0, 0, newWidth, newHeight);
            }

            picImage.SizeMode = PictureBoxSizeMode.CenterImage;
            picImage.Image = zoomed;
            UpdateInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
