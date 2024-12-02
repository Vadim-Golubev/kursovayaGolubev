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
    public partial class Clients : Form
    {
        private string conStr = data.conStr;

        public Clients()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menushka menushka = new Menushka();
            this.Visible = false;
            menushka.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Redactor redactor = new Redactor();
            this.Visible = false;
            redactor.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(conStr);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT name AS `имя`, surname AS `фамилия` , number_phone AS `номер телефона`FROM client ", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dobavlenieclient dobavlenieclient = new Dobavlenieclient();
            this.Visible = false;
            dobavlenieclient.ShowDialog();
            this.Close();
        }
    }
}
