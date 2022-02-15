using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
using System.Data.SqlClient;

namespace Project
{
    public partial class SecurityMenu : Form
    {

        SqlConnection sqlCon;
        public SecurityMenu()
        {
            try
            {
                DBConnection obj = new DBConnection();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting" + ex, "Customer Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBoxWebCam.Image = (Image)eventArgs.Frame.Clone();
        }

        private void SecurityMenu_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBoxCamSource.Items.Add(Device.Name);
            }
            comboBoxCamSource.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();

            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBoxCamSource.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();

            timer1.Start();

        }

        private void SecurityMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBoxWebCam.Image);
            try
            {
                string decoded = result.ToString();          
                SqlCommand cmd = new SqlCommand("SELECT QRCode FROM PatientDetails WHERE QRCode = '" + decoded + "' AND VisitorStatus = 'Allowed';");
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (decoded == dr[0].ToString())
                    {
                        dr.Close();
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Project.Properties.Resources.Success);
                        player.Play();
                        labelResponse.Text = "Visitor Allowed";
                        labelResponse.ForeColor = System.Drawing.Color.Green;

                        SqlCommand cmd1 = new SqlCommand("UPDATE PatientDetails SET VisitorStatus = 'Disabled' WHERE QRCode = '" + decoded + "';", sqlCon);
                        cmd1.ExecuteNonQuery();


                        await PutTaskDelay();
                        SqlCommand cmd2 = new SqlCommand("UPDATE PatientDetails SET VisitorStatus = 'Allowed' WHERE QRCode = '" + decoded + "'", sqlCon);
                        cmd2.ExecuteNonQuery();
                    }     
                }
                else
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Project.Properties.Resources.Error);
                    player.Play();
                    labelResponse.Text = "Visitor Denied";
                    labelResponse.ForeColor = System.Drawing.Color.Red;
                }
                dr.Close();     
            }
            catch (Exception ex)
            {

            }
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(10000);
        }
    }
}
