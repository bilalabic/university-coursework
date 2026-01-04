namespace AIChatBotDemo.Forms
{
    partial class SettingsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAPI = new System.Windows.Forms.TabPage();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            
            this.grpOpenAI = new System.Windows.Forms.GroupBox();
            this.txtOpenAIKey = new System.Windows.Forms.TextBox();
            this.btnTestOpenAI = new System.Windows.Forms.Button();
            this.chkOpenAIEnabled = new System.Windows.Forms.CheckBox();
            this.lblOpenAI = new System.Windows.Forms.Label();
            this.lblOpenAIInfo = new System.Windows.Forms.Label();
            
            this.grpGemini = new System.Windows.Forms.GroupBox();
            this.txtGeminiKey = new System.Windows.Forms.TextBox();
            this.btnTestGemini = new System.Windows.Forms.Button();
            this.chkGeminiEnabled = new System.Windows.Forms.CheckBox();
            this.lblGemini = new System.Windows.Forms.Label();
            this.lblGeminiInfo = new System.Windows.Forms.Label();
            
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.cmbDefaultModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.trkTemperature = new System.Windows.Forms.TrackBar();
            this.lblTempValue = new System.Windows.Forms.Label();
            this.lblMaxTokens = new System.Windows.Forms.Label();
            this.numMaxTokens = new System.Windows.Forms.NumericUpDown();
            this.chkStreaming = new System.Windows.Forms.CheckBox();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabAPI.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpOpenAI.SuspendLayout();
            this.grpGemini.SuspendLayout();
            this.grpModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTokens)).BeginInit();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAPI);
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(16, 16);
            this.tabControl.Size = new System.Drawing.Size(568, 420);

            // tabAPI
            this.tabAPI.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.tabAPI.Controls.Add(this.grpOpenAI);
            this.tabAPI.Controls.Add(this.grpGemini);
            this.tabAPI.Text = "🔑 API Ayarları";
            this.tabAPI.Padding = new System.Windows.Forms.Padding(16);

            // grpOpenAI
            this.grpOpenAI.Controls.Add(this.lblOpenAI);
            this.grpOpenAI.Controls.Add(this.txtOpenAIKey);
            this.grpOpenAI.Controls.Add(this.btnTestOpenAI);
            this.grpOpenAI.Controls.Add(this.chkOpenAIEnabled);
            this.grpOpenAI.Controls.Add(this.lblOpenAIInfo);
            this.grpOpenAI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpOpenAI.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.grpOpenAI.Location = new System.Drawing.Point(16, 16);
            this.grpOpenAI.Size = new System.Drawing.Size(520, 160);
            this.grpOpenAI.Text = "OpenAI (GPT-4o, GPT-4o Mini)";

            this.lblOpenAI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOpenAI.Location = new System.Drawing.Point(16, 35);
            this.lblOpenAI.Size = new System.Drawing.Size(70, 23);
            this.lblOpenAI.Text = "API Key:";

            this.txtOpenAIKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOpenAIKey.Location = new System.Drawing.Point(90, 32);
            this.txtOpenAIKey.Size = new System.Drawing.Size(310, 25);
            this.txtOpenAIKey.UseSystemPasswordChar = true;
            this.txtOpenAIKey.PlaceholderText = "sk-...";

            this.btnTestOpenAI.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnTestOpenAI.FlatAppearance.BorderSize = 0;
            this.btnTestOpenAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestOpenAI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTestOpenAI.ForeColor = System.Drawing.Color.White;
            this.btnTestOpenAI.Location = new System.Drawing.Point(410, 30);
            this.btnTestOpenAI.Size = new System.Drawing.Size(90, 30);
            this.btnTestOpenAI.Text = "🔗 Test";
            this.btnTestOpenAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestOpenAI.Click += new System.EventHandler(this.btnTestOpenAI_Click);

            this.chkOpenAIEnabled.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkOpenAIEnabled.Location = new System.Drawing.Point(90, 70);
            this.chkOpenAIEnabled.Size = new System.Drawing.Size(150, 24);
            this.chkOpenAIEnabled.Text = "OpenAI Aktif";

            this.lblOpenAIInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOpenAIInfo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblOpenAIInfo.Location = new System.Drawing.Point(90, 100);
            this.lblOpenAIInfo.Size = new System.Drawing.Size(400, 40);
            this.lblOpenAIInfo.Text = "💡 API key almak için: platform.openai.com → API Keys\n     GPT-4o için ödeme yöntemi eklemeniz gerekir.";

            // grpGemini
            this.grpGemini.Controls.Add(this.lblGemini);
            this.grpGemini.Controls.Add(this.txtGeminiKey);
            this.grpGemini.Controls.Add(this.btnTestGemini);
            this.grpGemini.Controls.Add(this.chkGeminiEnabled);
            this.grpGemini.Controls.Add(this.lblGeminiInfo);
            this.grpGemini.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpGemini.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.grpGemini.Location = new System.Drawing.Point(16, 190);
            this.grpGemini.Size = new System.Drawing.Size(520, 160);
            this.grpGemini.Text = "Google Gemini (1.5 Pro, 1.5 Flash)";

            this.lblGemini.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGemini.Location = new System.Drawing.Point(16, 35);
            this.lblGemini.Size = new System.Drawing.Size(70, 23);
            this.lblGemini.Text = "API Key:";

            this.txtGeminiKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGeminiKey.Location = new System.Drawing.Point(90, 32);
            this.txtGeminiKey.Size = new System.Drawing.Size(310, 25);
            this.txtGeminiKey.UseSystemPasswordChar = true;
            this.txtGeminiKey.PlaceholderText = "AIza...";

            this.btnTestGemini.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnTestGemini.FlatAppearance.BorderSize = 0;
            this.btnTestGemini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestGemini.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTestGemini.ForeColor = System.Drawing.Color.White;
            this.btnTestGemini.Location = new System.Drawing.Point(410, 30);
            this.btnTestGemini.Size = new System.Drawing.Size(90, 30);
            this.btnTestGemini.Text = "🔗 Test";
            this.btnTestGemini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestGemini.Click += new System.EventHandler(this.btnTestGemini_Click);

            this.chkGeminiEnabled.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGeminiEnabled.Location = new System.Drawing.Point(90, 70);
            this.chkGeminiEnabled.Size = new System.Drawing.Size(150, 24);
            this.chkGeminiEnabled.Text = "Gemini Aktif";

            this.lblGeminiInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGeminiInfo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblGeminiInfo.Location = new System.Drawing.Point(90, 100);
            this.lblGeminiInfo.Size = new System.Drawing.Size(400, 40);
            this.lblGeminiInfo.Text = "💡 API key almak için: makersuite.google.com/app/apikey\n     ✨ Gemini ücretsiz kullanılabilir!";

            // tabGeneral
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.tabGeneral.Controls.Add(this.grpModel);
            this.tabGeneral.Text = "⚙️ Genel Ayarlar";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(16);

            // grpModel
            this.grpModel.Controls.Add(this.lblModel);
            this.grpModel.Controls.Add(this.cmbDefaultModel);
            this.grpModel.Controls.Add(this.lblTemp);
            this.grpModel.Controls.Add(this.trkTemperature);
            this.grpModel.Controls.Add(this.lblTempValue);
            this.grpModel.Controls.Add(this.lblMaxTokens);
            this.grpModel.Controls.Add(this.numMaxTokens);
            this.grpModel.Controls.Add(this.chkStreaming);
            this.grpModel.Controls.Add(this.chkAutoSave);
            this.grpModel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpModel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.grpModel.Location = new System.Drawing.Point(16, 16);
            this.grpModel.Size = new System.Drawing.Size(520, 320);
            this.grpModel.Text = "Model Ayarları";

            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModel.Location = new System.Drawing.Point(16, 40);
            this.lblModel.Size = new System.Drawing.Size(130, 23);
            this.lblModel.Text = "Varsayılan Model:";

            this.cmbDefaultModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultModel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDefaultModel.Location = new System.Drawing.Point(150, 37);
            this.cmbDefaultModel.Size = new System.Drawing.Size(220, 25);

            this.lblTemp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTemp.Location = new System.Drawing.Point(16, 85);
            this.lblTemp.Size = new System.Drawing.Size(130, 23);
            this.lblTemp.Text = "Temperature:";

            this.trkTemperature.Location = new System.Drawing.Point(150, 80);
            this.trkTemperature.Maximum = 100;
            this.trkTemperature.Size = new System.Drawing.Size(220, 45);
            this.trkTemperature.TickFrequency = 10;
            this.trkTemperature.Value = 70;
            this.trkTemperature.Scroll += new System.EventHandler(this.trkTemperature_Scroll);

            this.lblTempValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTempValue.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lblTempValue.Location = new System.Drawing.Point(380, 85);
            this.lblTempValue.Size = new System.Drawing.Size(60, 23);
            this.lblTempValue.Text = "0.70";

            this.lblMaxTokens.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxTokens.Location = new System.Drawing.Point(16, 140);
            this.lblMaxTokens.Size = new System.Drawing.Size(130, 23);
            this.lblMaxTokens.Text = "Max Tokens:";

            this.numMaxTokens.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxTokens.Location = new System.Drawing.Point(150, 137);
            this.numMaxTokens.Maximum = 8000;
            this.numMaxTokens.Minimum = 100;
            this.numMaxTokens.Size = new System.Drawing.Size(120, 25);
            this.numMaxTokens.Value = 2000;

            this.chkStreaming.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkStreaming.Location = new System.Drawing.Point(16, 190);
            this.chkStreaming.Size = new System.Drawing.Size(300, 24);
            this.chkStreaming.Text = "✨ Streaming Yanıt (gerçek zamanlı)";
            this.chkStreaming.Checked = true;

            this.chkAutoSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAutoSave.Location = new System.Drawing.Point(16, 225);
            this.chkAutoSave.Size = new System.Drawing.Size(300, 24);
            this.chkAutoSave.Text = "💾 Otomatik Kaydet";
            this.chkAutoSave.Checked = true;

            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(380, 450);
            this.btnSave.Size = new System.Drawing.Size(100, 38);
            this.btnSave.Text = "💾 Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnCancel.Location = new System.Drawing.Point(490, 450);
            this.btnCancel.Size = new System.Drawing.Size(90, 38);
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // SettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.ClientSize = new System.Drawing.Size(600, 505);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "⚙️ Ayarlar";

            this.tabControl.ResumeLayout(false);
            this.tabAPI.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.grpOpenAI.ResumeLayout(false);
            this.grpOpenAI.PerformLayout();
            this.grpGemini.ResumeLayout(false);
            this.grpGemini.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTokens)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAPI;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox grpOpenAI;
        private System.Windows.Forms.Label lblOpenAI;
        private System.Windows.Forms.TextBox txtOpenAIKey;
        private System.Windows.Forms.Button btnTestOpenAI;
        private System.Windows.Forms.CheckBox chkOpenAIEnabled;
        private System.Windows.Forms.Label lblOpenAIInfo;
        private System.Windows.Forms.GroupBox grpGemini;
        private System.Windows.Forms.Label lblGemini;
        private System.Windows.Forms.TextBox txtGeminiKey;
        private System.Windows.Forms.Button btnTestGemini;
        private System.Windows.Forms.CheckBox chkGeminiEnabled;
        private System.Windows.Forms.Label lblGeminiInfo;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbDefaultModel;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.TrackBar trkTemperature;
        private System.Windows.Forms.Label lblTempValue;
        private System.Windows.Forms.Label lblMaxTokens;
        private System.Windows.Forms.NumericUpDown numMaxTokens;
        private System.Windows.Forms.CheckBox chkStreaming;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
