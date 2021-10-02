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
    public partial class MedicalHistory : Form
    {
        public MedicalHistory()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(Search.ForSponser == 1)
            {
                Application.Exit();
            }
            if (Search.Edittable == 1)
            {
                SqlCommand cmd = new SqlCommand("IF EXISTS ( SELECT * FROM [MedicalHistory] where Hosteller_idHosteller = @idHosteller ) " +
                        "BEGIN " +
                        "UPDATE [MedicalHistory] SET Height = @Height, Weight = @Weight, ageOfMenarche = @ageOfMenarche, Diet = @Diet, PersonalHygieneScale = @PersonalHygieneScale, " +
                        "BloodGroup = @BloodGroup, Hemoglobin = @Hemoglobin, Hematocrit = @Hematocrit, Platelets = @Platelets, NumofRBCs = @NumofRBCs, NumofWBCs = @NumofWBCs, " +
                        "EyeTest = @EyeTest, DentalTest = @DentalTest, ExtraInfo = @ExtraInfo " +
                        "WHERE Hosteller_idHosteller = @idHosteller " +
                        "END " +
                        "ELSE " +
                        "BEGIN " +
                        "INSERT INTO [MedicalHistory] VALUES (@idHosteller, @Height, @Weight, @ageOfMenarche, @Diet, @PersonalHygieneScale, " +
                        "@BloodGroup, @Hemoglobin, @Hematocrit, @Platelets, @NumofRBCs, @NumofWBCs, " +
                        "@EyeTest, @DentalTest, @ExtraInfo)" +
                        "END ", StartForm.con);

                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@Height", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Weight", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ageOfMenarche", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Diet", DietCB.Text);
                    cmd.Parameters.AddWithValue("@PersonalHygieneScale", HygieneCB.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGB.Text);
                    cmd.Parameters.AddWithValue("@Hemoglobin", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Hematocrit", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Platelets", textBox6.Text);
                    cmd.Parameters.AddWithValue("@NumofRBCs", textBox5.Text);
                    cmd.Parameters.AddWithValue("@NumofWBCs", textBox7.Text);
                    cmd.Parameters.AddWithValue("@EyeTest", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@DentalTest", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@ExtraInfo", AddInfoRTB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@Height", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Weight", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ageOfMenarche", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Diet", DietCB.Text);
                    cmd.Parameters.AddWithValue("@PersonalHygieneScale", HygieneCB.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGrpCB.Text);
                    cmd.Parameters.AddWithValue("@Hemoglobin", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Hematocrit", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Platelets", textBox6.Text);
                    cmd.Parameters.AddWithValue("@NumofRBCs", textBox5.Text);
                    cmd.Parameters.AddWithValue("@NumofWBCs", textBox7.Text);
                    cmd.Parameters.AddWithValue("@EyeTest", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@DentalTest", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@ExtraInfo", AddInfoRTB.Text);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            }

            this.Hide();
            if (Search.Edittable == 0)
            {
                AreasOfConcernView f10 = new AreasOfConcernView();
                f10.ShowDialog();
            }
            else
            {
                AreasOfConcern f10 = new AreasOfConcern();
                f10.ShowDialog();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(Search.Edittable == 1)
            {
                this.Hide();
                MonthlySchool f8 = new MonthlySchool();
                f8.ShowDialog();
            }
            else if(Search.Edittable == 0)
            {
                this.Hide();
                MonthlySchoolView f8 = new MonthlySchoolView();
                f8.ShowDialog();
            }

            if(Search.ForSponser == 1)
            {
                this.Hide();
                InfoForSponser f8 = new InfoForSponser();
                f8.ShowDialog();
            }
            
        }

        private void MedicalHistory_Load(object sender, EventArgs e)
        {
            if(Search.ForSponser == 1)
            {
                button1.Text = "End";
            }
            if (Search.Edittable == 0)
            {
                AllergyGB.Enabled = false;
                basicsGB.Enabled = false;
                bloodGB.Enabled = false;
                TestsGB.Enabled = false;
                IllnessGB.Enabled = false;
                FamIllGB.Enabled = false;
                MedicationGB.Enabled = false;
                SurgeryGB.Enabled = false;
                AddInfoRTB.Enabled = false;
            }

            bloodGrpCB.Items.Add("A+");
            bloodGrpCB.Items.Add("A-");
            bloodGrpCB.Items.Add("B+");
            bloodGrpCB.Items.Add("B-");
            bloodGrpCB.Items.Add("AB+");
            bloodGrpCB.Items.Add("AB-");
            bloodGrpCB.Items.Add("O+");
            bloodGrpCB.Items.Add("O-");

            DietCB.Items.Add("Healthy");
            DietCB.Items.Add("Moderate");
            DietCB.Items.Add("Unhealthy");

            HygieneCB.Items.Add("Excellent");
            HygieneCB.Items.Add("Good");
            HygieneCB.Items.Add("Moderate");
            HygieneCB.Items.Add("Poor");
            HygieneCB.Items.Add("Bad");

            if (Type.Existing == 1)
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [MedicalHistory] where Hosteller_idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    textBox10.Text = da.GetValue(1).ToString();
                    textBox1.Text = da.GetValue(2).ToString();
                    textBox2.Text = da.GetValue(3).ToString();
                    DietCB.Text = da.GetValue(4).ToString();
                    HygieneCB.Text = da.GetValue(5).ToString();
                    bloodGrpCB.Text = da.GetValue(6).ToString();
                    textBox4.Text = da.GetValue(7).ToString();
                    textBox3.Text = da.GetValue(8).ToString();
                    textBox6.Text = da.GetValue(9).ToString();
                    textBox5.Text = da.GetValue(10).ToString();
                    textBox7.Text = da.GetValue(11).ToString();
                    richTextBox1.Text = da.GetValue(12).ToString();
                    richTextBox2.Text = da.GetValue(13).ToString();
                    AddInfoRTB.Text = da.GetValue(14).ToString();
                }
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select possibleAlergy_idpossibleAlergy from Allergy where MedicalHistory_Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox5.DisplayMember = "Allergy";
                listBox5.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select possibleIllness_idIllness from Illness where MedicalHistory_Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox1.DisplayMember = "Illness";
                listBox1.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select possibleSurgery_idpossibleSurgery from Surgery where MedicalHistory_Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox4.DisplayMember = "Surgery";
                listBox4.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select possibleMedication_idMedication from Medication where MedicalHistory_Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox3.DisplayMember = "Medication";
                listBox3.DataSource = dt;
                StartForm.con.Close();
            }
            else if(BasicInfo.studentID != "")
            {
                StartForm.con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [MedicalHistory] where Hosteller_idHosteller = @hostellerID", StartForm.con);
                cmd.Parameters.AddWithValue("@hostellerID", int.Parse(Search.studentID));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string temp = da.GetValue(0).ToString();
                    textBox10.Text = da.GetValue(1).ToString();
                    textBox1.Text = da.GetValue(2).ToString();
                    textBox2.Text = da.GetValue(3).ToString();
                    DietCB.Text = da.GetValue(4).ToString();
                    HygieneCB.Text = da.GetValue(5).ToString();
                    bloodGrpCB.Text = da.GetValue(6).ToString();
                    textBox4.Text = da.GetValue(7).ToString();
                    textBox3.Text = da.GetValue(8).ToString();
                    textBox6.Text = da.GetValue(9).ToString();
                    textBox5.Text = da.GetValue(10).ToString();
                    textBox7.Text = da.GetValue(11).ToString();
                    richTextBox1.Text = da.GetValue(12).ToString();
                    richTextBox2.Text = da.GetValue(13).ToString();
                    AddInfoRTB.Text = da.GetValue(14).ToString();
                }
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Allergy from Allergy where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox5.DisplayMember = "Allergy";
                listBox5.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select Illness from Illness where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox1.DisplayMember = "Illness";
                listBox1.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select Surgery from Surgery where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox4.DisplayMember = "Surgery";
                listBox4.DataSource = dt;
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("Select Medication from Medication where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                dt = new DataTable();
                adapt.Fill(dt);
                listBox3.DisplayMember = "Medication";
                listBox3.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Medication] VALUES (@idHosteller, @Medication)");
            cmd.Connection = StartForm.con;
            SqlDataAdapter adapt = new SqlDataAdapter("Select Medication from Medication where Hosteller_idHosteller = @hostellerID", StartForm.con);

            if (Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@Medication", medTB.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", BasicInfo.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox3.ValueMember = "Medication";
                listBox3.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@medication", medTB.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox3.DisplayMember = "Medication";
                listBox3.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BloodGB_Enter(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllergyGB_Enter(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Illness] VALUES (@idHosteller, @Illness)");
            cmd.Connection = StartForm.con;

            if (Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@Illness", textBox8.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Illness from Illness where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", BasicInfo.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox1.DisplayMember = "Illness";
                listBox1.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@Illness", textBox8.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Illness from Illness where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox1.DisplayMember = "Illness";
                listBox1.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [FamilyIllness] VALUES (@idHosteller, @FamilyIllness)");
            cmd.Connection = StartForm.con;

            if (Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@FamilyIllness", textBox9.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select FamilyIllness from FamilyIllness where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", BasicInfo.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox2.DisplayMember = "FamilyIllness";
                listBox2.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@FamilyIllness", textBox9.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select FamilyIllness from FamilyIllness where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox2.DisplayMember = "FamilyIllness";
                listBox2.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Allergy] VALUES (@idHosteller, @Allergy)");
            cmd.Connection = StartForm.con;

            if (Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@Allergy", textBox12.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Allergy from Allergy where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", BasicInfo.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox5.DisplayMember = "Allergy";
                listBox5.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@Allergy", textBox12.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Allergy from Allergy where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox5.DisplayMember = "Allergy";
                listBox5.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Surgery] VALUES (@idHosteller, @Surgery)");
            cmd.Connection = StartForm.con;

            if (Type.Existing == 0)
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                cmd.Parameters.AddWithValue("@Surgery", textBox11.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Surgery from Surgery where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", BasicInfo.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox4.DisplayMember = "Surgery";
                listBox4.DataSource = dt;
                StartForm.con.Close();
            }
            else
            {
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                cmd.Parameters.AddWithValue("@Surgery", textBox11.Text);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();

                StartForm.con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("Select Surgery from Surgery where Hosteller_idHosteller = @hostellerID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                listBox4.DisplayMember = "Surgery";
                listBox4.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void MedicationGB_Enter(object sender, EventArgs e)
        {

        }

        private void MedicalHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
