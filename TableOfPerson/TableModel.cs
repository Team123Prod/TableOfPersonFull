using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TableOfPerson
{
    public class TableModel
    {
        List<Person> persons = null;
        IPerson_DAO db = null;

        public void SetDataBase(string key)
        {
            db = DBFactory.getInstance(key);
        }

        public void Create(Person p)
        {
            db.Create(p);
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
        public void AddPhone(int id, string phone)
        {
            db.AddPhone(id, phone);
        }

        public void Delete(int id)
        {
            Person per = null;
            foreach(Person p in persons)
            {
                if (id == p.id)
                {
                    per = p;
                }
            }
            db.Delete(per);
        }

        public List<Person> ReturnPersons()
        {
            return persons;
        }
    }
}
