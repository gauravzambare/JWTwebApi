using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTwebApi.Models
{
    public class Account
    {
        public string id { get; set; }
        public DateTime dateCreated { get; set; }
        public string accountType { get; set; }
        public string ownerId { get; set; }        
    }
}
