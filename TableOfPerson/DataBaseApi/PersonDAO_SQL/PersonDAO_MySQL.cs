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
    public class PersonDAO_MySQL : PersonDAO_SQL
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
            MySqlCommand sqlCmd = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = sqlCmd.ExecuteReader();

            List<Person> listPerson = new List<Person>();
            while (reader.Read())
            {
                //если idPerson уже содержится, то добавляем еще один телефон
                if (listPerson.Exists(x => x.id == reader.GetInt32(0)))
                {
                    listPerson.FirstOrDefault(x => x.id == reader.GetInt32(0)).listOfPhones.Add(new Phone(reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6)));
                }
                //если у Person не телефонов
                else if (reader.IsDBNull(reader.GetOrdinal("IdPhones")) || reader.IsDBNull(reader.GetOrdinal("Phone")))
                {
                    listPerson.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetInt32(3), new List<Phone>()));
                }
                //если idPerson нет в списке
                else
                    listPerson.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetInt32(3), new List<Phone>() { new Phone(reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6)) }));
            }
            reader.Close();

            return listPerson;
        }

    }
}
