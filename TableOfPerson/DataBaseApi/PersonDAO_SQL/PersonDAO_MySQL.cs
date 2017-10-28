using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson
{
    public class PersonDAO_MySQL: PersonDAO_SQL
    {
        MySqlConnection connection = null;
        public PersonDAO_MySQL()
        {
            string MySQLconnString = @"Server=localhost;" +
                                     @"Database=personbd;" +
                                     @"Uid=root;" +
                                     @"Pwd=1111;";

            connection = new MySqlConnection(MySQLconnString);
        }
        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void ExecuteCommand(string cmd)
        {
            DbCommand command = new MySqlCommand();
            command = new MySqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override List<Person> ReadData(string cmd)
        {
            List<Person> listPerson = new List<Person>();

            MySqlCommand sqlCmdPerson = new MySqlCommand(cmd, connection);
            MySqlDataReader readerPerson = sqlCmdPerson.ExecuteReader();
            while (readerPerson.Read())
            {
                //если idPerson уже содержится, то добавляем еще один телефон
                if (listPerson.Exists(x => x.id == readerPerson.GetInt32(0)))
                {
                    listPerson.FirstOrDefault(x => x.id == readerPerson.GetInt32(0)).listOfPhones.Add(new Phone(readerPerson.GetInt32(0), readerPerson.GetString(4)));
                }
                //если idPerson нет в списке
                else
                    listPerson.Add(new Person(readerPerson.GetInt32(0), readerPerson.GetString(1), readerPerson.GetString(2),
                    readerPerson.GetInt32(3), new List<Phone>(new Phone(1, "+38095"))));
            }
            readerPerson.Close();

            return listPerson;
        }
        
    }
}
