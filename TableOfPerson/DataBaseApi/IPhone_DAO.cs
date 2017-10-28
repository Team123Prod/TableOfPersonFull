using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public interface IPhone_DAO
    {
        void DeletePhone(int id);
        void AddPhone(int idPerson, string phone);
    }
}
