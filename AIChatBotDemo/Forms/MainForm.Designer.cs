namespace AIChatBotDemo.Forms
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuApiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLightTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDarkTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.listChats = new System.Windows.Forms.ListBox();
            this.btnNewChat = new System.Windows.Forms.Button();
            this.lblChats = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.panelChat = new System.Windows.Forms.Panel();
            this.webViewChat = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelInputInner = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.btnAttachImage = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();

            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.panelInputInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuFile, this.menuSettings, this.menuHelp });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.menuStrip.Size = new System.Drawing.Size(1280, 28);

            // menuFile
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuNewChat, this.menuSaveChat, this.menuSep1, this.menuExport, this.menuSep2, this.menuExit });
            this.menuFile.Name = "menuFile";
            this.menuFile.Text = "Dosya";

            this.menuNewChat.Name = "menuNewChat";
            this.menuNewChat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNewChat.Text = "Yeni Sohbet";
            this.menuNewChat.Click += new System.EventHandler(this.menuNewChat_Click);

            this.menuSaveChat.Name = "menuSaveChat";
            this.menuSaveChat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveChat.Text = "Kaydet";
            this.menuSaveChat.Click += new System.EventHandler(this.menuSaveChat_Click);

            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuExportJson, this.menuExportTxt });
            this.menuExport.Name = "menuExport";
            this.menuExport.Text = "Dışa Aktar";

            this.menuExportJson.Name = "menuExportJson";
            this.menuExportJson.Text = "JSON";
            this.menuExportJson.Click += new System.EventHandler(this.menuExportJson_Click);

            this.menuExportTxt.Name = "menuExportTxt";
            this.menuExportTxt.Text = "TXT";
            this.menuExportTxt.Click += new System.EventHandler(this.menuExportTxt_Click);

            this.menuExit.Name = "menuExit";
            this.menuExit.Text = "Çıkış";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            // menuSettings
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuApiSettings, this.menuTheme });
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Text = "Ayarlar";

            this.menuApiSettings.Name = "menuApiSettings";
            this.menuApiSettings.Text = "API Ayarları";
            this.menuApiSettings.Click += new System.EventHandler(this.menuApiSettings_Click);

            this.menuTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuLightTheme, this.menuDarkTheme });
            this.menuTheme.Name = "menuTheme";
            this.menuTheme.Text = "Tema";

            this.menuLightTheme.Name = "menuLightTheme";
            this.menuLightTheme.Text = "☀️ Açık Tema";
            this.menuLightTheme.Click += new System.EventHandler(this.menuLightTheme_Click);

            this.menuDarkTheme.Name = "menuDarkTheme";
            this.menuDarkTheme.Text = "🌙 Koyu Tema";
            this.menuDarkTheme.Click += new System.EventHandler(this.menuDarkTheme_Click);

            // menuHelp
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuAbout });
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Text = "Yardım";

            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "Hakkında";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);

            // statusStrip
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus, this.progressBar });
            this.statusStrip.Location = new System.Drawing.Point(0, 778);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1280, 22);

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1163, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Hazır";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;

            // splitMain
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 28);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.panelSidebar);
            this.splitMain.Panel2.Controls.Add(this.panelChat);
            this.splitMain.Size = new System.Drawing.Size(1280, 750);
            this.splitMain.SplitterDistance = 280;
            this.splitMain.SplitterWidth = 1;

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelSidebar.Controls.Add(this.listChats);
            this.panelSidebar.Controls.Add(this.btnNewChat);
            this.panelSidebar.Controls.Add(this.lblChats);
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(12);

            // lblAppTitle
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(12, 12);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(256, 40);
            this.lblAppTitle.Text = "🤖 AI ChatBot";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnNewChat
            this.btnNewChat.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnNewChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewChat.FlatAppearance.BorderSize = 0;
            this.btnNewChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnNewChat.ForeColor = System.Drawing.Color.White;
            this.btnNewChat.Location = new System.Drawing.Point(12, 52);
            this.btnNewChat.Name = "btnNewChat";
            this.btnNewChat.Size = new System.Drawing.Size(256, 42);
            this.btnNewChat.Text = "➕  Yeni Sohbet";
            this.btnNewChat.Click += new System.EventHandler(this.btnNewChat_Click);

            // lblChats
            this.lblChats.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChats.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblChats.Location = new System.Drawing.Point(12, 94);
            this.lblChats.Name = "lblChats";
            this.lblChats.Padding = new System.Windows.Forms.Padding(0, 12, 0, 4);
            this.lblChats.Size = new System.Drawing.Size(256, 35);
            this.lblChats.Text = "SON SOHBETLER";

            // listChats
            this.listChats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listChats.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.listChats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listChats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listChats.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.listChats.ItemHeight = 32;
            this.listChats.Location = new System.Drawing.Point(12, 129);
            this.listChats.Name = "listChats";
            this.listChats.Size = new System.Drawing.Size(256, 609);
            this.listChats.SelectedIndexChanged += new System.EventHandler(this.listChats_SelectedIndexChanged);

            // panelChat
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.panelChat.Controls.Add(this.webViewChat);
            this.panelChat.Controls.Add(this.panelInput);
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.Name = "panelChat";

            // webViewChat
            this.webViewChat.AllowExternalDrop = true;
            this.webViewChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewChat.Location = new System.Drawing.Point(0, 0);
            this.webViewChat.Name = "webViewChat";
            this.webViewChat.Size = new System.Drawing.Size(999, 620);

            // panelInput
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.panelInput.Controls.Add(this.panelInputInner);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInput.Location = new System.Drawing.Point(0, 620);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(20, 12, 20, 16);
            this.panelInput.Size = new System.Drawing.Size(999, 130);

            // panelInputInner
            this.panelInputInner.BackColor = System.Drawing.Color.White;
            this.panelInputInner.Controls.Add(this.txtMessage);
            this.panelInputInner.Controls.Add(this.btnAttachImage);
            this.panelInputInner.Controls.Add(this.btnSend);
            this.panelInputInner.Controls.Add(this.btnCancel);
            this.panelInputInner.Controls.Add(this.cmbModel);
            this.panelInputInner.Controls.Add(this.picPreview);
            this.panelInputInner.Controls.Add(this.btnRemoveImage);
            this.panelInputInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInputInner.Name = "panelInputInner";
            this.panelInputInner.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);

            // txtMessage
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtMessage.Location = new System.Drawing.Point(16, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "Mesajınızı yazın... (Enter: Gönder, Shift+Enter: Yeni satır)";
            this.txtMessage.Size = new System.Drawing.Size(700, 45);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);

            // btnAttachImage
            this.btnAttachImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachImage.BackColor = System.Drawing.Color.Transparent;
            this.btnAttachImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttachImage.FlatAppearance.BorderSize = 0;
            this.btnAttachImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnAttachImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachImage.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.btnAttachImage.Location = new System.Drawing.Point(726, 8);
            this.btnAttachImage.Name = "btnAttachImage";
            this.btnAttachImage.Size = new System.Drawing.Size(50, 50);
            this.btnAttachImage.Text = "🖼️";
            this.btnAttachImage.Click += new System.EventHandler(this.btnAttachImage_Click);

            // btnSend
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(786, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 50);
            this.btnSend.Text = "Gönder ➤";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(896, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 50);
            this.btnCancel.Text = "İptal";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // cmbModel
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbModel.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbModel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.cmbModel.Location = new System.Drawing.Point(16, 68);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(180, 23);
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);

            // picPreview
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picPreview.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(210, 62);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(36, 36);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.Visible = false;

            // btnRemoveImage
            this.btnRemoveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveImage.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnRemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveImage.FlatAppearance.BorderSize = 0;
            this.btnRemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveImage.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnRemoveImage.ForeColor = System.Drawing.Color.White;
            this.btnRemoveImage.Location = new System.Drawing.Point(250, 62);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveImage.Text = "✕";
            this.btnRemoveImage.Visible = false;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);

            // MainForm
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI ChatBot Pro";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelChat.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInputInner.ResumeLayout(false);
            this.panelInputInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewChat;
        private System.Windows.Forms.ToolStripMenuItem menuSaveChat;
        private System.Windows.Forms.ToolStripSeparator menuSep1;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExportJson;
        private System.Windows.Forms.ToolStripMenuItem menuExportTxt;
        private System.Windows.Forms.ToolStripSeparator menuSep2;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuApiSettings;
        private System.Windows.Forms.ToolStripMenuItem menuTheme;
        private System.Windows.Forms.ToolStripMenuItem menuLightTheme;
        private System.Windows.Forms.ToolStripMenuItem menuDarkTheme;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.ListBox listChats;
        private System.Windows.Forms.Button btnNewChat;
        private System.Windows.Forms.Label lblChats;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel panelChat;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewChat;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelInputInner;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAttachImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnRemoveImage;
    }
}
