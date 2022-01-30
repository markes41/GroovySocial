using GroovySocial.Helpers;
using GroovySocial.Models;
using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroovySocial.Controllers
{
    public class ProfileController : Controller
    {
        private SessionHelper session;
        private ProfileModel model;
        private UserViewModel user;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileController(SessionHelper session)
        {
            this.session = session;
            this.model = new ProfileModel();
            this.user = session.GetUser();
        }

        /// <summary>
        /// Main view
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            if (user != null)
                return View();
            else
                return RedirectToAction("Login", "Login");
        }


    }
}
