using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groov.Data.Base.Base
{
    public abstract class ApplicationBase<T> where T : class
    {
        /// <summary>
        /// Implementation of Save 
        /// </summary>
        protected abstract Task<bool> Save(T entityModel);

        /// <summary>
        /// Bring a list of objects from database
        /// </summary>
        protected abstract Task<IList<T>> GetDataSources();

        /// <summary>
        /// Save changes of any entity in database
        /// </summary>
        public async Task<bool> SaveBaseAsync(T entityModel, bool isNew, DbContext context)
        {
            try
            {
                // Check if a new register or it's an exist one
                if (isNew)
                    context.Entry<T>(entityModel).State = EntityState.Added;
                else
                    context.Entry<T>(entityModel).State = EntityState.Modified;

                // Check any error while pre-saving in database
                var err = context.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException();

                // Return true if the changes was saved or false if not
                return await context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        
    }
}
