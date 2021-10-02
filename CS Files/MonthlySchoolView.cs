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
    public partial class MonthlySchoolView : Form
    {
        public MonthlySchoolView()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicalHistory f9 = new MedicalHistory();
            f9.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AchievementsView f7 = new AchievementsView();
            f7.ShowDialog();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MonthlySchoolView_Load(object sender, EventArgs e)
        {
            MSchoolViewGB.Enabled = false;

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select [Month_2], [Subject], [Marks] from [MonthlyTestGrades] where SchoolPerformance_Hosteller_idHosteller = @idHosteller", StartForm.con);
            adapt.SelectCommand.Parameters.AddWithValue("@idHosteller", Search.studentID);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            StartForm.con.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MonthlySchoolView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
