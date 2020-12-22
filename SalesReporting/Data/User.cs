using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReporting.Data
{
    public class User
    {
        public string UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
