using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace UTS2
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
         
        private void IsiPatient() 
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatName from PasTab", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatName", typeof(string));
            dt.Load(rdr);
            PatientCb.ValueMember = "PatName";
            PatientCb.DataSource = dt;
            Con.Close();

            
        }
        private void IsiPerawatan()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TreatName from TreatmentTab", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TreatName", typeof(string));
            dt.Load(rdr);
            TreatmentCb.ValueMember = "TreatName";
            TreatmentCb.DataSource = dt;
            Con.Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            IsiPatient();
            IsiPerawatan();
            populate();
        }

        void populate()
        {
            Pasien Pat = new Pasien();
            string query = "select * from AppointmentTab";
            DataSet ds = Pat.ShowPatient(query);
            AppointmentDGV.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into AppointmentTab values('" + PatientCb.SelectedValue.ToString() + "','" + TreatmentCb.SelectedValue.ToString() + "','" + Date.Value.Date + "','"+ Time.Value.TimeOfDay +"')";
            Pasien Pat = new Pasien();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Appointment Sucesfully Recorded");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientCb.SelectedValue = AppointmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentCb.SelectedValue =AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            string pat= AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();

            if (pat =="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pasien Pat = new Pasien();
            if (key == 0)
            {
                MessageBox.Show("Select the Appointment to Cancel");
            }
            else
            {
                try
                {

                    string query = "Delete from AppointmentTab where Apid=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Appointement Succesfully Deleted");
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
                MessageBox.Show("Select the Patient");
            }
            else
            {
                try
                {

                    string query = "Update AppointmentTab set Patient='" + PatientCb.SelectedValue.ToString() + "',Treatment='" + TreatmentCb.SelectedValue.ToString() + "',ApDate='" + Date.Value.Date + "',ApTime='" + Time.Value.TimeOfDay + "'where Apid=" + key + "";

                    Pat.DeletePatient(query);
                    MessageBox.Show("Appointment Sucesfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
