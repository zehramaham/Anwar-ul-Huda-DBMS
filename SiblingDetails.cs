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
    public partial class SiblingDetails : Form
    {
        public static int Done = 0;
        public SiblingDetails()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Done = 0;
            this.Hide();
            GuardianDetails f4 = new GuardianDetails();
            f4.ShowDialog();
        }

        private void SiblingDetails_Load(object sender, EventArgs e)
        {
            if (Search.Edittable == 0)
            {
                SiblingGB.Enabled = false;
            }
            if(Type.Existing == 1)
            {
                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("select nameSibling from HostellerSibling where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                textBox1.ValueMember = "nameSibling";
                textBox1.DataSource = dt;
                StartForm.con.Close();

                Done = 1;
                
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Done = 0;
            this.Hide();
            Hostel_Etiquette f6 = new Hostel_Etiquette();
            f6.ShowDialog();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SiblingDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
                SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT * FROM [HostellerSibling] where Hosteller_idHosteller = @idHosteller and nameSibling = @nameSibling) " +
                    "BEGIN " +
                    "UPDATE [HostellerSibling] SET nameSibling = @nameSibling, LivingAtHostel = @LivingAtHostel, Gender = @Gender, DOBSibling = @DOBSibling where Hosteller_idHosteller = @idHosteller and nameSibling = @nameSibling " +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                    "INSERT INTO [HostellerSibling] ([Hosteller_idHosteller], [nameSibling], [LivingAtHostel], [Gender], [DOBSibling]) VALUES (@idHosteller, @nameSibling, @LivingAtHostel, @Gender, @DOBSibling) " +
                    " END", StartForm.con);
                if (Type.Existing == 0)
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO [HostellerSibling] ([Hosteller_idHosteller], [nameSibling], [LivingAtHostel], [Gender], [DOBSibling]) VALUES (@idHosteller, @nameSibling, @LivingAtHostel, @Gender, @DOBSibling)", StartForm.con);

                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@nameSibling", textBox1.Text);
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@LivingAtHostel", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@LivingAtHostel", 0);
                    }
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "male");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Gender", "female");
                    }
                    cmd.Parameters.AddWithValue("@DOBSibling", dateTimePicker1.Value);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    //SqlCommand cmd = new SqlCommand("UPDATE [HostellerSibling] SET nameSibling = @nameSibling, LivingAtHostel = @LivingAtHostel, Gender = @Gender, DOBSibling = @DOBSibling where Hosteller_idHosteller = @idHosteller", StartForm.con);

                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@nameSibling", textBox1.Text);
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@LivingAtHostel", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@LivingAtHostel", 0);
                    }
                    if (radioButton1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "male");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Gender", "female");
                    }
                    cmd.Parameters.AddWithValue("@DOBSibling", dateTimePicker1.Value);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            
        }

        private void TextBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Done == 1)
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from HostellerSibling where Hosteller_idHosteller = @hostellerID and nameSibling = @nameSibling ", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@nameSibling", textBox1.Text);

                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    textBox1.Text = da.GetValue(1).ToString();
                    string temp2 = da.GetValue(2).ToString();
                    if (temp2 == "True")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    string temp3 = da.GetValue(3).ToString();
                    if (temp3 == "male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    string temp4 = da.GetValue(4).ToString();
                    dateTimePicker1.Text = da.GetValue(5).ToString();
                }
                StartForm.con.Close();
            }
        }

        private void TextBox1_DropDown(object sender, EventArgs e)
        {
            
        }
    }
}
