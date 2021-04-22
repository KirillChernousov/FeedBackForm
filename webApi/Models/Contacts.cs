using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class Contacts
    {
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}

