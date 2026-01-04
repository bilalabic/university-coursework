namespace AIChatBotDemo.Forms
{
    partial class AboutForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.panelHeader.Controls.Add(this.lblAppName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Size = new System.Drawing.Size(450, 100);

            // lblAppName
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Text = "🤖 AI ChatBot Pro";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblVersion
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblVersion.Location = new System.Drawing.Point(0, 115);
            this.lblVersion.Size = new System.Drawing.Size(450, 25);
            this.lblVersion.Text = "Versiyon 1.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblDescription
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblDescription.Location = new System.Drawing.Point(30, 150);
            this.lblDescription.Size = new System.Drawing.Size(390, 30);
            this.lblDescription.Text = "Çoklu LLM destekli profesyonel chatbot uygulaması";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblFeatures
            this.lblFeatures.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFeatures.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblFeatures.Location = new System.Drawing.Point(50, 190);
            this.lblFeatures.Size = new System.Drawing.Size(350, 120);
            this.lblFeatures.Text = "✨ Desteklenen Modeller:\n" +
                "     • OpenAI GPT-4o, GPT-4o Mini\n" +
                "     • Google Gemini 1.5 Pro, 1.5 Flash\n\n" +
                "🎯 Özellikler:\n" +
                "     • Görsel analiz (Vision API)\n" +
                "     • Streaming yanıtlar\n" +
                "     • Markdown rendering";

            // lblCopyright
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblCopyright.Location = new System.Drawing.Point(0, 320);
            this.lblCopyright.Size = new System.Drawing.Size(450, 20);
            this.lblCopyright.Text = "© 2026 AI ChatBot Pro - Made with ❤️";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnOK
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(175, 350);
            this.btnOK.Size = new System.Drawing.Size(100, 36);
            this.btnOK.Text = "Tamam";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // AboutForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFeatures);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hakkında";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnOK;
    }
}
