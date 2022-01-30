using GroovySocial.Helpers;
using GroovySocial.Models;
using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GroovySocial.Controllers
{
    public class LoginController : Controller
    {

        private SessionHelper session;
        private UserViewModel user;
        private LoginModel model;

        public LoginController(SessionHelper session)
        {
            this.session = session;
            this.user = this.session.GetUser();
            this.model = new LoginModel();
        }

        /// <summary>
        /// Main page only can access if is any user logged
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            // If user is not login it will redirect to error page
            if (user == null)
                return View();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Post IActionResult to validate the login
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                // Validate the model coming as parameter
                if (ModelState.IsValid)
                {
                    // Search the user in database
                    var result = await model.Search(user);

                    // If find any user redirect to Home
                    if (result)
                        return RedirectToAction("Index", "Home");
                }

                // If any error happens then it return the message error to the view
                ModelState.AddModelError("", model.ErrorMessage);
                return View();
            } 
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un error en la aplicación");
                return View();
            }
        }
    }
}
