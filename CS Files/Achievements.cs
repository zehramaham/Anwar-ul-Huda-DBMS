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
    public partial class Achievements : Form
    {
        public Achievements()
        {
            InitializeComponent();
        }

        private void Achievements_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Achievements] VALUES (@idHosteller, @Name, @DateofAckn)", StartForm.con);
                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DateofAckn", dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DateofAckn", dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Search.Edittable == 0)
            {
                MonthlySchoolView f8 = new MonthlySchoolView();
                f8.ShowDialog();
            }
            else
            {
                MonthlySchool f8 = new MonthlySchool();
                f8.ShowDialog();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OverallSchool f7 = new OverallSchool();
            f7.ShowDialog();
        }

        private void Achievements_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
