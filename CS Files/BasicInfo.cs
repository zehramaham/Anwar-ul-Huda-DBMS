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
    public partial class BasicInfo : Form
    {
        public static string studentID = "";
        public BasicInfo()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CurrentStateCB.Checked = true;

            if (Search.Edittable == 0)
            {
                BasInfoGB.Enabled = false;
            }
            if (Type.Existing == 1) 
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Hosteller where idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    NameTB.Text = da.GetValue(1).ToString();
                    DOB.Text = da.GetValue(2).ToString();
                    DOAdmission.Text = da.GetValue(3).ToString();
                    AgeAtAdmisTB.Text = da.GetValue(4).ToString();
                    ReasonTB.Text = da.GetValue(5).ToString();
                    string temp2 = da.GetValue(6).ToString();
                    //NameTB.Text = temp2;
                    if(temp2 == "True")
                    {
                        CurrentStateCB.Checked = true;
                    } 
                    else
                    {
                        CurrentStateCB.Checked = false;
                    }
                    DODepart.Text = da.GetValue(7).ToString();
                }
                StartForm.con.Close();

            }
            else if (studentID != "")
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Hosteller where idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    NameTB.Text = da.GetValue(1).ToString();
                    DOB.Text = da.GetValue(2).ToString();
                    DOAdmission.Text = da.GetValue(3).ToString();
                    AgeAtAdmisTB.Text = da.GetValue(4).ToString();
                    ReasonTB.Text = da.GetValue(5).ToString();
                    string temp2 = da.GetValue(6).ToString();
                    //NameTB.Text = temp2;
                    if (temp2 == "True")
                    {
                        CurrentStateCB.Checked = true;
                    }
                    else
                    {
                        CurrentStateCB.Checked = false;
                    }
                    DODepart.Text = da.GetValue(7).ToString();
                }
                StartForm.con.Close();
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Search.Edittable == 1)
            {
                if (Type.Existing == 0)
                {
                    StartForm.con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [Hosteller] VALUES (@Name, @DOB, @DOAdmission, @AgeAtAdmis, @Reason, @StillLiving, @DOLeaving); SELECT SCOPE_IDENTITY() ", StartForm.con))
                    {
                        cmd.Parameters.AddWithValue("@Name", NameTB.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOB.Value);
                        cmd.Parameters.AddWithValue("@DOAdmission", DOAdmission.Value);
                        cmd.Parameters.AddWithValue("@AgeAtAdmis", AgeAtAdmisTB.Text);
                        cmd.Parameters.AddWithValue("@Reason", ReasonTB.Text);
                        cmd.Parameters.AddWithValue("@StillLiving", CurrentStateCB.Checked);
                        cmd.Parameters.AddWithValue("@DOLeaving", DODepart.Value);

                        studentID = cmd.ExecuteScalar().ToString();
                    }
                    StartForm.con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Hosteller] SET nameHosteller = @Name, DOBHosteller = @DOB, DateofAdmission = @DOAdmission, AgeatAdmission = @AgeAtAdmis, ReasonForAdmission = @Reason, StillLiving = @StillLiving, DateOfLeaving = @DOLeaving where idHosteller = @idHosteller");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    //cmd.Parameters.AddWithValue("@ID", 4);
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@Name", NameTB.Text);
                    cmd.Parameters.AddWithValue("@DOB", DOB.Value);
                    cmd.Parameters.AddWithValue("@DOAdmission", DOAdmission.Value);
                    cmd.Parameters.AddWithValue("@AgeAtAdmis", AgeAtAdmisTB.Text);
                    cmd.Parameters.AddWithValue("@Reason", ReasonTB.Text);
                    cmd.Parameters.AddWithValue("@StillLiving", CurrentStateCB.Checked);
                    cmd.Parameters.AddWithValue("@DOLeaving", DODepart.Value);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            }

            this.Hide();
            GuardianDetails f4 = new GuardianDetails();
            f4.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Type.Existing == 1)
            {
                Search f2 = new Search();
                f2.ShowDialog();
            }
            else
            {
                Type f1 = new Type();
                f1.ShowDialog();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentStateCB.Checked == true)
            {
                DODepart.Enabled = false;
            }
            else
            {
                DODepart.Enabled = true;
            }
        }

        private void BasicInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
