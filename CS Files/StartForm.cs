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
    public partial class StartForm : Form
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True; User Instance=True");

        public static int Sponser;

        public StartForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sponser = 1;
            this.Hide();
            Type f1 = new Type();
            f1.ShowDialog();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            Sponser = 0;
            this.Hide();
            Type f1 = new Type();
            f1.ShowDialog();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
