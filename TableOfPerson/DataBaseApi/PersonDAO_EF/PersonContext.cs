using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public class PersonContext: DbContext
    {
        public PersonContext() 
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\COURSE\TABLE_DB\TableOfPersonFull Last\TableOfPerson\DB_EF.mdf;Integrated Security=True")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
