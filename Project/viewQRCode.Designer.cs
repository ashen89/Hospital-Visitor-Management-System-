namespace Project
{
    partial class viewQRCode
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
            this.btnSendQR = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.labelPatientQR = new System.Windows.Forms.Label();
            this.labelMobileNumber = new System.Windows.Forms.Label();
            this.labelqrCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendQR
            // 
            this.btnSendQR.Activecolor = System.Drawing.Color.Gray;
            this.btnSendQR.BackColor = System.Drawing.Color.Silver;
            this.btnSendQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendQR.BorderRadius = 0;
            this.btnSendQR.ButtonText = "Send QR Code";
            this.btnSendQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendQR.DisabledColor = System.Drawing.Color.Gray;
            this.btnSendQR.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSendQR.Iconimage = null;
            this.btnSendQR.Iconimage_right = null;
            this.btnSendQR.Iconimage_right_Selected = null;
            this.btnSendQR.Iconimage_Selected = null;
            this.btnSendQR.IconMarginLeft = 0;
            this.btnSendQR.IconMarginRight = 0;
            this.btnSendQR.IconRightVisible = true;
            this.btnSendQR.IconRightZoom = 0D;
            this.btnSendQR.IconVisible = true;
            this.btnSendQR.IconZoom = 90D;
            this.btnSendQR.IsTab = false;
            this.btnSendQR.Location = new System.Drawing.Point(228, 408);
            this.btnSendQR.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSendQR.Name = "btnSendQR";
            this.btnSendQR.Normalcolor = System.Drawing.Color.Silver;
            this.btnSendQR.OnHovercolor = System.Drawing.Color.Gray;
            this.btnSendQR.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSendQR.selected = false;
            this.btnSendQR.Size = new System.Drawing.Size(237, 74);
            this.btnSendQR.TabIndex = 12;
            this.btnSendQR.Text = "Send QR Code";
            this.btnSendQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendQR.Textcolor = System.Drawing.Color.Black;
            this.btnSendQR.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendQR.Click += new System.EventHandler(this.btnSendQR_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxQR.Location = new System.Drawing.Point(176, 81);
            this.pictureBoxQR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(341, 308);
            this.pictureBoxQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxQR.TabIndex = 0;
            this.pictureBoxQR.TabStop = false;
            // 
            // labelPatientQR
            // 
            this.labelPatientQR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPatientQR.AutoSize = true;
            this.labelPatientQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPatientQR.Location = new System.Drawing.Point(237, 27);
            this.labelPatientQR.Name = "labelPatientQR";
            this.labelPatientQR.Size = new System.Drawing.Size(129, 25);
            this.labelPatientQR.TabIndex = 13;
            this.labelPatientQR.Text = "Patient Name";
            // 
            // labelMobileNumber
            // 
            this.labelMobileNumber.AutoSize = true;
            this.labelMobileNumber.Location = new System.Drawing.Point(31, 179);
            this.labelMobileNumber.Name = "labelMobileNumber";
            this.labelMobileNumber.Size = new System.Drawing.Size(101, 17);
            this.labelMobileNumber.TabIndex = 14;
            this.labelMobileNumber.Text = "mobile number";
            this.labelMobileNumber.Visible = false;
            // 
            // labelqrCode
            // 
            this.labelqrCode.AutoSize = true;
            this.labelqrCode.Location = new System.Drawing.Point(31, 229);
            this.labelqrCode.Name = "labelqrCode";
            this.labelqrCode.Size = new System.Drawing.Size(56, 17);
            this.labelqrCode.TabIndex = 15;
            this.labelqrCode.Text = "qr code";
            this.labelqrCode.Visible = false;
            // 
            // viewQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(675, 514);
            this.Controls.Add(this.labelqrCode);
            this.Controls.Add(this.labelMobileNumber);
            this.Controls.Add(this.labelPatientQR);
            this.Controls.Add(this.btnSendQR);
            this.Controls.Add(this.pictureBoxQR);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "viewQRCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View QR Code";
            this.Load += new System.EventHandler(this.viewQRCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton btnSendQR;
        public System.Windows.Forms.PictureBox pictureBoxQR;
        public System.Windows.Forms.Label labelPatientQR;
        public System.Windows.Forms.Label labelMobileNumber;
        public System.Windows.Forms.Label labelqrCode;
    }
}