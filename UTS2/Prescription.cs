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
            SqlCommand cmd = new SqlCommand("select Patient from AppointmenTab", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Patient", typeof(string));
            dt.Load(rdr);
            PasId.ValueMember = "Patient";
            PasId.DataSource = dt;
            Con.Close();


        }


        private void GetPatientName()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Patient from PasTab where PatId="+PasId.SelectedValue.ToString()+"", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            SqlDataReader rdr;
            foreach(DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PatName"].ToString();
            }
            
            
            Con.Close();


        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Prescription_Load(object sender, EventArgs e)
        {
            IsiPatient();
        }

        private void PasId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPatientName();
        }
    }
}
