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
    public partial class AreasOfConcern : Form
    {
        public AreasOfConcern()
        {
            InitializeComponent();
        }

        private void AreasOfConcern_Load(object sender, EventArgs e)
        {
            if (Search.Edittable == 0)
            {
                AOCGB.Enabled = false;
            }

            FromCB.Items.Add("School");
            FromCB.Items.Add("Hostel");
            FromCB.Items.Add("Family");

            aboutCB.Items.Add("Behaviour");
            aboutCB.Items.Add("Academic");
            aboutCB.Items.Add("Other");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicalHistory f9 = new MedicalHistory();
            f9.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
                int concernNum = 0;
                SqlCommand cmd = new SqlCommand("IF EXISTS ( SELECT * FROM AreaOfConcern where Hosteller_idHosteller = @idHosteller AND ComplainFrom = @ComplainFrom AND Regarding = @Regarding ) " +
                    "BEGIN " +
                    "SELECT MAX(ConcernNum) FROM AreaOfConcern where Hosteller_idHosteller = @idHosteller AND ComplainFrom = @ComplainFrom AND Regarding = @Regarding " +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                    "SELECT COALESCE(NULL, 0) " +
                    "END", StartForm.con);

                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@ComplainFrom", FromCB.Text);
                    cmd.Parameters.AddWithValue("@Regarding", aboutCB.Text);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        concernNum = int.Parse(da.GetValue(0).ToString());
                    }
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@ComplainFrom", FromCB.Text);
                    cmd.Parameters.AddWithValue("@Regarding", aboutCB.Text);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        concernNum = int.Parse(da.GetValue(0).ToString());
                    }
                    StartForm.con.Close();
                }

                cmd = new SqlCommand("INSERT INTO [AreaOfConcern] VALUES (@idHosteller, @ComplainFrom, @Regarding, @Complain, @ConcernNum)", StartForm.con);

                concernNum = concernNum + 1;
                if (Type.Existing == 0)
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(BasicInfo.studentID));
                    cmd.Parameters.AddWithValue("@ComplainFrom", FromCB.Text);
                    cmd.Parameters.AddWithValue("@Regarding", aboutCB.Text);
                    cmd.Parameters.AddWithValue("@Complain", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@ConcernNum", concernNum);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
                    cmd.Parameters.AddWithValue("@ComplainFrom", FromCB.Text);
                    cmd.Parameters.AddWithValue("@Regarding", aboutCB.Text);
                    cmd.Parameters.AddWithValue("@Complain", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@ConcernNum", concernNum);
                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
            
        }

        private void AreasOfConcern_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
