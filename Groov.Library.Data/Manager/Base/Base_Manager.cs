using Groov.Data.Base.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace Groov.Library.Data.Manager.Base
{
    public abstract class Base_Manager<T> where T : class
    {
        /// <summary>
        /// Bring a list of objects from database
        /// </summary>
        public abstract Task<IList<T>> GetDataSources();

        /// <summary>
        /// Bring a determinate object
        /// </summary>
        public abstract Task<T> Search(T entityModel);

        /// <summary>
        /// Delete any register in database
        /// </summary>
        public abstract Task<bool> Delete(T entityModel);

        /// <summary>
        /// Save any entity in database 
        /// </summary>
        public static async Task<bool> Save(T entityModel, bool isNew)
        {
            try
            {
                // Initialize the context
                var context = new GroovContext();

                // Check if a new register or it's an exist one
                if (isNew)
                    context.Entry<T>(entityModel).State = EntityState.Added;
                else
                    context.Entry<T>(entityModel).State = EntityState.Modified;

                // Check any error while pre-saving in database
                var err = context.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException();

                // Validate if the changes was saved
                var result = await context.SaveChangesAsync() > 0;

                // Dispose the context
                context.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "BaseSave()");
                throw;
            }
        }
    }
}
