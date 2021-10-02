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
    public partial class Hostel_Etiquette : Form
    {
        public Hostel_Etiquette()
        {
            InitializeComponent();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Hostel_Etiquette_Load(object sender, EventArgs e)
        {
            if (Search.Edittable == 0)
            {
                HostelGB.Enabled = false;
            }

            BehOthChilCB.Items.Add("Aggressive");
            BehOthChilCB.Items.Add("Disrespectful");
            BehOthChilCB.Items.Add("Indifferent");
            BehOthChilCB.Items.Add("Friendly");
            BehOthChilCB.Items.Add("Kind");

            BehSupeCB.Items.Add("Disrespectful");
            BehSupeCB.Items.Add("Indifferent");
            BehSupeCB.Items.Add("Respectful");

            RespHostCB.Items.Add("Excellent");
            RespHostCB.Items.Add("Good");
            RespHostCB.Items.Add("Average");
            RespHostCB.Items.Add("Poor");
            RespHostCB.Items.Add("Bad");

            RespPBCB.Items.Add("Excellent");
            RespPBCB.Items.Add("Good");
            RespPBCB.Items.Add("Average");
            RespPBCB.Items.Add("Poor");
            RespPBCB.Items.Add("Bad");

            NamazCB.Items.Add("Prays with proper pronounciation and correctness");
            NamazCB.Items.Add("Prays independently, needs a little improvement in pronounciation");
            NamazCB.Items.Add("Can pray, needs supervision");
            NamazCB.Items.Add("Follows recitation");
            NamazCB.Items.Add("Follows actions");

            QuranCB.Items.Add("Completed Quran more than 5 times");
            QuranCB.Items.Add("Completed Quran atleast once");
            QuranCB.Items.Add("Completed more than 15 siparas");
            QuranCB.Items.Add("Reading 30 sipara first");
            QuranCB.Items.Add("On Qaida");

            if(Type.Existing == 1)
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from BehaviorInHostel where Hosteller_idHosteller = @idHosteller", StartForm.con);
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    BehOthChilCB.Text = da.GetValue(1).ToString();
                    BehSupeCB.Text = da.GetValue(2).ToString();
                    RespHostCB.Text = da.GetValue(3).ToString();
                    RespPBCB.Text = da.GetValue(4).ToString();
                    QuranCB.Text = da.GetValue(5).ToString();
                    NamazCB.Text = da.GetValue(6).ToString();
                }
                StartForm.con.Close();
            }
            else if(BasicInfo.studentID != "")
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from BehaviorInHostel where Hosteller_idHosteller = @idHosteller", StartForm.con);
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    BehOthChilCB.Text = da.GetValue(1).ToString();
                    BehSupeCB.Text = da.GetValue(2).ToString();
                    RespHostCB.Text = da.GetValue(3).ToString();
                    RespPBCB.Text = da.GetValue(4).ToString();
                    QuranCB.Text = da.GetValue(5).ToString();
                    NamazCB.Text = da.GetValue(6).ToString();
                }
                StartForm.con.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Search.Edittable == 1)
            {
                SqlCommand cmd = new SqlCommand("IF EXISTS ( SELECT * FROM [BehaviorInHostel] where Hosteller_idHosteller = @idHosteller )" +
                    "BEGIN " +
                    "UPDATE [BehaviorInHostel] SET BehavWithOthChildren = @BehavWithOthChildren, BehavWithSupervisor = @BehavWithSupervisor, ResponsInHostelScale = @ResponsInHostelScale, ResponsOfBelongScale = @ResponsOfBelongScale, QuranLevel = @QuranLevel, NamazLevel = @NamazLevel where Hosteller_idHosteller = @idHosteller " +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                    "INSERT INTO [BehaviorInHostel] VALUES (@idHosteller, @BehavWithOthChildren, @BehavWithSupervisor, @ResponsInHostelScale, @ResponsOfBelongScale, @QuranLevel, @NamazLevel) " +
                    "END", StartForm.con);

                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@BehavWithOthChildren", BehOthChilCB.Text);
                    cmd.Parameters.AddWithValue("@BehavWithSupervisor", BehSupeCB.Text);
                    cmd.Parameters.AddWithValue("@ResponsInHostelScale", RespHostCB.Text);
                    cmd.Parameters.AddWithValue("@ResponsOfBelongScale", RespPBCB.Text);
                    cmd.Parameters.AddWithValue("@QuranLevel", QuranCB.Text);
                    cmd.Parameters.AddWithValue("@NamazLevel", NamazCB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@BehavWithOthChildren", BehOthChilCB.Text);
                    cmd.Parameters.AddWithValue("@BehavWithSupervisor", BehSupeCB.Text);
                    cmd.Parameters.AddWithValue("@ResponsInHostelScale", RespHostCB.Text);
                    cmd.Parameters.AddWithValue("@ResponsOfBelongScale", RespPBCB.Text);
                    cmd.Parameters.AddWithValue("@QuranLevel", QuranCB.Text);
                    cmd.Parameters.AddWithValue("@NamazLevel", NamazCB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            }
            this.Hide();
            OverallSchool f7 = new OverallSchool();
            f7.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SiblingDetails f5 = new SiblingDetails();
            f5.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HostelGB_Enter(object sender, EventArgs e)
        {

        }

        private void Hostel_Etiquette_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
