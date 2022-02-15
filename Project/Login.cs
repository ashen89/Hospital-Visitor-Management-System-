using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Login : Form
    {

        SqlConnection sqlCon;
        public Login()
        {
            try
            {
                DBConnection obj = new DBConnection();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting" + ex, "Login Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login__Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                      
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
   

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {              
                bool valid = true;
                if (string.IsNullOrEmpty(txtUsername.Text) || (string.IsNullOrEmpty(txtPassword.Text)))
                {
                    MessageBox.Show("Username and Password cannot be empty", "Login Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }

                if (valid)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT userType FROM UserDetails WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "';");
                        cmd.Connection = sqlCon;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr[0].ToString() == "Security")
                            {
                                this.Hide();
                                SecurityMenu obj = new SecurityMenu();
                                obj.Show();                              
                                dr.Close();
                            }
                            else if (dr[0].ToString() == "Employee")
                            {
                                this.Hide();
                                Mainmenu obj = new Mainmenu();
                                obj.Show();                              
                                dr.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                        dr.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Login Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 

        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
