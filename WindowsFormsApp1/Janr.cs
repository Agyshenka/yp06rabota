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
    public partial class Janr : Form
    {
        public Janr()
        {
            InitializeComponent();
        }

        private void Janr_Load(object sender, EventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(connect);
            myConnection.Open();
            string command1 = "Select * from [12Janr]";
            SqlCommand myCommand = new SqlCommand(command1, myConnection);
            SqlDataReader reader = myCommand.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
            String quertString = @"insert into [12Janr] (Nazvanie_Janra) values('" + textBox1.Text + "');";
            SqlConnection myConnection = new SqlConnection(connect);
            SqlCommand insert = new SqlCommand(quertString, myConnection); myConnection.Open();
            insert.ExecuteNonQuery(); dataGridView1.Rows.Clear();
            string command1 = "Select * from [12Janr]";
            SqlCommand myCommand = new SqlCommand(command1, myConnection);
            SqlDataReader reader = myCommand.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();

            }
            reader.Close();

            myConnection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            textBox1.Clear();
            MessageBox.Show("Успешно добавлено!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox1.Text != "")
                {
                    string zxc = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
                    SqlConnection zxc1 = new SqlConnection(zxc);
                    String quertString = @"update [12Janr] set Nazvanie_Janra='" + textBox1.Text + "' where Id_Janra='" + textBox2.Text + "'";

                    SqlCommand insert = new SqlCommand(quertString, zxc1); zxc1.Open();
                    insert.ExecuteNonQuery(); zxc1.Close();
                    textBox1.Text = "";
                }
               
                dataGridView1.Rows.Clear();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(connect);
                myConnection.Open();
                string command1 = "Select * from [12Janr]";
                SqlCommand myCommand = new SqlCommand(command1, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[2]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();

                }
                reader.Close();

                myConnection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
                textBox2.Text = "";
                MessageBox.Show("Успешно обновлено!");
            }
            else
            {
                MessageBox.Show("Вы не ввели ID для обновления");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user53_db;password=user53;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(connect);
                myConnection.Open();
                String quertString = @"delete from [12Janr] where Id_Janra='" + textBox3.Text + "'";
                SqlCommand delete = new SqlCommand(quertString, myConnection);
                delete.ExecuteNonQuery();
                myConnection.Close();
                dataGridView1.Rows.Clear();
                myConnection.Open();
                string command1 = "Select * from [12Janr]";
                SqlCommand myCommand = new SqlCommand(command1, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[2]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();

                }
                reader.Close();

                myConnection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
                textBox3.Text = "";
                MessageBox.Show("Успешно удалено!");
            }
            else
            {
                MessageBox.Show("Вы не ввели ID для удаления");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
