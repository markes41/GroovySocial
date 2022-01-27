using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GroovySocial.Helpers
{
    public class SessionHelper
    {
        private IHttpContextAccessor _contextAccessor;

        public SessionHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Get the current user in session
        /// </summary>
        public UserViewModel GetUser()
        {
            // Get the current user in session
            var userJsonFormat = _contextAccessor.HttpContext.Session.GetString("UserSession");

            // Convert the json to UserViewModel
            return JsonSerializer.Deserialize<UserViewModel>(userJsonFormat);
        }

        /// <summary>
        /// Set a user in session
        /// </summary>
        public void SetUser(UserViewModel user)
        {
            // Serialize the user param into string
            var userJsonFormat = JsonSerializer.Serialize(user);

            // Put the user information in session
            _contextAccessor.HttpContext.Session.SetString("UserSession", userJsonFormat);
        }

        /// <summary>
        /// Remove the current user in session
        /// </summary>
        public void RemoveUser()
        {
            _contextAccessor.HttpContext.Session.Remove("UserSession");
        }
    }
}
