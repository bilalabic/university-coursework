namespace DemoChatSocketApp
{
    partial class Main
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
            this.btnServerCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClientCon = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtUsername = new System.Windows.Forms.MaskedTextBox();
            this.mtxtIP = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPort = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnServerCreate
            // 
            this.btnServerCreate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerCreate.Location = new System.Drawing.Point(81, 296);
            this.btnServerCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnServerCreate.Name = "btnServerCreate";
            this.btnServerCreate.Size = new System.Drawing.Size(162, 54);
            this.btnServerCreate.TabIndex = 0;
            this.btnServerCreate.Text = "Sunucu Oluştur";
            this.btnServerCreate.UseVisualStyleBackColor = true;
            this.btnServerCreate.Click += new System.EventHandler(this.btnServerCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kulanıcı Adı: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Adres: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 239);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port: ";
            // 
            // btnClientCon
            // 
            this.btnClientCon.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientCon.Location = new System.Drawing.Point(252, 296);
            this.btnClientCon.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientCon.Name = "btnClientCon";
            this.btnClientCon.Size = new System.Drawing.Size(162, 54);
            this.btnClientCon.TabIndex = 8;
            this.btnClientCon.Text = "Bağlan";
            this.btnClientCon.UseVisualStyleBackColor = true;
            this.btnClientCon.Click += new System.EventHandler(this.btnClientCon_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(471, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "🗨️  SOCKET CHAT UYGULAMASI";
            // 
            // mtxtUsername
            // 
            this.mtxtUsername.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtUsername.Location = new System.Drawing.Point(221, 120);
            this.mtxtUsername.Name = "mtxtUsername";
            this.mtxtUsername.Size = new System.Drawing.Size(159, 30);
            this.mtxtUsername.TabIndex = 10;
            // 
            // mtxtIP
            // 
            this.mtxtIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtIP.Location = new System.Drawing.Point(221, 178);
            this.mtxtIP.Name = "mtxtIP";
            this.mtxtIP.Size = new System.Drawing.Size(159, 30);
            this.mtxtIP.TabIndex = 11;
            this.mtxtIP.ValidatingType = typeof(int);
            // 
            // mtxtPort
            // 
            this.mtxtPort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtPort.Location = new System.Drawing.Point(223, 236);
            this.mtxtPort.Mask = "0000";
            this.mtxtPort.Name = "mtxtPort";
            this.mtxtPort.Size = new System.Drawing.Size(159, 30);
            this.mtxtPort.TabIndex = 12;
            this.mtxtPort.ValidatingType = typeof(int);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 370);
            this.Controls.Add(this.mtxtPort);
            this.Controls.Add(this.mtxtIP);
            this.Controls.Add(this.mtxtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClientCon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnServerCreate);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soket Chat ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServerCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClientCon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtUsername;
        private System.Windows.Forms.MaskedTextBox mtxtIP;
        private System.Windows.Forms.MaskedTextBox mtxtPort;
    }
}


