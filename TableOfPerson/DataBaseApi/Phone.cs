using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    [Serializable]
    public class Phone
    {
        [BsonId]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; } //id phone
        public int idPerson { get; set; }
        public string phone { get; set; }

        public Phone()
        {

        }
        public Phone(int id, int idPerson, string phone)
        {
            this.id = id;
            this.idPerson = idPerson;
            this.phone = phone;
        }
    }
}
