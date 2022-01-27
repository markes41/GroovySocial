using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Users.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Register_Day { get; set; }
        public string City { get; set; }
        public string Biography { get; set; }
    }
}
