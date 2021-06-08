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
using System.IO;

namespace UTS2
{
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }
        
        ConnectionString MyCon = new ConnectionString();
        private void IsiPatient()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Patient from AppointmentTab", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Patient", typeof(string));
            dt.Load(rdr);
            PasId.ValueMember = "Patient";
            PasId.DataSource = dt;
            Con.Close();


        }

        private void IsiTreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TreatName from TreatmentTab", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Patient", typeof(string));
            dt.Load(rdr);
            PasId.ValueMember = "Patient";
            PasId.DataSource = dt;
            Con.Close();


        }



        private void GetTreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from AppointmentTab where Patient='" + PasId.SelectedValue.ToString() + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            SqlDataReader rdr;
            foreach (DataRow dr in dt.Rows)
            {
                TreatmentTab.Text = dr["Treatment"].ToString();
            }
            
            
            Con.Close();


        }

        private void GetPrice()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from TreatmentTab where TreatName='" + TreatmentTab.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            SqlDataReader rdr;
            foreach (DataRow dr in dt.Rows)
            {
                TreatCostTab.Text = dr["TreatCost"].ToString();
            }


            Con.Close();


        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Prescription_Load(object sender, EventArgs e) 
        {
            
        }

        private void PasId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTreatment();
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

        private void label8_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Appointment Appo = new Appointment();
            Appo.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void Prescription_Load_1(object sender, EventArgs e)
        {
            IsiPatient();
            populate();
        }

        private void TreatmentTab_TextChanged(object sender, EventArgs e)
        {
            GetPrice();
        }

        void populate()
        {
            Pasien Pat = new Pasien();
            string query = "select * from PrescriptionTab";
            DataSet ds = Pat.ShowPatient(query);
            PrescDGV.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into PrescriptionTab values('" + PasId.SelectedValue.ToString() + "','" + TreatmentTab.Text + "','" + TreatCostTab.Text + "', '" + MedTab.Text + "', '"+ QtyTab.Text + "')";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

               
       int key = 0;


        private void PrescDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //private void PasienDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    PatNameTab.Text = PasienDGV.SelectedRows[0].Cells[1].Value.ToString();
        //    PatHpTab.Text = PasienDGV.SelectedRows[0].Cells[2].Value.ToString();
        //    PatAddresTab.Text = PasienDGV.SelectedRows[0].Cells[3].Value.ToString();
        //    GenCb.SelectedItem = PasienDGV.SelectedRows[0].Cells[5].Value.ToString();
        //    PatAllergiesTab.Text = PasienDGV.SelectedRows[0].Cells[6].Value.ToString();
        //    if (PatNameTab.Text == "")
        //    {
        //        key = 0;
        //    }
        //    else
        //    {
        //        key = Convert.ToInt32(PasienDGV.SelectedRows[0].Cells[0].Value.ToString());
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void DelButt_Click(object sender, EventArgs e)
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

                    string query = "Delete from PrescriptionTab where PrescId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Sucesfully Deleted");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            //Pasien Pat = new Pasien();
            //if (key == 0)
            //{
            //    MessageBox.Show("Select the Prescription to Cancel");

            //}
            //else
            //{
            //    try
            //    {

            //        string query = "Delete from PrescriptionTab where PrescId=" + key + "";
            //        Pat.DeletePatient(query);
            //        MessageBox.Show("Prescription Succesfully Deleted");
            //        populate();
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(Ex.Message);
            //    }
            //}
        }

        private void PrescDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            PasId.SelectedValue = PrescDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentTab.Text = PrescDGV.SelectedRows[0].Cells[2].Value.ToString();
            TreatCostTab.Text = PrescDGV.SelectedRows[0].Cells[3].Value.ToString();
            MedTab.Text = PrescDGV.SelectedRows[0].Cells[4].Value.ToString();
            QtyTab.Text = PrescDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (TreatmentTab.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PrescDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
