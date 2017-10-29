using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_JSON: PersonDAO_File
    {
        public PersonDAO_JSON() 
            : base("JSON_DB.txt")
        {    }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string line = File.ReadAllText(path);
            if (line.Length != 0)
            {
                line = (line.Remove(0, line.IndexOf('[') + 1));
                line = line.Remove(line.Length - 2, 2);
            }
            int i = 0;
            while (i < line.Length)
            {
                string str = "";
                while (line.ElementAt(i) != '}')
                {
                    str += line.ElementAt(i++);
                }
                str += line.ElementAt(i++);
                i++;
                people.Add(FromJSON(str));
            }
            return people;

        }
        
        protected override void Save(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.Write("{ Persons : [");
            for (int i = 0; i < people.Count; i++)
            {
                file.Write(ToJSON(people.ElementAt(i)) + ((i != (people.Count - 1)) ? "," : ""));
            }
            file.Write("]}");
            file.Close();
        }
        
        private string ToJSON(Person person)
        {
            string str = "{";
            str += $"Id: {person.id},";
            str += $"FirstName: {person.fn},";
            str += $"LastName: {person.ln},";
            str += $"Age: {person.age},";
            str += $"listOfPhones: ";
            foreach (Phone ph in person.listOfPhones)
            {
                str += "{id:" + ph.id + ",";
                str += "idPerson:" + ph.idPerson + ", ";
                str += "phone:" + ph.phone + " };";
            }
 
            str += "}";
            return str;
        }
        private Person FromJSON(string json_string)
        {
            Person person = new Person();
            string[] args = json_string.Split(':', ',', '}', ']');
            person.id = Int32.Parse(args[1].Trim());
            person.fn = args[3].Trim();
            person.ln = args[5].Trim();
            person.age = Int32.Parse(args[7].Trim());
            person.listOfPhones = FromPhoneJSON(json_string);
            return person;
        }
        private List<Phone> FromPhoneJSON(string json_string)
        {
            string[] str = json_string.Split(':', ',', '}', ';', ']');
            List<Phone> ListPhone = new List<Phone>();
            try
            {
                for (int i = 10; i < str.Length; i += 6)
                {
                    ListPhone.Add(new Phone(Int32.Parse(str[i]), Int32.Parse(str[i + 2]), str[i + 4]));
                }
            }
            catch (Exception e)
            { }


            return ListPhone;
        }

    }
}
