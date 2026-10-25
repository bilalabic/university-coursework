namespace DemoChatSocketApp
{
    partial class ChatServer
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
            this.txtServerMesaj = new System.Windows.Forms.TextBox();
            this.btnServerGonder = new System.Windows.Forms.Button();
            this.txtServerMesajlar = new System.Windows.Forms.TextBox();
            this.btnServerBaglantiyiKes = new System.Windows.Forms.Button();
            this.lbnClientUsername = new System.Windows.Forms.Label();
            this.lbnBaglantiDurum = new System.Windows.Forms.Label();
            this.lbn5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtServerMesaj
            // 
            this.txtServerMesaj.Location = new System.Drawing.Point(59, 494);
            this.txtServerMesaj.Multiline = true;
            this.txtServerMesaj.Name = "txtServerMesaj";
            this.txtServerMesaj.Size = new System.Drawing.Size(339, 39);
            this.txtServerMesaj.TabIndex = 1;
            this.txtServerMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerMesaj_KeyPress);
            // 
            // btnServerGonder
            // 
            this.btnServerGonder.Location = new System.Drawing.Point(404, 493);
            this.btnServerGonder.Name = "btnServerGonder";
            this.btnServerGonder.Size = new System.Drawing.Size(157, 40);
            this.btnServerGonder.TabIndex = 2;
            this.btnServerGonder.Text = "Gönder";
            this.btnServerGonder.UseVisualStyleBackColor = true;
            this.btnServerGonder.Click += new System.EventHandler(this.btnServerGonder_Click);
            // 
            // txtServerMesajlar
            // 
            this.txtServerMesajlar.Location = new System.Drawing.Point(59, 74);
            this.txtServerMesajlar.Multiline = true;
            this.txtServerMesajlar.Name = "txtServerMesajlar";
            this.txtServerMesajlar.ReadOnly = true;
            this.txtServerMesajlar.Size = new System.Drawing.Size(675, 413);
            this.txtServerMesajlar.TabIndex = 3;
            // 
            // btnServerBaglantiyiKes
            // 
            this.btnServerBaglantiyiKes.Location = new System.Drawing.Point(567, 493);
            this.btnServerBaglantiyiKes.Name = "btnServerBaglantiyiKes";
            this.btnServerBaglantiyiKes.Size = new System.Drawing.Size(167, 40);
            this.btnServerBaglantiyiKes.TabIndex = 4;
            this.btnServerBaglantiyiKes.Text = "Bağlantıyı Kes";
            this.btnServerBaglantiyiKes.UseVisualStyleBackColor = true;
            this.btnServerBaglantiyiKes.Click += new System.EventHandler(this.btnServerBaglantiyiKes_Click);
            // 
            // lbnClientUsername
            // 
            this.lbnClientUsername.AutoSize = true;
            this.lbnClientUsername.Location = new System.Drawing.Point(55, 39);
            this.lbnClientUsername.Name = "lbnClientUsername";
            this.lbnClientUsername.Size = new System.Drawing.Size(59, 23);
            this.lbnClientUsername.TabIndex = 7;
            this.lbnClientUsername.Text = "label4";
            // 
            // lbnBaglantiDurum
            // 
            this.lbnBaglantiDurum.AutoSize = true;
            this.lbnBaglantiDurum.Location = new System.Drawing.Point(620, 39);
            this.lbnBaglantiDurum.Name = "lbnBaglantiDurum";
            this.lbnBaglantiDurum.Size = new System.Drawing.Size(59, 23);
            this.lbnBaglantiDurum.TabIndex = 17;
            this.lbnBaglantiDurum.Text = "label3";
            // 
            // lbn5
            // 
            this.lbn5.AutoSize = true;
            this.lbn5.Location = new System.Drawing.Point(533, 39);
            this.lbn5.Name = "lbn5";
            this.lbn5.Size = new System.Drawing.Size(81, 23);
            this.lbn5.TabIndex = 16;
            this.lbn5.Text = "Durum: ";
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.lbnBaglantiDurum);
            this.Controls.Add(this.lbn5);
            this.Controls.Add(this.lbnClientUsername);
            this.Controls.Add(this.btnServerBaglantiyiKes);
            this.Controls.Add(this.txtServerMesajlar);
            this.Controls.Add(this.btnServerGonder);
            this.Controls.Add(this.txtServerMesaj);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ChatServer";
            this.Text = "ChatServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServer_FormClosing);
            this.Load += new System.EventHandler(this.ChatServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtServerMesaj;
        private System.Windows.Forms.Button btnServerGonder;
        private System.Windows.Forms.TextBox txtServerMesajlar;
        private System.Windows.Forms.Button btnServerBaglantiyiKes;
        private System.Windows.Forms.Label lbnClientUsername;
        private System.Windows.Forms.Label lbnBaglantiDurum;
        private System.Windows.Forms.Label lbn5;
    }
}
