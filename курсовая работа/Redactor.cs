using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace kursovayaGolubev
{
    public partial class Redactor : Form
    {
        public Redactor()
        {
            InitializeComponent();
        }
        private string conStr = data.conStr;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Вернуться_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            this.Visible = false;
            clients.ShowDialog();
            this.Close();
        }

        private void Redactor_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(conStr);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT name AS `имя`, surname AS `фамилия` , number_phone AS `номер телефона`FROM client ", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
