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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Janr form = new Janr();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Avtor form = new Avtor();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user2 form = new user2();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tovar form = new Tovar();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Zakazi form = new Zakazi();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vid_Zapisi form = new Vid_Zapisi();
            form.Show();
        }
    }
}
