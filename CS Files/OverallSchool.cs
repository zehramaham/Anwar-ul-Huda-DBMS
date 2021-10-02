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
    public partial class OverallSchool : Form
    {
        public OverallSchool()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Search.Edittable == 1)
            {
                SqlCommand cmd = new SqlCommand("IF EXISTS ( SELECT * FROM [SchoolPerformance] WHERE hosteller_idHosteller = @idHosteller ) " +
                    "BEGIN " +
                    "UPDATE [SchoolPerformance] SET schoolName = @schoolName, currentClass = @currentClass, currentPercent = @currentPercent, prevPercent = @prevPercent, CoCurriculars = @CoCurriculars, ClassParticipation = @ClassParticipation, PeerRelation = @PeerRelation, TeachStaffRelation = @TeachStaffRelation WHERE Hosteller_idHosteller = @idHosteller " +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                    "INSERT INTO [SchoolPerformance] ([Hosteller_idHosteller],[schoolName],[currentClass],[currentPercent],[prevPercent],[CoCurriculars],[ClassParticipation],[PeerRelation],[TeachStaffRelation]) " +
                    "VALUES (@idHosteller, @schoolName, @currentClass, @currentPercent, @prevPercent, @CoCurriculars, @ClassParticipation, @PeerRelation, @TeachStaffRelation) " +
                    "END", StartForm.con);

                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@schoolName", SchoolCB.Text);
                    cmd.Parameters.AddWithValue("@currentClass", textBox1.Text);
                    cmd.Parameters.AddWithValue("@currentPercent", textBox3.Text);
                    cmd.Parameters.AddWithValue("@prevPercent", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CoCurriculars", CoCurricularsCB.Text);
                    cmd.Parameters.AddWithValue("@ClassParticipation", classActCB.Text);
                    cmd.Parameters.AddWithValue("@PeerRelation", behavOtherStudCB.Text);
                    cmd.Parameters.AddWithValue("@TeachStaffRelation", behavTeachCB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@schoolName", SchoolCB.Text);
                    cmd.Parameters.AddWithValue("@currentClass", textBox1.Text);
                    cmd.Parameters.AddWithValue("@currentPercent", textBox3.Text);
                    cmd.Parameters.AddWithValue("@prevPercent", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CoCurriculars", CoCurricularsCB.Text);
                    cmd.Parameters.AddWithValue("@ClassParticipation", classActCB.Text);
                    cmd.Parameters.AddWithValue("@PeerRelation", behavOtherStudCB.Text);
                    cmd.Parameters.AddWithValue("@TeachStaffRelation", behavTeachCB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            }

            this.Hide();
            if (Search.Edittable == 0)
            {  
                AchievementsView f8 = new AchievementsView();
                f8.ShowDialog();
            }
            else
            {
                Achievements f8 = new Achievements();
                f8.ShowDialog();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hostel_Etiquette f6 = new Hostel_Etiquette();
            f6.ShowDialog();
        }

        private void OverallSchool_Load(object sender, EventArgs e)
        {
            if (Search.Edittable == 0)
            {
                OSchoolGB.Enabled = false;
            }

            SchoolCB.Items.Add("Uswa Girls Public School and College");
            SchoolCB.Items.Add("Uswa Girls Yultar School");
            SchoolCB.Items.Add("Government Koshmara High School");

            CoCurricularsCB.Items.Add("very frequent");
            CoCurricularsCB.Items.Add("often");
            CoCurricularsCB.Items.Add("sometimes");
            CoCurricularsCB.Items.Add("seldom");
            CoCurricularsCB.Items.Add("never");

            classActCB.Items.Add("very frequent");
            classActCB.Items.Add("often");
            classActCB.Items.Add("sometimes");
            classActCB.Items.Add("seldom");
            classActCB.Items.Add("never");

            behavOtherStudCB.Items.Add("Aggressive");
            behavOtherStudCB.Items.Add("Disrespectful");
            behavOtherStudCB.Items.Add("Indifferent");
            behavOtherStudCB.Items.Add("Friendly");
            behavOtherStudCB.Items.Add("Kind");

            behavTeachCB.Items.Add("Disrespectful");
            behavTeachCB.Items.Add("Indifferent");
            behavTeachCB.Items.Add("Respectful");

            if(Type.Existing == 1)
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select [Hosteller_idHosteller],[schoolName],[currentClass],[currentPercent],[prevPercent],[CoCurriculars],[ClassParticipation],[PeerRelation],[TeachStaffRelation] from SchoolPerformance where Hosteller_idHosteller = @idHosteller", StartForm.con);
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    SchoolCB.Text = da.GetValue(1).ToString();
                    textBox1.Text = da.GetValue(2).ToString();
                    textBox3.Text = da.GetValue(3).ToString();
                    textBox2.Text = da.GetValue(4).ToString();
                    CoCurricularsCB.Text = da.GetValue(5).ToString();
                    classActCB.Text = da.GetValue(6).ToString();
                    behavOtherStudCB.Text = da.GetValue(7).ToString();
                    behavTeachCB.Text = da.GetValue(8).ToString();
                }
                StartForm.con.Close();
            }

        }

        private void OSchoolGB_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OverallSchool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
