using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTwebApi.Models
{
    public class Owner
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string address { get; set; }
        public List<Account> accounts { get; set; }
    }
}
