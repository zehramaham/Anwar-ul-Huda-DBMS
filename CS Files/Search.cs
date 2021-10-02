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
    public partial class Search : Form
    {
        public static int Edittable = 1;
        public static string studentID;
        public static int ForSponser = 0;

        public Search()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select distinct nameHosteller from Hosteller", StartForm.con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            NameCB.ValueMember = "nameHosteller";
            NameCB.DataSource = dt;
            StartForm.con.Close();
            studentID = "";
            BasicInfo.studentID = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Edittable = 0;
            this.Hide();
            BasicInfo f3 = new BasicInfo();
            f3.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Edittable = 1;
            this.Hide();
            BasicInfo f3 = new BasicInfo();
            f3.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Type f1 = new Type();
            f1.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ForSponser = 1;
            this.Hide();
            InfoForSponser f1 = new InfoForSponser();
            f1.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (NameCB.Text == "")
            {
                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select * from hosteller", StartForm.con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                SearchDGV.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select * from hosteller where nameHosteller = '" + NameCB.Text + "'", StartForm.con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                SearchDGV.DataSource = dt;
                StartForm.con.Close();
            }

        }

        private void SearchDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SearchDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.SearchDGV.CurrentRow.Selected = true;
                studentID = this.SearchDGV.Rows[e.RowIndex].Cells["idHosteller"].FormattedValue.ToString();

            }
        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SearchDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
