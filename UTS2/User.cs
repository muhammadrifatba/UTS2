using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTS2
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        void populate()
        {
            Pasien Pat = new Pasien();
            string query = "select * from UserTab";
            DataSet ds = Pat.ShowPatient(query);
            UserDGV.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into UserTab values('" + UsNameTab.Text + "'," + UsPassw.Text + ",'" + UsPassw.Text + "')";
            Pasien Pat = new Pasien();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("User Sucesfully Added");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsNameTab.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UsPassw.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            UsPhoneTab.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();


            if (UsNameTab.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the User to Delete");
            }
            else
            {
                try
                {

                    string query = "Delete from UserTab where Ud=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("User Succesfully Deleted");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the User");
            }
            else
            {
                try
                {

                    string query = "Update UserTab set Uname='" + UsNameTab.Text + "',Upass=" + UsPassw.Text + ",Uhp='" + UsPhoneTab.Text + "'where Ud=" + key + ";";

                    Pat.DeletePatient(query);
                    MessageBox.Show("User Sucesfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }
    }
}
