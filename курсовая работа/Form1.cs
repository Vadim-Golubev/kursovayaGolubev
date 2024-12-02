using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using курсовая_работа;

namespace kursovayaGolubev
{
    public partial class Form1 : Form
    {
        string conString = data.conStr;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                string login = textBox1.Text.ToString();
                string hashPassword = string.Empty;
                string role = string.Empty;
                MySqlConnection con = new MySqlConnection(conString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand($"Select * From Users Where Login = '{login}'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                hashPassword = GetHashPass(passwd.Text.ToString());

                if (hashPassword == dt.Rows[0].ItemArray.GetValue(2).ToString())
                {
                    role = dt.Rows[0].ItemArray.GetValue(3).ToString();
                    data.role = role;
                    MessageBox.Show("Вы успешно авторизовались");
                    if (role == "Admin")
                    {
                    Menushka menushka = new Menushka();
                        this.Visible = false;
                    menushka.ShowDialog();
                        this.Close();
                    }
                    else if (role == "Manager")
                    {
                        Manager manager = new Manager();
                        this.Visible = false;
                        manager.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                else
            {
                MessageBox.Show("Неверный пароль");
            }
           
        }

        private string GetHashPass(object p)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public static string GetHashPass(string password)
        {

            byte[] bytesPass = Encoding.UTF8.GetBytes(password);

            SHA256Managed hashstring = new SHA256Managed();

            byte[] hash = hashstring.ComputeHash(bytesPass);

            string hashPasswd = string.Empty;

            foreach (byte x in hash)
            {

                hashPasswd += String.Format("{0:x2}", x);
            }

            hashstring.Dispose();

            return hashPasswd;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
