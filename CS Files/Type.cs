using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Type : Form
    {
        public static int Existing;

        public Type()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Existing = 1;
            this.Hide();
            if (StartForm.Sponser == 1)
            {
                ExistingSponser f2 = new ExistingSponser();
                f2.ShowDialog();
            }
            else
            {
                Search f2 = new Search();
                f2.ShowDialog();
            }   
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Existing = 0;
            Search.Edittable = 1;
            this.Hide();
            if (StartForm.Sponser == 1)
            {
                NewSponser f2 = new NewSponser();
                f2.ShowDialog();
            }
            else
            {
                BasicInfo f3 = new BasicInfo();
                f3.ShowDialog();
            }          
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm f0 = new StartForm();
            f0.ShowDialog();
        }

        private void Type_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
