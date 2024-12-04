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
using kursovayaGolubev;
using System.IO;

namespace курсовая_работа
{
    public partial class ImportExport : Form
    {
        //wfgwefwefwefewf
        //flufvlvlvl
        public ImportExport()
        {
            InitializeComponent();
        }
        private static string conStr = data.conStr;
        string conString = $@"host=127.0.0.1;uid=root;pwd=root;";
        private void button3_Click(object sender, EventArgs e)
        {
            Menushka menushka = new Menushka();
            this.Visible = false;
            menushka.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV файлы с разделителем ';' (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    string filePath = openFileDialog.FileName;
                    ImportExport.ImportData(filePath, comboBox1.SelectedItem.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string backupPath = "Backup\\Structure.sql";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    string script = File.ReadAllText(backupPath);
                    MySqlScript sqlScript = new MySqlScript(con, script);
                    sqlScript.Execute();
                    con.Close();
                }
                MessageBox.Show("Uspesno!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreDatabaseStructure(string filePath)
        {
            string sqlScript = File.ReadAllText(filePath);
            ImportExport.InsertDataOnDb(sqlScript);
        }

        private static long InsertDataOnDb(string query)
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = conStr;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.LastInsertedId;
            }
        }

        public static void ImportData(string filePath, string tablename)
        {
            int counter = 0;
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = conStr;
                con.Open();

                bool isFirstStr = true;

                Encoding encoding = Encoding.GetEncoding(1251);

                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isFirstStr) { isFirstStr = false; }
                        else
                        {
                            // Предполагается, что данные разделены запятыми
                            var values = line.Split(';');

                            string query = string.Empty;

                            switch (tablename)
                            {
                                case "client":
                                    query = $"INSERT INTO `{tablename}` (idclient, name, surname, number_phone) VALUES ({values[0]}, {values[1]}, {values[2]}, {values[3]})";
                                    break;
                                case "games":
                                    query = $"INSERT INTO `{tablename}` (idgames, tittle, genre, rating) VALUES ({values[0]}, {values[1]}, {values[2]}, {values[3]})";
                                    break;
                                case "rooms":
                                    query = $"INSERT INTO `{tablename}` (idRooms, status) VALUES ({values[0]}, {values[1]})";
                                    break;
                                case "session":
                                    query = $"INSERT INTO `{tablename}` (idSession, room_id, user_id, status) VALUES ({values[0]},{values[1]}, {values[2]}, {values[3]})";
                                    break;
                                case "users":
                                    query = $"INSERT INTO `{tablename}` (iduser, login, password, role) VALUES ({values[0]}, {values[1]}, {values[2]}, {values[3]})";
                                    break;

                            }

                            try
                            {
                                using (MySqlCommand command = new MySqlCommand(query, con))
                                {
                                    command.ExecuteNonQuery();
                                    counter++;
                                }
                            }
                            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
                        }
                    }
                }
                MessageBox.Show($"Данные успешно импортированы. Добавлено {counter} записей");
            }
        }

        private void ImportExport_Load(object sender, EventArgs e)
        {
            
        }
    }
}

