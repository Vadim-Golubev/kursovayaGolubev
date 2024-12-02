using MySql.Data.MySqlClient;
using System;

namespace kursovayaGolubev
{
    internal class MySqlConnection1
    {
        private object conString;

        public MySqlConnection1(object conString)
        {
            this.conString = conString;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        public static implicit operator MySqlConnection(MySqlConnection1 v)
        {
            throw new NotImplementedException();
        }
    }
}