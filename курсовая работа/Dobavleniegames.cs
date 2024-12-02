using kursovayaGolubev;
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

namespace курсовая_работа
{
    public partial class Dobavleniegames : Form
    {
        public Dobavleniegames()
        {
            InitializeComponent();
        }
        private string conStr = data.conStr;

        private void button2_Click(object sender, EventArgs e)
        {
            Games games = new Games();
            this.Visible = false;
            games.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Dobavleniegames_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(conStr);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT tittle AS `название `, genre AS `жанр`,rating `рейтинг` FROM games", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (Name.Text != "" && zhanr.Text != "" && Name.Text != "" && zhanr.Text != "" && rang.Text != "" && rang.Text != "")
            {
                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand($@"Insert Into games
(tittle,genre,rating)
Values ('{Name.Text}','{zhanr.Text}','{Convert.ToInt32(rang.Text)}')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Новая игра добавлена!");
                Name.Text = "";
                zhanr.Text = "";
                rang.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        
    }

        
    }
}

