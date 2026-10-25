namespace DemoChatSocketApp
{
    partial class ChatClient
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
            this.txtClientMesajlar = new System.Windows.Forms.TextBox();
            this.btnClientGonder = new System.Windows.Forms.Button();
            this.txtClientMesaj = new System.Windows.Forms.TextBox();
            this.lbnServerUsername = new System.Windows.Forms.Label();
            this.lbn5 = new System.Windows.Forms.Label();
            this.lbnBaglantiDurum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClientMesajlar
            // 
            this.txtClientMesajlar.Location = new System.Drawing.Point(56, 65);
            this.txtClientMesajlar.Multiline = true;
            this.txtClientMesajlar.Name = "txtClientMesajlar";
            this.txtClientMesajlar.ReadOnly = true;
            this.txtClientMesajlar.Size = new System.Drawing.Size(601, 410);
            this.txtClientMesajlar.TabIndex = 9;
            // 
            // btnClientGonder
            // 
            this.btnClientGonder.Location = new System.Drawing.Point(490, 481);
            this.btnClientGonder.Name = "btnClientGonder";
            this.btnClientGonder.Size = new System.Drawing.Size(167, 41);
            this.btnClientGonder.TabIndex = 8;
            this.btnClientGonder.Text = "Gönder";
            this.btnClientGonder.UseVisualStyleBackColor = true;
            this.btnClientGonder.Click += new System.EventHandler(this.btnClientGonder_Click);
            // 
            // txtClientMesaj
            // 
            this.txtClientMesaj.Location = new System.Drawing.Point(56, 482);
            this.txtClientMesaj.Multiline = true;
            this.txtClientMesaj.Name = "txtClientMesaj";
            this.txtClientMesaj.Size = new System.Drawing.Size(428, 40);
            this.txtClientMesaj.TabIndex = 7;
            this.txtClientMesaj.TextChanged += new System.EventHandler(this.txtClientMesaj_TextChanged);
            this.txtClientMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientMesaj_KeyPress);
            // 
            // lbnServerUsername
            // 
            this.lbnServerUsername.AutoSize = true;
            this.lbnServerUsername.Location = new System.Drawing.Point(52, 27);
            this.lbnServerUsername.Name = "lbnServerUsername";
            this.lbnServerUsername.Size = new System.Drawing.Size(59, 23);
            this.lbnServerUsername.TabIndex = 13;
            this.lbnServerUsername.Text = "label4";
            // 
            // lbn5
            // 
            this.lbn5.AutoSize = true;
            this.lbn5.Location = new System.Drawing.Point(490, 27);
            this.lbn5.Name = "lbn5";
            this.lbn5.Size = new System.Drawing.Size(81, 23);
            this.lbn5.TabIndex = 14;
            this.lbn5.Text = "Durum: ";
            // 
            // lbnBaglantiDurum
            // 
            this.lbnBaglantiDurum.AutoSize = true;
            this.lbnBaglantiDurum.Location = new System.Drawing.Point(577, 27);
            this.lbnBaglantiDurum.Name = "lbnBaglantiDurum";
            this.lbnBaglantiDurum.Size = new System.Drawing.Size(59, 23);
            this.lbnBaglantiDurum.TabIndex = 15;
            this.lbnBaglantiDurum.Text = "label3";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 545);
            this.Controls.Add(this.lbnBaglantiDurum);
            this.Controls.Add(this.lbn5);
            this.Controls.Add(this.lbnServerUsername);
            this.Controls.Add(this.txtClientMesajlar);
            this.Controls.Add(this.btnClientGonder);
            this.Controls.Add(this.txtClientMesaj);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChatClient";
            this.Text = "ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClient_FormClosing);
            this.Load += new System.EventHandler(this.ChatClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtClientMesajlar;
        private System.Windows.Forms.Button btnClientGonder;
        private System.Windows.Forms.TextBox txtClientMesaj;
        private System.Windows.Forms.Label lbnServerUsername;
        private System.Windows.Forms.Label lbn5;
        private System.Windows.Forms.Label lbnBaglantiDurum;
    }
}
