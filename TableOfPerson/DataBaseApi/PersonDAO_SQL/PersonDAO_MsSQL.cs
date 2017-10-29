using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson
{
    public class PersonDAO_MsSQL : PersonDAO_SQL
    {
        SqlConnection connection = null;
        public PersonDAO_MsSQL()
        {

            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                @"D:\COURSE\TABLE_DB\TableOfPersonFull\TableOfPerson\PeopleDB.mdf;" +
                "Integrated Security=True";

            connection = new SqlConnection(strConn);
        }

        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override void ExecuteCommand(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
        }

        protected override List<Person> ReadData(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

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
