using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AIChatBotDemo.Services
{
    public class ImageService
    {
        private const int MaxDimension = 2048;

        public string ImageToBase64(Image image)
        {
            using var ms = new MemoryStream();
            var resized = ResizeIfNeeded(image);
            resized.Save(ms, ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        public Image? Base64ToImage(string base64)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64);
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch { return null; }
        }

        public Image? GetFromClipboard()
        {
            return Clipboard.ContainsImage() ? Clipboard.GetImage() : null;
        }

        public bool IsSupportedFormat(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            return ext is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".webp";
        }

        private Image ResizeIfNeeded(Image image)
        {
            if (image.Width <= MaxDimension && image.Height <= MaxDimension)
                return image;

            var ratio = Math.Min((double)MaxDimension / image.Width, (double)MaxDimension / image.Height);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var resized = new Bitmap(newWidth, newHeight);
            using var g = Graphics.FromImage(resized);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, newWidth, newHeight);
            return resized;
        }
    }
}
