using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Project
{
    public partial class viewQRCode : Form
    {
        SqlConnection sqlCon;

        public viewQRCode()
        {
            try
            {
                DBConnection obj = new DBConnection();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting" + ex, "View QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }


        private void btnSendQR_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
            string accountSid = "ACe4c250277e2246b7d7eca5dae175eab1";
            string authToken = "a3e79acc74aad6ca504e59b8df0c9569";
            TwilioClient.Init(accountSid, authToken);
                                   
            var to = new PhoneNumber(labelMobileNumber.Text);
            var from = new PhoneNumber("+12512748539");
            /*var mediaUrl = new[] {
                new Uri("https://dzone.com/storage/temp/8670158-qrcode-boofcv.jpg")
            }.ToList();*/

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Here is your QR Code for visiting the Hospital: " + labelqrCode.Text
               // mediaUrl: mediaUrl
                );

            //pictureBoxQR.Image.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Jpeg

            MessageBox.Show("QR Code Successfully Sent!", "Send QR Code", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void viewQRCode_Load(object sender, EventArgs e)
        {
            
        }
    }
}
