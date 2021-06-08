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
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into TreatmentTab values('" + TreatmentNameTab.Text + "'," + TreatmentCostTab.Text + ",'" + TreatmentDesc.Text + "')";
            Pasien Pat = new Pasien();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Treatment Sucesfully Added");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void populate()
        {
            Pasien Pat = new Pasien();
            string query = "select * from TreatmentTab";
            DataSet ds = Pat.ShowPatient(query);
            TreatmentDGV.DataSource = ds.Tables[0];
        }

        private void Treatment_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the Treatment");
            }
            else
            {
                try
                {

                    string query = "Update TreatmentTab set TreatName='" + TreatmentNameTab.Text + "',TreatDesc='" + TreatmentDesc.Text + "',TreatCost='" + TreatmentCostTab.Text + "'where Treatid=" + key + "";

                    Pat.DeletePatient(query);
                    MessageBox.Show("Treatment Sucesfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TreatmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TreatmentNameTab.Text = TreatmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentDesc.Text = TreatmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            TreatmentCostTab.Text = TreatmentDGV.SelectedRows[0].Cells[3].Value.ToString();
         
            if (TreatmentNameTab.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TreatmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
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

        private void label3_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the Treatment");
            }
            else
            {
                try
                {

                    string query = "Delete from TreatmentTab where Treatid=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Treatment Sucesfully Deleted");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
