using Groov.Data.Base.Logs;
using Groov.Library.Data;
using Groov.Library.Data.Entities;
using Groov.Library.Data.Manager;
using GroovySocial.Helpers;
using GroovySocial.Interfaces;
using GroovySocial.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace GroovySocial.Models
{
    public class LoginModel : IModelBase<UserViewModel>
    {
        

        private User_Manager manager;

        public string ErrorMessage { get => "Los datos introducidos son erróneos."; set => throw new NotImplementedException(); }

        public LoginModel()
        {
            this.manager = new User_Manager();
        }

        public async Task<bool> Save(UserViewModel entityModel)
        {
            try
            {
                // Convert viewmodel to original model
                var user = MapperHelper.ViewModelToModel(entityModel);
                
                // return the result
                return await this.manager.Save(user, entityModel.Id == 0);
                
            }catch(Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "Save()");
                return false;
            }
        }

        public async Task<bool> Search(UserViewModel entityModel)
        {
            try
            {
                // Search an user in datbase
                var result = await this.manager.Search(new User() { UserName = entityModel.UserName });

                // If the user exist return true
                if (result != null)
                    return true;

                // If user not exist return an error message and a false statment
                this.ErrorMessage = "No se ha encontrado un usuario con las credenciales ingresadas.";
                return false;

            }
            catch(Exception ex)
            {
                // If any error happen will be saved in a Log
                ApplicationLog.LogError(ex, ErrorCode.User, "Search()");
                return false;
            }
        }

        public async Task<bool> Delete(UserViewModel entityModel)
        {
            try
            {
                var user = await this.manager.Search(new User() { UserName = entityModel.UserName });

                return await this.manager.Delete(user);
            }
            catch (Exception ex)
            {
                // If any error happen will be saved in a Log
                ApplicationLog.LogError(ex, ErrorCode.User, "Delete()");
                return false;
            }
        }
    }
}
