using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordHashing.Models
{
    public class User
    {

        public User()
        {
        }

        public string Email => "test@test.com";
        public string Password { get; set; }
    }

}
