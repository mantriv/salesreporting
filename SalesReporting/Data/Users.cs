using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReporting.Data
{
    public class UserData
    {
        public List<User> Users;
        public UserData()
        {
            Users = new List<User>()
            {
                new User()
                {
                    UUID = Guid.NewGuid().ToString(),
                    EmailId = "john.doe@gmail.com",
                    Password = "Password#1",
                    FirstName = "John",
                    LastName = "Doe"
                },
                 new User()
                {
                    UUID = Guid.NewGuid().ToString(),
                    EmailId = "jane.doe@gmail.com",
                    Password = "Password#1",
                    FirstName = "Jane",
                    LastName = "Doe"
                }
            };
        }


    }
}
