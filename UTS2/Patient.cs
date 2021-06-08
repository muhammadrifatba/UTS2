using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace UTS2
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into PasTab values('" + PatNameTab.Text + "','" + PatHpTab.Text + "','" + PatAddresTab.Text + "','" + DOBDateCb.Value.Date + "','" + GenCb.SelectedItem.ToString() + "','" + PatAllergiesTab.Text + "')";
            Pasien Pat = new Pasien();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Patient Sucesfully Added");
                populate();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        void populate()
        {
            Pasien Pat = new Pasien();
            string query = "select * from PasTab";
            DataSet ds = Pat.ShowPatient(query);
            PasienDGV.DataSource = ds.Tables[0];
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void PasienDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTab.Text = PasienDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatHpTab.Text = PasienDGV.SelectedRows[0].Cells[2].Value.ToString();
            PatAddresTab.Text = PasienDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenCb.SelectedItem= PasienDGV.SelectedRows[0].Cells[5].Value.ToString();
            PatAllergiesTab.Text = PasienDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (PatNameTab.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PasienDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the Patient");
            }
            else
            {
                try
                {
                    
                    string query = "Delete from PasTab where Patid=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Sucesfully Deleted");
                    populate();
                }
                catch(Exception Ex)
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
                MessageBox.Show("Select the Patient");
            }
            else
            {
                try
                {

                    string query = "Update PasTab set PatName='" + PatNameTab.Text + "',PatHp='" + PatHpTab.Text + "',PatAddress='" + PatAddresTab.Text + "',PatDOB='" + DOBDateCb.Value.Date + "',PatGender='" + GenCb.SelectedItem.ToString()+ "',PatAllergies='" + PatAllergiesTab.Text + "'where Patid=" + key + "";
                    
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Sucesfully Updated");
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

        private void label4_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }
    }
}
