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

        }

        private void TreatmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
