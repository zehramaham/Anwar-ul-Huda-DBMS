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
    public partial class NewSponser : Form
    {
        public static string studentID;
        public static string sponserID;

        public NewSponser()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Exit();
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ExistingSponser.Edittable == 0)
            {
                if (SponserCB.Checked == false)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [SPONSER] VALUES (@nameSponser, @organisationSponser, @SponserSince, @ContactNumber, @Contactmail, @address, @SponserTill)");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@nameSponser", textBox5.Text);
                    cmd.Parameters.AddWithValue("@organisationSponser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SponserSince", SinceDTP.Value);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contactmail", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SponserTill", TillDTP.Value);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [SPONSER] (nameSponser, organisationSponser, SponserSince, ContactNumber, Contactmail, address) VALUES (@nameSponser, @organisationSponser, @SponserSince, @ContactNumber, @Contactmail, @address)");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@nameSponser", textBox5.Text);
                    cmd.Parameters.AddWithValue("@organisationSponser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SponserSince", SinceDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contactmail", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }

            }
            else
            {

                if (SponserCB.Checked == false)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Sponser] SET organisationSponser = @organisationSponser, nameSponser = @nameSponser, SponserSince = @SponserSince, ContactNumber = @ContactNumber, Contactmail = @Contactmail, address = @address, SponserTill = @SponserTill where idSponser = @idSponser");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@nameSponser", textBox5.Text);
                    cmd.Parameters.AddWithValue("@organisationSponser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@idSponser", ExistingSponser.sponserID);
                    cmd.Parameters.AddWithValue("@SponserSince", SinceDTP.Value);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contactmail", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SponserTill", TillDTP.Value);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Sponser] SET organisationSponser = @organisationSponser, nameSponser = @nameSponser, SponserSince = @SponserSince, ContactNumber = @ContactNumber, Contactmail = @Contactmail, address = @address where idSponser = @idSponser");

                    cmd.Connection = StartForm.con;
                    StartForm.con.Open();
                    cmd.Parameters.AddWithValue("@nameSponser", textBox5.Text);
                    cmd.Parameters.AddWithValue("@organisationSponser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@idSponser", ExistingSponser.sponserID);
                    cmd.Parameters.AddWithValue("@SponserSince", SinceDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contactmail", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);

                    cmd.ExecuteNonQuery();
                    StartForm.con.Close();

                }

            }
        }

        private void Sponser_Load(object sender, EventArgs e)
        {
            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from Hosteller", StartForm.con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            HostellersDGV.DataSource = dt;
            StartForm.con.Close();

            /*StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select nameHosteller from Hosteller", StartForm.con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            comboBox1.ValueMember = "nameHosteller";
            comboBox1.DataSource = dt;
            StartForm.con.Close();*/

            SponserCB.Checked = true;
            if(ExistingSponser.Edittable == 1)
            {
                StartForm.con.Open();
                //var sponserID = ExistingSponser.sponserID;
                SqlCommand cmd = new SqlCommand("Select organisationSponser, nameSponser, SponserSince, ContactNumber, Contactmail, [address], SponserTill from Sponser where idSponser = @sponserID", StartForm.con);
                cmd.Parameters.AddWithValue("@sponserID", int.Parse(ExistingSponser.sponserID));
                SqlDataReader da = cmd.ExecuteReader();
                while(da.Read())
                {
                    textBox1.Text = da.GetValue(0).ToString();
                    textBox5.Text = da.GetValue(1).ToString();
                    SinceDTP.Text = da.GetValue(2).ToString();
                    textBox4.Text = da.GetValue(3).ToString();
                    textBox3.Text = da.GetValue(4).ToString();
                    textBox2.Text = da.GetValue(5).ToString();
                    string temp = da.GetValue(6).ToString();
                    TillDTP.Text = temp;
                    if(temp != "")
                    {
                        SponserCB.Checked = false;
                        TillDTP.Text = temp;
                    }
                }
                StartForm.con.Close();

                StartForm.con.Open();
                adapt = new SqlDataAdapter("select nameHosteller from Spons_Hosteller, Hosteller where Hosteller_idHosteller = idHosteller and Sponser_idSponser = @sponserID", StartForm.con);
                adapt.SelectCommand.Parameters.AddWithValue("@sponserID", int.Parse(ExistingSponser.sponserID));
                dt = new DataTable();
                adapt.Fill(dt);
                //SearchDGV.ValueMember = "nameHosteller";
                SearchDGV.DataSource = dt;
                StartForm.con.Close();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SponserCB_CheckedChanged(object sender, EventArgs e)
        {
            if (SponserCB.Checked == true)
            {
                TillDTP.Enabled = false;
            }
            else
            {
                TillDTP.Enabled = true; 
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(ExistingSponser.Edittable == 1)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Spons_Hosteller] VALUES (@SponserID, @HostellerID)");
                cmd.Connection = StartForm.con;
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@SponserID", ExistingSponser.sponserID);
                cmd.Parameters.AddWithValue("@HostellerID", studentID);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();
            }
            else
            {
                
                SqlCommand cmd = new SqlCommand("Select idSponser from [Sponser] where organisationSponser = @organisationSponser", StartForm.con);
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@organisationSponser", textBox1.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    sponserID = da.GetValue(0).ToString();
                }
                StartForm.con.Close();

                cmd = new SqlCommand("INSERT INTO [Spons_Hosteller] VALUES (@SponserID, @HostellerID)");
                cmd.Connection = StartForm.con;
                StartForm.con.Open();
                cmd.Parameters.AddWithValue("@SponserID",sponserID);
                cmd.Parameters.AddWithValue("@HostellerID", studentID);
                cmd.ExecuteNonQuery();
                StartForm.con.Close();
            }

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select Hosteller.nameHosteller from Spons_Hosteller, Hosteller where Spons_Hosteller.Hosteller_idHosteller = Hosteller.idHosteller and Sponser_idSponser = @sponserID", StartForm.con);

            if(ExistingSponser.Edittable == 1)
            {
                adapt.SelectCommand.Parameters.AddWithValue("@sponserID", int.Parse(ExistingSponser.sponserID));
            }
            else
            {
                adapt.SelectCommand.Parameters.AddWithValue("@sponserID", int.Parse(sponserID));
            }
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            //SearchDGV.ValueMember = "nameHosteller";
            SearchDGV.DataSource = dt;
            StartForm.con.Close();
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ExistingSponser.Edittable = 0;
            this.Hide();
            Type f1 = new Type();
            f1.ShowDialog();
        }

        private void NewSponser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void HostellersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HostellersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.HostellersDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                this.HostellersDGV.CurrentRow.Selected = true;
                studentID = this.HostellersDGV.Rows[e.RowIndex].Cells["idHosteller"].FormattedValue.ToString();

            }
        }
    }
}
