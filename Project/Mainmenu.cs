using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Mainmenu : Form
    {

        SqlConnection sqlCon;
        public Mainmenu()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 55)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 200;
                PanelTransition.ShowSync(sidemenu);
                LogoTransition.ShowSync(logo);


            }
            else
            {
                LogoTransition.Hide(logo);
                sidemenu.Visible = false;
                sidemenu.Width = 55;
                PanelTransition.ShowSync(sidemenu);

            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            mainMenuPanel.Visible = false;
            displayPanelView.Visible = true;
            displayPanelAdd.Visible = false;
            displayPanelUpdate.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mainMenuPanel.Visible = false;
            displayPanelAdd.Visible = true;
            displayPanelView.Visible = false;
            displayPanelUpdate.Visible = false;
        }

        private void btnUpdatee_Click(object sender, EventArgs e)
        {
            mainMenuPanel.Visible = false;
            displayPanelUpdate.Visible = true;
            displayPanelAdd.Visible = false;
            displayPanelView.Visible = false;

        }

        private void displayPanelAdd_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select regID from PatientDetails", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";
                bool NumberofRows = dr.HasRows;
                if (NumberofRows)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString();
                    }
                    string idString = id.Substring(1);
                    int CTR = Int32.Parse(idString);
                    if (CTR >= 1 && CTR < 9)
                    {
                        CTR = CTR + 1;
                        txtRegID.Text = "P00" + CTR;
                    }
                    else if (CTR >= 9 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        txtRegID.Text = "P0" + CTR;
                    }
                    else if (CTR >= 99)
                    {
                        CTR = CTR + 1;
                        txtRegID.Text = "P" + CTR;
                    }

                }
                else
                {
                    txtRegID.Text = "P001";
                }
                dr.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error" + e1, "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFName.Text != "" && txtLName.Text != "" && txtGName.Text != "" && txtAdate.Text != "" && txtGName.Text != "" && txtGAddress.Text != "" && txtGNumber.Text != "")
                {
                    try
                    {
                        string qrCombination = txtRegID.Text + txtFName.Text + txtLName.Text + txtPAddress.Text + txtPNIC.Text + txtAdate.Text + txtDdate.Text + txtGName.Text + txtGAddress.Text;
                        SqlCommand cmd1 = new SqlCommand("Insert into PatientDetails (regID, FName, LName, Address, NIC, AdmissionDate, DischargeDate, Gname, Gaddress, GMobile, QRCode, VisitorStatus) values ('" + txtRegID.Text + "', '" + txtFName.Text + "', '" + txtLName.Text + "', '" + txtPAddress.Text + "', '" +
                            txtPNIC.Text + "', '" + txtAdate.Text + "', '" + txtDdate.Text + "', '" + txtGName.Text + "', '" + txtGAddress.Text + "', '" + txtGNumber.Text + "', '" + qrCombination + "', 'Allowed');");

                        cmd1.Connection = sqlCon;
                        cmd1.ExecuteNonQuery();


                        MessageBox.Show("Patient Successfully Added!", "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Inserting Data" + ex, "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the required details.", "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            resetViewGrid();            
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            viewRegID.Enabled = false;

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from PatientDetails where regID='" + viewRegID.Text + "'");
                cmd.Connection = sqlCon;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    viewFName.Text = dr[1].ToString();
                    viewLName.Text = dr[2].ToString();
                    viewPAddress.Text = dr[3].ToString();
                    viewPNIC.Text = dr[4].ToString();
                    viewADate.Text = dr[5].ToString();
                    viewDDate.Text = dr[6].ToString();
                    viewGName.Text = dr[7].ToString();
                    viewGAddress.Text = dr[8].ToString();
                    viewGMobile.Text = dr[9].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Searching Data" + ex, "Update Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            viewFName.Text = "";
            viewLName.Text = "";
            viewPAddress.Text = "";
            viewPNIC.Text = "";
            viewADate.Text = "";
            viewDDate.Text = "";
            viewGName.Text = "";
            viewGAddress.Text = "";
            viewGMobile.Text = "";

            viewRegID.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFName.Text != "" && txtLName.Text != "" && txtGName.Text != "" && txtAdate.Text != "" && txtGName.Text != "" && txtGAddress.Text != "" && txtGNumber.Text != "")
                    try
                    {
                        string qrCombination = txtRegID.Text + txtFName.Text + txtLName.Text + txtPAddress.Text + txtPNIC.Text + txtAdate.Text + txtDdate.Text + txtGName.Text + txtGAddress.Text;
                        SqlCommand cmd = new SqlCommand("Update PatientDetails set FName = '" + viewFName.Text + "', LName = '" + viewLName.Text + "', Address = '" + viewPAddress.Text + "', NIC = '" +
                            viewPNIC.Text + "', AdmissionDate = '" + viewADate.Text + "', DischargeDate = '" + viewDDate.Text + "', GName = '" + viewGName.Text + "', GAddress = '"
                            + viewGAddress.Text + "', GMobile = '" + viewGMobile.Text + "', QRCode = '" + qrCombination + "' where regID = '" + viewRegID.Text + "'", sqlCon);

                        int numberOfRecords = cmd.ExecuteNonQuery();
                        if (numberOfRecords > 0)
                        {
                            MessageBox.Show("Record Updated", "Update Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Record", "Update Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Updating Data" + ex, "Update Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    resetViewGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Update Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
       

        private void btnQRCodeGen_Click(object sender, EventArgs e)
        {


        }


        private void btnViewQR_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatient.SelectedRows.Count > 0)
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(dataGridViewPatient.SelectedRows[0].Cells[10].Value.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);

                viewQRCode obj = new viewQRCode();
                obj.pictureBoxQR.Image = code.GetGraphic(5);

                string qrCode = dataGridViewPatient.SelectedRows[0].Cells[10].Value.ToString().Trim();
                obj.labelqrCode.Text = qrCode;

                string mobileNumber = dataGridViewPatient.SelectedRows[0].Cells[9].Value.ToString().Trim();
                obj.labelMobileNumber.Text = mobileNumber;

                string patientName = dataGridViewPatient.SelectedRows[0].Cells[1].Value.ToString().Trim() + " " + dataGridViewPatient.SelectedRows[0].Cells[2].Value.ToString().Trim();
                obj.labelPatientQR.Text = "QR Code of " + patientName;

                obj.Show();
            }
        }


        private void btnDischarge_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatient.SelectedRows.Count > 0)
            {
                if (dataGridViewPatient.SelectedRows[0].Cells[11].Value.ToString().Trim() == "Allowed")
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE PatientDetails SET VisitorStatus = 'Disabled' WHERE regID = '" + dataGridViewPatient.SelectedRows[0].Cells[0].Value.ToString() + "';", sqlCon);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Patient " + dataGridViewPatient.SelectedRows[0].Cells[1].Value.ToString().Trim() + " " + dataGridViewPatient.SelectedRows[0].Cells[2].Value.ToString().Trim() + " (" + dataGridViewPatient.SelectedRows[0].Cells[0].Value.ToString().Trim() + ") has been discharged.", "Discharge Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetViewGrid();
                }
                else
                {
                    MessageBox.Show("Patient is already discharged.", "Discharge Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void displayPanelView_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewPatient.Columns[0].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[1].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[2].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[3].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[4].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[5].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[6].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[7].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[8].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[9].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[10].HeaderCell.Style.Font = new Font("Century Gothic", 9);
            dataGridViewPatient.Columns[11].HeaderCell.Style.Font = new Font("Century Gothic", 9);

            dataGridViewPatient.Columns[0].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[1].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[2].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[3].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[4].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[5].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[6].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[7].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[8].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[9].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[10].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridViewPatient.Columns[11].HeaderCell.Style.BackColor = Color.LightGray;

            dataGridViewPatient.Columns[0].HeaderText = "Register ID";
            dataGridViewPatient.Columns[1].HeaderText = "First Name";
            dataGridViewPatient.Columns[2].HeaderText = "Last Name";
            dataGridViewPatient.Columns[3].HeaderText = "Address";
            dataGridViewPatient.Columns[4].HeaderText = "NIC";
            dataGridViewPatient.Columns[5].HeaderText = "Admission Date";
            dataGridViewPatient.Columns[6].HeaderText = "Discharge Date";
            dataGridViewPatient.Columns[7].HeaderText = "Guardian Name";
            dataGridViewPatient.Columns[8].HeaderText = "Guardian Address";
            dataGridViewPatient.Columns[9].HeaderText = "Guardian Mobile";
            dataGridViewPatient.Columns[10].HeaderText = "QR Code";
            dataGridViewPatient.Columns[11].HeaderText = "Visitor Status";

            dataGridViewPatient.Columns[10].Visible = false;

            dataGridViewPatient.EnableHeadersVisualStyles = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbFilter.Text == "Name")
                {
                    SqlCommand cmd = new SqlCommand("SELECT regID, FName, LName, Address, NIC, AdmissionDate, DischargeDate, Gname, Gaddress, GMobile, QRCode, VisitorStatus FROM PatientDetails WHERE FName LIKE '%" + txtSearch.Text + "%' OR LName LIKE '%" + txtSearch.Text + "%'", sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "PatientDetails");

                    dataGridViewPatient.DataSource = ds;
                    dataGridViewPatient.DataMember = "PatientDetails";
                }
                else if (cbFilter.Text == "NIC")
                {
                    SqlCommand cmd = new SqlCommand("SELECT regID, FName, LName, Address, NIC, AdmissionDate, DischargeDate, Gname, Gaddress, GMobile, QRCode, VisitorStatus FROM PatientDetails WHERE NIC LIKE '%" + txtSearch.Text + "%'", sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "PatientDetails");

                    dataGridViewPatient.DataSource = ds;
                    dataGridViewPatient.DataMember = "PatientDetails";
                }
                else if (cbFilter.Text == "Contact Number")
                {
                    SqlCommand cmd = new SqlCommand("SELECT regID, FName, LName, Address, NIC, AdmissionDate, DischargeDate, Gname, Gaddress, GMobile, QRCode, VisitorStatus FROM PatientDetails WHERE GMobile LIKE '%" + txtSearch.Text + "%'", sqlCon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "PatientDetails");

                    dataGridViewPatient.DataSource = ds;
                    dataGridViewPatient.DataMember = "PatientDetails";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            mainMenuPanel.Visible = true;
            resetViewGrid();        
        }

        private void dataGridViewPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void resetViewGrid()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT regID, FName, LName, Address, NIC, AdmissionDate, DischargeDate, Gname, Gaddress, GMobile, QRCode, VisitorStatus FROM PatientDetails", sqlCon);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();

                da1.Fill(ds1, "PatientDetails");

                dataGridViewPatient.DataSource = ds1;
                dataGridViewPatient.DataMember = "PatientDetails";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
