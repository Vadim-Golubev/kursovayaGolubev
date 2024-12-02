using kursovayaGolubev;
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

namespace курсовая_работа
{
    public partial class Dobavlenieclient : Form
    {
        private string conStr = data.conStr;

        public Dobavlenieclient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            this.Visible = false;
            clients.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Name.Text != "" && Surname.Text != "" && Number_phone.Text != "")
            {
                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand($@"Insert Into client
(name,surname,number_phone)
Values ('{Name.Text}','{Surname.Text}','{Number_phone.Text}')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Вы успешно добавили нового клиента!");
                Name.Text = "";
                Surname.Text = "";
                Number_phone.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Dobavlenieclient_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(conStr);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Name AS `Имя`, Surname AS `Фамилия`,Number_phone `Контактный номер` FROM client", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
