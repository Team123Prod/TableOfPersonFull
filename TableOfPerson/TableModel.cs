using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson
{
    public class TableModel
    {
        List<Person> persons = null;
        IPerson_DAO db = null;
        IPhone_DAO dbPhone = null;

        public void SetDataBase(string key)
        {
            db = DBFactory.getInstance(key);
            dbPhone = (IPhone_DAO)db;
        }

        public void Create(Person p)
        {
            db.Create(p);
            persons = db.Read();
        }

        public DataTable Read()
        {
            DataTable dt = new DataTable();
            persons = db.Read();

            dt.Columns.Add(new DataColumn("Id"));
            dt.Columns.Add(new DataColumn("Fn"));
            dt.Columns.Add(new DataColumn("Ln"));

            foreach (Person person in persons)
            {
                DataRow row = dt.NewRow();
                row[0] = person.id;
                row[1] = person.fn;
                row[2] = person.ln;
                dt.Rows.Add(row);
            }

            return dt;
        }
        public DataTable Search(string searchLine)
        {
            DataTable dt = new DataTable();
            persons = db.Search(searchLine);

            dt.Columns.Add(new DataColumn("Id"));
            dt.Columns.Add(new DataColumn("Fn"));
            dt.Columns.Add(new DataColumn("Ln"));

            foreach (Person person in persons)
            {
                DataRow row = dt.NewRow();
                row[0] = person.id;
                row[1] = person.fn;
                row[2] = person.ln;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public void Update(Person p)
        {
            db.Update(p);
        }
        public void AddPhone(int idPerson, string phone)
        {
            dbPhone.AddPhone(idPerson, phone);
        }

        public void Delete(int id)
        {
            Person per = null;
            foreach (Person p in persons)
            {
                if (id == p.id)
                {
                    per = p;
                }
            }
            db.Delete(per);
        }
        public void DeletePhone(int idPerson, string numbersOfPhone)
        {
            dbPhone.DeletePhone(idPerson, numbersOfPhone);
        }

        public List<Person> ReturnPersons()
        {
            return persons;
        }
    }
}
