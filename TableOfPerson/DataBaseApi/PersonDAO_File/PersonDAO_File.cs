using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public abstract class PersonDAO_File: IPerson_DAO, IPhone_DAO
    {
        protected string path = "";
        public PersonDAO_File(string path)
        {
            this.path = path;
        }

        public void Create(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.id == person.id);
            if (add == null)
            {
                people.Add(person);
            }
            Save(people);
        }

        public void Delete(Person person)
        {
            List<Person> people = Load();
            Person del = people.Find((x) => x.id == person.id);
            if (del != null)
            {
                people.Remove(del);
            }
            Save(people);
        }

        public void Update(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.id == person.id);
            if (add != null)
            {
                int i = people.IndexOf(add);
                people.ElementAt(i).fn = person.fn;
                people.ElementAt(i).ln = person.ln;
                people.ElementAt(i).age = person.age;
            }
            Save(people);
        }

        public List<Person> Read()
        {
            return Load();
        }

        abstract protected List<Person> Load();
        abstract protected void Save(List<Person> people);

        public void AddPhone(int idPerson, string phone)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.id == idPerson);
            if (add != null)
            {
                int i = people.IndexOf(add);
                int idP = (people.ElementAt(i).listOfPhones.Count + people.ElementAt(i).fn.Length) * 3;
                people.ElementAt(i).listOfPhones.Add(new Phone(idP, idPerson, phone));
            }
            Save(people);
        }

        public List<Person> Search(string searchLine)
        {
            List<Person> persons = Load();
            List<Person> list = new List<Person>();
            foreach (Person p in persons)
            {
                if (searchLine == p.id.ToString() || searchLine == p.fn || searchLine == p.ln || searchLine == p.age.ToString())
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public void DeletePhone(int idPerson, string numbersOfPhone)
        {
            List<Person> people = Load();
            Person p = people.Find((x) => x.id == idPerson);
            Phone phDel = p.listOfPhones.Find((x) => x.phone == numbersOfPhone);
            p.listOfPhones.Remove(phDel);
            Save(people);
        }
    }
}
