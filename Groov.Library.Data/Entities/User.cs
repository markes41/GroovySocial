using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Library.Data.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Register_Date { get; set; }
        public string City { get; set; }
        public string Biography { get; set; }
        public byte[] Profile_Image { get; set; }
    }
}
