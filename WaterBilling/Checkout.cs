using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBilling
{
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e) // Exit
        {
           Environment.Exit(0);
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Checkout_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            guna2CustomCheckBox1.Checked = guna2CustomCheckBox2.Checked = guna2CustomCheckBox3.Checked = false;
            Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender;

            checkBox.Checked = true;
        }
        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            guna2CustomCheckBox1.Checked = guna2CustomCheckBox2.Checked = guna2CustomCheckBox3.Checked = false;
            Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender;
            checkBox.Checked = true;

        }
        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            guna2CustomCheckBox1.Checked = guna2CustomCheckBox2.Checked = guna2CustomCheckBox3.Checked = false;
            Guna.UI2.WinForms.Guna2CustomCheckBox checkBox = (Guna.UI2.WinForms.Guna2CustomCheckBox)sender;
            checkBox.Checked = true;

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://paymentdemo.aamarpay.com/");
        }
    }
}
