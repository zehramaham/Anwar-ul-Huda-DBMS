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
    public partial class AchievementsView : Form
    {
        public AchievementsView()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonthlySchoolView f8 = new MonthlySchoolView();
            f8.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OverallSchool f7 = new OverallSchool();
            f7.ShowDialog();
        }

        private void AchievementsView_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select Name as Achievement, DateofAckn as [Recieving Date] from [Achievements] where Hosteller_idHosteller = @idHosteller", StartForm.con);
            adapt.SelectCommand.Parameters.AddWithValue("@idHosteller", Search.studentID);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            StartForm.con.Close();
        }

        private void AchievementsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
