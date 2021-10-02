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
    public partial class AreasOfConcernView : Form
    {
        public AreasOfConcernView()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void AreasOfConcernView_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select [ComplainFrom], [Regarding], [ConcernNum], [Complain]  from [AreaOfConcern] where Hosteller_idHosteller = @idHosteller ORDER BY ComplainFrom, Regarding, ConcernNum ASC", StartForm.con);
            adapt.SelectCommand.Parameters.AddWithValue("@idHosteller", Search.studentID);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            StartForm.con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            MedicalHistory f9 = new MedicalHistory();
            f9.ShowDialog();
        }

        private void AreasOfConcernView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
