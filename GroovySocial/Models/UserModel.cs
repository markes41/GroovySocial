using GroovySocial.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroovySocial.Models
{
    public class UserModel
    {
        private SessionHelper session;

        public UserModel(SessionHelper session)
        {
            this.session = session;
        }

        public static bool SaveUser()
        {
            return false;
        }

        public static bool DeleteUser()
        {
            return false;
        }

        public static bool CheckUser()
        {
            return false;
        }
    }
}
