using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TableOfPerson.DataBaseApi.PersonDAO_File;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_CSV: PersonDAO_File
    {
        public PersonDAO_CSV() 
            : base("CSV_DB.txt")
        { }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                people.Add(FromCSV(lines[i]));
            }
            return people;
        }


        protected override void Save(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("Id, Fn, Ln, Age, listOfPhones");
            foreach (Person person in people)
            {
                file.WriteLine(ToCSV(person));
            }
            file.Close();
        }


        private string ToCSV(Person person)
        {
            string str = "";
            str += person.id + ", ";
            str += person.fn + ", ";
            str += person.ln + ", ";
            str += person.age + ", ";
            str += "\"[";
            foreach (Phone ph in person.listOfPhones)
            {
                str += "{id:" + ph.id + ",";
                str += "idPerson:" + ph.idPerson + ", ";
                str += "phone:" + ph.phone + " }";
            }
            str += "]\"";
            return str;
        }

        private Person FromCSV(string csv_string)
        {
            Person person = new Person();
            string[] args = csv_string.Split(',');
            person.id = Int32.Parse(args[0].Trim());
            person.fn = args[1].Trim();
            person.ln = args[2].Trim();
            person.age = Int32.Parse(args[3].Trim());
            person.listOfPhones = FromPhoneCSV(csv_string);
            return person;
        }
        private List<Phone> FromPhoneCSV(string csv_string)
        {
            string[] str = csv_string.Split(':', ',', '}');
            List<Phone> ListPhone = new List<Phone>();
            try
            {
                for (int i = 5; i < str.Length; i += 6)
                {
                    ListPhone.Add(new Phone(Int32.Parse(str[i]), Int32.Parse(str[i + 2]), str[i + 4]));
                }
            }
            catch(Exception e)
            {
            }

            return ListPhone;
        }
    }
}
