using Groov.Data.Users;
using Groov.Data.Users.Date;
using GroovySocial.Interfaces;
using GroovySocial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroovySocial.Models
{
    public class LoginModel : IModelBase<UserViewModel>
    {
        public string ErrorMessage { get; set; } = "Los datos introducidos son erróneos.";

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save(UserViewModel entityModel)
        {
            var result = await UserDate.GetUserByUsername(entityModel.UserName, entityModel.Password);

            if (result)
            {
                return true;
            }
            else
            {
                this.ErrorMessage = "No se ha encontrado un usuario con las credenciales ingresadas.";
                return false;
            }
        }

        public Task<bool> Search(UserViewModel entityModel)
        {
            throw new NotImplementedException();
        }
    }
}
