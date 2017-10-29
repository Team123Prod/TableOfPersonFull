using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TableOfPerson.DataBaseApi
{
    public class PersonDAO_MongoDB: IPerson_DAO, IPhone_DAO
    {
        IMongoCollection<Person> persons = null;
        IMongoCollection<Phone> phones = null;
        public PersonDAO_MongoDB()
        {
            string strConn = @"mongodb://localhost:27017";

            MongoClient client = new MongoClient(strConn);
            IMongoDatabase database = client.GetDatabase("mongoPerson");
            persons = database.GetCollection<Person>("people");
            phones = database.GetCollection<Phone>("phones");
        }
        
        public void Create(Person person)
        {
            if (persons.Find(x => x.id == person.id).ToList().Count == 0)
            {
                persons.InsertOne(person);
            }
        }

        public void Delete(Person person)
        {
            persons.DeleteOne(x => x.id == person.id);
        }

        public List<Person> Read()
        {
            List<Person> listPerson = new List<Person>();
            listPerson = persons.Find(x => true).ToList();
            return listPerson;
        }
        
        public void Update(Person person)
        {
            persons.ReplaceOne(x => x.id == person.id, person);
        }
        public void AddPhone(int id, string phone)
        {
            List<Phone> phoneList = phones.Find(x => true).ToList();
            // ---------------------
        }
        
        public void DeletePhone(int idPerson, string numbersOfPhone)
        {
            throw new NotImplementedException();
        }

        public List<Person> Search(string searchLine)
        {
            throw new NotImplementedException();
        }
    }
}
