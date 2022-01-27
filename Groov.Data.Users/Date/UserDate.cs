using Groov.Data.Base.Base;
using Groov.Data.Base.Logs;
using Groov.Data.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Users.Date
{
    public class UserDate : ApplicationBase<User>
    {
        protected override async Task<IList<User>> GetDataSources()
        {
            try
            {
                using (var db = new UserContext())
                {
                    return await db.Users.ToListAsync();
                }
            }catch(Exception ex)
            {
                ApplicationLog.LogError(ex, "Users");
                throw;
            }
        }

        protected override async Task<bool> Save(User entityModel)
        {
            try
            {
                using (var db = new UserContext())
                {
                    return await base.SaveBaseAsync(entityModel, entityModel.Id == 0, db);
                }

            }catch(Exception ex)
            {
                ApplicationLog.LogError(ex, "Users");
                throw;
            }
        }

        public Task<bool> SaveUser(User entity)
        {
            return this.Save(entity);
        }

        public async static Task<bool> GetUserByUsername(string username, string password)
        {
            return await Task<bool>.Factory.StartNew(() =>
            {
                try
                {
                    using (var db = new UserContext())
                    {
                        return db.Users.Where(m =>
                        m.UserName.ToLower().Equals(username)
                        && m.Password.Equals(password)).Any();
                    }
                }
                catch (Exception ex)
                {
                    ApplicationLog.LogError(ex, "Users");
                    throw;
                }
            });
        }
    }
}
