using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TestToDoUus.Models
{
    [DataContract]
    public class Todo
    {
        [DataMember(Name = "idtable")]
        public int idtable { get; set; }

        [DataMember(Name = "dateexpire")]
        public DateTime dateexpire { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "complete")]
        public decimal complete { get; set; }

        [DataMember(Name = "isdone")]
        public int isdone { get; set; }

    }
}
