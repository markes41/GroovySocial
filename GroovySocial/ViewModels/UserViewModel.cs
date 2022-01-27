using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroovySocial.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Register_Day { get; set; }
        public string City { get; set; }
        public string Biography { get; set; }
        public bool Remember { get; set; }
    }
}
