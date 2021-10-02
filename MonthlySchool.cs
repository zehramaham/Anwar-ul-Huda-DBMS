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
    public partial class MonthlySchool : Form
    {
        public MonthlySchool()
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
            Achievements f7 = new Achievements();
            f7.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MonthlySchool_Load(object sender, EventArgs e)
        {
            MonthCB.Items.Add("January");
            MonthCB.Items.Add("February");
            MonthCB.Items.Add("March");
            MonthCB.Items.Add("April");
            MonthCB.Items.Add("May");
            MonthCB.Items.Add("June");
            MonthCB.Items.Add("July");
            MonthCB.Items.Add("August");
            MonthCB.Items.Add("September");
            MonthCB.Items.Add("October");
            MonthCB.Items.Add("November");
            MonthCB.Items.Add("December");

            SubjectCB.Items.Add("English");
            SubjectCB.Items.Add("Mathematics");
            SubjectCB.Items.Add("Urdu");
            SubjectCB.Items.Add("Social Studies");
            SubjectCB.Items.Add("Science");
            SubjectCB.Items.Add("Computer Science");
            SubjectCB.Items.Add("Islamiyat");
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [MonthlyTestGrades] VALUES (@idHosteller, @Month, @Subject, @Marks)");
            cmd.Connection = StartForm.con;

            if(Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@Month", MonthCB.Text);
                cmd.Parameters.AddWithValue("@Subject", SubjectCB.Text);
                cmd.Parameters.AddWithValue("@Marks", textBox1.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@Month", MonthCB.Text);
                cmd.Parameters.AddWithValue("@Subject", SubjectCB.Text);
                cmd.Parameters.AddWithValue("@Marks", textBox1.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();
            }
        }

        private void MonthlySchool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
