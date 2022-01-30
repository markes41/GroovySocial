using Groov.Data.Base.Logs;
using Groov.Library.Data.Entities;
using Groov.Library.Data.Manager.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace Groov.Library.Data.Manager
{
    public class User_Manager : Base_Manager<User>
    {
        private readonly GroovContext context;

        public User_Manager()
        {
            this.context = new GroovContext();
        }

        public async override Task<User> Search(User entityModel)
        {
            try
            {
                return await this.context.Users.Where(m =>
                    m.UserName.ToLower().Equals(entityModel.UserName)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "Search()");
                throw;
            }
        }

        public async override Task<IList<User>> GetDataSources()
        {
            try
            {
                return await this.context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "GetDataSources()");
                throw;
            }
        }

        public async override Task<bool> Delete(User entityModel)
        {
            try
            {
                // Set to remove the user
                this.context.Users.Remove(entityModel);

                // Save changes to delete it from database
                return await this.context.SaveChangesAsync() > 0;

            }catch(Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "Delete()");
                throw;
            }
        }
    }
}
