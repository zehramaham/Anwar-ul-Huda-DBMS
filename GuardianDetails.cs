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
    public partial class GuardianDetails : Form
    {
        public GuardianDetails()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void GuardianDetails_Load(object sender, EventArgs e)
        {
            if (Search.Edittable == 0)
            {
                NOKGB.Enabled = false;
                FatherGB.Enabled = false;
                MotherGB.Enabled = false;
                StepFatherGB.Enabled = false;
            }
            if(Type.Existing == 1)
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from GuardianDetails where Hosteller_idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    textBox1.Text = da.GetValue(1).ToString();
                    textBox3.Text = da.GetValue(2).ToString();
                    textBox2.Text = da.GetValue(3).ToString();
                    textBox6.Text = da.GetValue(4).ToString();
                    textBox7.Text = da.GetValue(5).ToString();
                    textBox5.Text = da.GetValue(6).ToString();
                    textBox4.Text = da.GetValue(7).ToString();
                    textBox10.Text = da.GetValue(8).ToString();
                    textBox9.Text = da.GetValue(9).ToString();
                    textBox8.Text = da.GetValue(10).ToString();
                    textBox11.Text = da.GetValue(11).ToString();
                    textBox15.Text = da.GetValue(12).ToString();
                    string temp2 = da.GetValue(13).ToString();
                    if (temp2 == "True")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    textBox13.Text = da.GetValue(14).ToString();
                    textBox12.Text = da.GetValue(15).ToString();
                }
                StartForm.con.Close();
            }
            else if(BasicInfo.studentID != "")
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from GuardianDetails where Hosteller_idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(BasicInfo.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    textBox1.Text = da.GetValue(1).ToString();
                    textBox3.Text = da.GetValue(2).ToString();
                    textBox2.Text = da.GetValue(3).ToString();
                    textBox6.Text = da.GetValue(4).ToString();
                    textBox7.Text = da.GetValue(5).ToString();
                    textBox5.Text = da.GetValue(6).ToString();
                    textBox4.Text = da.GetValue(7).ToString();
                    textBox10.Text = da.GetValue(8).ToString();
                    textBox9.Text = da.GetValue(9).ToString();
                    textBox8.Text = da.GetValue(10).ToString();
                    textBox11.Text = da.GetValue(11).ToString();
                    textBox15.Text = da.GetValue(12).ToString();
                    string temp2 = da.GetValue(13).ToString();

                    textBox13.Text = da.GetValue(14).ToString();
                    textBox12.Text = da.GetValue(15).ToString();
                }
                StartForm.con.Close();
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Search.Edittable == 1)
            {
                SqlCommand cmd = new SqlCommand("IF EXISTS ( SELECT * FROM [GuardianDetails] WHERE Hosteller_idHosteller = @idHosteller)" +
                        "BEGIN " +
                        "UPDATE [GuardianDetails] SET Hosteller_idHosteller = @idHosteller, MotherName = @MotherName, MotherEducation = @MotherEducation, MotherOccupation = @MotherOccupation, " +
                        "FatherName = @FatherName, ReasonForFatherDeath = @ReasonForFatherDeath, FatherEducation = @FatherEducation, FatherOccupation = @FatherOccupation," +
                        "NextOfKinName = @NextOfKinName, NOKRelationship = @NOKRelationship, NOKContact = @NOKContact, NOKAddress = @NOKAddress, " +
                        "StepFatherName = @StepFatherName, SFWillingToStayInTouch = @SFWillingToStayInTouch, SFContact = @SFContact, SFAddress = @SFAddress" +
                        " where Hosteller_idHosteller = @idHosteller " +
                        "END " +
                        "ELSE " +
                        "BEGIN " +
                        "INSERT INTO [GuardianDetails] VALUES (@idHosteller, @MotherName, @MotherEducation, @MotherOccupation, @FatherName, @ReasonForFatherDeath, @FatherEducation, @FatherOccupation, @NextOfKinName, @NOKRelationship, @NOKContact, @NOKAddress, @StepFatherName, @SFWillingToStayInTouch, @SFContact, @SFAddress)" +
                        " END ");
                if (Type.Existing == 0)
                {

                    //SqlCommand cmd = new SqlCommand("INSERT INTO [GuardianDetails] VALUES (@idHosteller, @MotherName, @MotherEducation, @MotherOccupation, @FatherName, @ReasonForFatherDeath, @FatherEducation, @FatherOccupation, @NextOfKinName, @NOKRelationship, @NOKContact, @NOKAddress, @StepFatherName, @SFWillingToStayInTouch, @SFContact, @SFAddress)");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@MotherName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MotherEducation", textBox3.Text);
                    cmd.Parameters.AddWithValue("@MotherOccupation", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FatherName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ReasonForFatherDeath", textBox7.Text);
                    cmd.Parameters.AddWithValue("@FatherEducation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@FatherOccupation", textBox4.Text);
                    cmd.Parameters.AddWithValue("@NextOfKinName", textBox10.Text);
                    cmd.Parameters.AddWithValue("@NOKRelationship", textBox9.Text);
                    cmd.Parameters.AddWithValue("@NOKContact", textBox8.Text);
                    cmd.Parameters.AddWithValue("@NOKAddress", textBox11.Text);
                    cmd.Parameters.AddWithValue("@StepFatherName", textBox15.Text);
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@SFWillingToStayInTouch", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SFWillingToStayInTouch", 0);
                    }
                    cmd.Parameters.AddWithValue("@SFContact", textBox13.Text);
                    cmd.Parameters.AddWithValue("@SFAddress", textBox12.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    /*SqlCommand cmd = new SqlCommand("UPDATE [GuardianDetails] SET Hosteller_idHosteller = @idHosteller, MotherName = @MotherName, MotherEducation = @MotherEducation, MotherOccupation = @MotherOccupation, " +
                        "FatherName = @FatherName, ReasonForFatherDeath = @ReasonForFatherDeath, FatherEducation = @FatherEducation, FatherOccupation = @FatherOccupation," +
                        "NextOfKinName = @NextOfKinName, NOKRelationship = @NOKRelationship, NOKContact = @NOKContact, NOKAddress = @NOKAddress, " +
                        "StepFatherName = @StepFatherName, SFWillingToStayInTouch = @SFWillingToStayInTouch, SFContact = @SFContact, SFAddress = @SFAddress" +
                        " where Hosteller_idHosteller = @idHosteller");*/

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", Search.studentID);
                    cmd.Parameters.AddWithValue("@MotherName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MotherEducation", textBox3.Text);
                    cmd.Parameters.AddWithValue("@MotherOccupation", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FatherName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ReasonForFatherDeath", textBox7.Text);
                    cmd.Parameters.AddWithValue("@FatherEducation", textBox5.Text);
                    cmd.Parameters.AddWithValue("@FatherOccupation", textBox4.Text);
                    cmd.Parameters.AddWithValue("@NextOfKinName", textBox10.Text);
                    cmd.Parameters.AddWithValue("@NOKRelationship", textBox9.Text);
                    cmd.Parameters.AddWithValue("@NOKContact", textBox8.Text);
                    cmd.Parameters.AddWithValue("@NOKAddress", textBox11.Text);
                    cmd.Parameters.AddWithValue("@StepFatherName", textBox15.Text);
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@SFWillingToStayInTouch", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SFWillingToStayInTouch", 0);
                    }
                    cmd.Parameters.AddWithValue("@SFContact", textBox13.Text);
                    cmd.Parameters.AddWithValue("@SFAddress", textBox12.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            }

            if(Search.Edittable == 1)
            {
                this.Hide();
                SiblingDetails f5 = new SiblingDetails();
                f5.ShowDialog();
            }
            else
            {
                this.Hide();
                SiblingDetailsView f5 = new SiblingDetailsView();
                f5.ShowDialog();
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BasicInfo f3 = new BasicInfo();
            f3.ShowDialog();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GuardianDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
