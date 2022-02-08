using Groov.Data.Base.Custom;
using Groov.Data.Base.Logs;
using Groov.Library.Data;
using Groov.Library.Data.Entities;
using Groov.Library.Data.Manager;
using Groov.Web.Helpers;
using GroovySocial.Helpers;
using GroovySocial.Interfaces;
using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Groov.Data.Base.Enums.CommonEnums;

namespace GroovySocial.Models
{
    public class LoginModel : IModelBase<UserViewModel>
    {

        private User_Manager manager;

        public string ErrorMessage { get => "Los datos introducidos son erróneos."; set { } }

        public LoginModel()
        {
            this.manager = new User_Manager();

        }

        public async Task<bool> Save(UserViewModel entityModel)
        {
            try
            {
                var user = new User();

                // Convert viewmodel to original model
                Mapper.CopyProperties(entityModel, user);
                
                // Return the result
                return await User_Manager.Save(user, entityModel.Id == 0);
                
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
                // Search an user in database
                var user = await this.manager.Search(new User() { UserName = entityModel.UserName });

                if (user != null)
                    return true;

                // Capture the error
                this.ErrorMessage = "No se ha encontrado un usuario con las credenciales ingresadas.";
                return false;

            }
            catch(Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "Search()");
                return false;
            }
        }

        public async Task<bool> Delete(UserViewModel entityModel)
        {
            try
            {
                // Search any user
                var user = await this.manager.Search(new User() { UserName = entityModel.UserName });

                // If user has value will delete it, otherwise will return false
                if (user != null)
                    return await this.manager.Delete(user);

                this.ErrorMessage = "No se ha encontrado el usuario a borrar.";
                return false;
            }
            catch (Exception ex)
            {
                ApplicationLog.LogError(ex, ErrorCode.User, "Delete()");
                return false;
            }
        }

    }
}

