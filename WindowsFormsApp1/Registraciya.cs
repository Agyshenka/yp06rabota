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
    public partial class Registraciya : Form
    {
        public Registraciya()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (textBox5.Text != "" || textBox6.Text != "")
            {
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(connect);
                myConnection.Open();
                string str = "insert into [12Avtorizaciya](Familiya,Imya,Otchestvo,Nomer_Telephone,Login,Password,Id_Role) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','2')";
                SqlCommand cmd = new SqlCommand(str, myConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Вы зарегистрировались! Теперь можете войти в свой аккаунт.");
                myConnection.Close();
                Form1 z = new Form1();
                z.Show();
            } else
            {
                MessageBox.Show("Вы не заполнили обязательные поля");
            }
        }
    }
}
