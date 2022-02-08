using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Base.Enums
{
    public class CommonEnums
    {
        public enum ErrorCode
        {
            Base = 0,
            User = 1,
            Projection = 2
        }

        public enum UserStatus
        {
            Active = 0,
            Blocked = 1,
            Eliminated = 2
        }
    }
}
