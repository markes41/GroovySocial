using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroovySocial.Interfaces
{
    public interface IModelBase<T>
    {
        /// <summary>
        /// Generic method to search a register
        /// </summary>
        Task<bool> Search(T entityModel);

        /// <summary>
        /// Generic method to Save a register
        /// </summary>
        Task<bool> Save(T entityModel);

        /// <summary>
        /// Generic method to Delete a register
        /// </summary>
        Task<bool> Delete(int id);
    }
}
