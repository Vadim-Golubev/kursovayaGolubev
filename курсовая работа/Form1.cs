using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using курсовая_работа;

namespace kursovayaGolubev
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        //wfwfwfefWF
        //ERGEARGREGREG
        string conString = data.conStr;
        private string captchaText;
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

            string conString = $@"host=127.0.0.1;uid=root;pwd=root; database = igrovoy_club";
            string login = textBox1.Text.ToString();


            if (passwd.Text == localAdmin.password && textBox1.Text == localAdmin.login)
            {
                this.Hide();
                ImportExport backup = new ImportExport();
                data.role = "локальный";
                backup.Show();
            }
            else
            {
                try
                {
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
                            //Manager manager = new Manager();
                            //  this.Visible = false;
                            //  manager.ShowDialog();
                            //  this.Close();
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
                catch
                {
                    Captha();
                }


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
        private void Captha() //Создание капчи
        {
            button4.Enabled = true;
            textBox2.Enabled = true;
            CaptchaToImage();
            button2.Enabled = false;
            textBox1.Enabled = false;
            passwd.Enabled = false;
            textBox1.Text = null;
            passwd.Text = null;
            this.Width = 930;
        }
        private void CaptchaToImage() //Отрисовка капчи
        {
            Random random = new Random();
            string chars = "QWERTYUIOPLKJHGFDSAZXCVBNM0123456789qwertyuiopasdfghjklzxcvbnm";
            captchaText = ""; for (int i = 0; i < 5; i++)
            {
                captchaText += chars[random.Next(chars.Length)];
            }
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias; graphics.Clear(Color.White);
            Font font = new Font("Arial", 20, FontStyle.Bold);
            for (int i = 0; i < 5; i++)
            {
                PointF point = new PointF(i * 20, 0);
                graphics.TranslateTransform(100, 50);
                graphics.RotateTransform(random.Next(-10, 10));
                graphics.DrawString(captchaText[i].ToString(), font, Brushes.Black, point);
                graphics.ResetTransform();
            }
            for (int i = 0; i < 10; i++)
            {
                Pen pen = new Pen(Color.Black, random.Next(2, 5));
                int x1 = random.Next(pictureBox1.Width);
                int y1 = random.Next(pictureBox1.Height);
                int x2 = random.Next(pictureBox1.Width);
                int y2 = random.Next(pictureBox1.Height); graphics.DrawLine(pen, x1, y1, x2, y2);
            }
            pictureBox1.Image = bmp;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Captha();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == captchaText)
            {
                MessageBox.Show("Успешный ввод");
                button2.Enabled = true;
                textBox1.Enabled = true;
                passwd.Enabled = true;
                textBox2.Text = null;
                this.Width = 577;
            }
            else //Блокировка системы на 10 секунд посленеудачного ввода
            {
                MessageBox.Show("Неверный ввод, блокировка системы на 10 секунд");
                button4.Enabled = false;
                Thread.Sleep(10000);
                button4.Enabled = true;
                Captha();
            }
        }
    }
 
}
