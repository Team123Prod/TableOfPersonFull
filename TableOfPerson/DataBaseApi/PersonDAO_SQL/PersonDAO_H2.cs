using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.sql;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson
{
    public class PersonDAO_H2: PersonDAO_SQL
    {
        Statement state = null;
        Connection connection = null;
        public PersonDAO_H2()
        {
            string connectionH2 = "jdbc:h2:tcp://localhost/~/test";
            string user = "sa";
            string pass = "1111";
            
            org.h2.Driver.load();
            connection = DriverManager.getConnection(connectionH2, user, pass);
        }


        protected override List<Person> ReadData(string cmd)
        {
            ResultSet rs = state.executeQuery(cmd);
            List<Person> listPerson = new List<Person>();
            while (rs.next())
            {
                //listPerson.Add(new Person(rs.getInt("ID"), rs.getString("FIRSTNAME"), rs.getString("LASTNAME"), rs.getInt("AGE")));
                //если idPerson уже содержится, то добавляем еще один телефон
                if (listPerson.Exists(x => x.id == rs.getInt(0)))
                {
                    listPerson.FirstOrDefault(x => x.id == rs.getInt(0)).listOfPhones.Add(new Phone(rs.getInt(4), rs.getInt(5), rs.getString(6)));
                }
                //если у Person не телефонов
                //else if (rs.wasNull(rs.getInt("IdPhones")) || rs.wasNull(rs.getInt("Phone")))
                //{
                //    listPerson.Add(new Person(rs.getInt(0), rs.getString(1), rs.GetString(2),
                //        rs.getInt(3), new List<Phone>()));
                //}
                //если idPerson нет в списке
                else
                    listPerson.Add(new Person(rs.getInt(0), rs.getString(1), rs.getString(2),
                        rs.getInt(3), new List<Phone>() { new Phone(rs.getInt(4), rs.getInt(5), rs.getString(6)) }));
            }
            rs.close();
            return listPerson;
            
        }


        protected override void CloseConnection()
        {
            state.close();
        }

        protected override void ExecuteCommand(string cmd)
        {
            state.executeUpdate(cmd);
        }

        protected override void OpenConnection()
        {
            state = connection.createStatement();
        }
        
    }
}
