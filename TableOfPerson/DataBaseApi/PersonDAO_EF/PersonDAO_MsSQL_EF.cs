using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public class PersonDAO_MsSQL_EF: IPerson_DAO, IPhone_DAO
    {
        public List<Person> Read()
        {
            using (PersonContext context = new PersonContext())
            {
                return context.Persons.Include(p => p.listOfPhones).ToList();
            }
        }
        public void Create(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                context.Persons.Add(p);
                context.SaveChanges();
            }
        }
        public void Delete(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                foreach (var phone in p.listOfPhones)
                {
                    DeletePhone(phone);
                }
                Person pToDel = context.Persons.First(x => x.id == p.id);
                context.Persons.Remove(pToDel);
                context.SaveChanges();
            }
        }
        private void DeletePhone(Phone phone)
        {
            using (PersonContext context = new PersonContext())
            {
                Phone pToDel = context.Phones.First(x => x.id == phone.id);
                context.Phones.Remove(pToDel);
                context.SaveChanges();
            }
        }
        
        public void Update(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                Person original = context.Persons.FirstOrDefault(x => x.id == p.id);
                context.Entry(original).CurrentValues.SetValues(p);
                context.SaveChanges();
            }
        }
        public void AddPhone(int idPerson, string phone)  // ------
        {
            using (PersonContext context = new PersonContext())
            {
                //Person original = context.Persons.FirstOrDefault(x => x.id == idPerson);
                //original.listOfPhones.Add(new Phone());

                context.Phones.Add(new Phone());
                context.SaveChanges();
            }
        }

        public void DeletePhone(int idPerson, string numbersOfPhone)  // -------
        {
            using (PersonContext context = new PersonContext())
            {
                Phone pToDel = context.Phones.First(x => x.phone == numbersOfPhone);
                context.Phones.Remove(pToDel);
                context.SaveChanges();
            }
        }
        
        public List<Person> Search(string searchLine)
        {
            throw new NotImplementedException();
        }

    }
}
