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
    public partial class InfoForSponser : Form
    {
        public InfoForSponser()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void InfoForSponser_Load(object sender, EventArgs e)
        {
            StartForm.con.Open();
            SqlCommand cmd = new SqlCommand("Select nameSponser, nameHosteller, currentPercent " +
                "from Spons_Hosteller, Hosteller, Sponser, SchoolPerformance " +
                "where Spons_Hosteller.Sponser_idSponser = Sponser.idSponser " +
                "and Spons_Hosteller.Hosteller_idHosteller = Hosteller.idHosteller " +
                "and Spons_Hosteller.Hosteller_idHosteller = SchoolPerformance.Hosteller_idHosteller " +
                "and Hosteller.idHosteller = @idHosteller ", StartForm.con);
            cmd.Parameters.AddWithValue("@idHosteller", int.Parse(Search.studentID));
            SqlDataReader da = cmd.ExecuteReader();
            while(da.Read())
            {
                textBox1.Text = da.GetValue(0).ToString();
                textBox3.Text = da.GetValue(1).ToString();
                textBox2.Text = da.GetValue(2).ToString();
            }
            StartForm.con.Close();

            StartForm.con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select Name from Achievements where Hosteller_idHosteller = @hostellerID", StartForm.con);
            adapt.SelectCommand.Parameters.AddWithValue("@hostellerID", Search.studentID);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = dt;
            StartForm.con.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search f2 = new Search();
            f2.ShowDialog();
        }

        private void InfoForSponser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicalHistory f9 = new MedicalHistory();
            f9.ShowDialog();
        }
    }
}
