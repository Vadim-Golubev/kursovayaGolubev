using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using курсовая_работа;

namespace kursovayaGolubev
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        private string conStr = data.conStr;

        private void button2_Click(object sender, EventArgs e)
        {
            Menushka menushka = new Menushka();
            this.Visible = false;
            menushka.ShowDialog();
            this.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(conStr);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT login AS `Логин`, password AS `Пароль` , role AS `Роль`FROM users ", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
