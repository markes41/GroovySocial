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

        private readonly SessionHelper session;
        private readonly UserViewModel user;
        private readonly LoginModel model;

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
            // Check any user in session
            if (user == null)
                return View();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Post to validate the login
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                // Validate the model
                if (ModelState.IsValid)
                {
                    // Search the user
                    var result = await model.Search(user);

                    // Redirect to Home if true
                    if (result)
                        return RedirectToAction("Index", "Home");
                }

                // Capture the error
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
