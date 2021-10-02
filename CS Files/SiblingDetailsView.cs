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

namespace WindowsFormsApp1
{
    public partial class SiblingDetailsView : Form
    {
        public SiblingDetailsView()
        {
            InitializeComponent();
        }

        private void SiblingDetailsView_Load(object sender, EventArgs e)
        {
            SiblingViewGB.Enabled = false;

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select [nameSibling], [LivingAtHostel], [Gender], [DOBSibling] from [HostellerSibling] where Hosteller_idHosteller = @idHosteller", StartForm.con);
            adapt.SelectCommand.Parameters.AddWithValue("@idHosteller", Search.studentID);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            StartForm.con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuardianDetails f4 = new GuardianDetails();
            f4.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hostel_Etiquette f6 = new Hostel_Etiquette();
            f6.ShowDialog();
        }
    }
}
