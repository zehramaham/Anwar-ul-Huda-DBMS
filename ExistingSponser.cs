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

namespace WindowsFormsApp1
{
    public partial class ExistingSponser : Form
    {
        public static int Edittable = 0;
        public static string sponserID = "";

        public ExistingSponser()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Edittable = 1;
            //sponserID = ESponserDGV.Rows[0].Cells[0].Value.ToString();
            this.Hide();
            NewSponser f2 = new NewSponser();
            f2.ShowDialog();
        }

        private void ExistingSponser_Load(object sender, EventArgs e)
        {
            //ESponserDGV.Enabled = false;
            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from Sponser", StartForm.con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            ESponserDGV.DataSource = dt;
            StartForm.con.Close();
        }

        private void ESponserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ESponserDGV.Rows[e.RowIndex];

                sponserID = row.Cells["idSponser"].Value.ToString();
            }*/
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Edittable = 0;
            this.Hide();
            Type f1 = new Type();
            f1.ShowDialog();
        }

        private void ESponserDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Edittable = 1;
            if(this.ESponserDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.ESponserDGV.CurrentRow.Selected = true;
                sponserID = this.ESponserDGV.Rows[e.RowIndex].Cells["idSponser"].FormattedValue.ToString();
                this.Hide();
                NewSponser f2 = new NewSponser();
                f2.ShowDialog();
            }
        }

        private void ESponserDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //sponserID = ESponserDGV.Rows[e.RowIndex].Cells["idSponser"].FormattedValue.ToString();
        }

        private void ExistingSponser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
