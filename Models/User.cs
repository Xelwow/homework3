using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_API.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string city { get; set; }
    }
}
