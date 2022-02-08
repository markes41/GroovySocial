using Groov.Web.Helpers;
using GroovySocial.Helpers;
using GroovySocial.Models;
using GroovySocial.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GroovySocial.Controllers
{
    public class ProfileController : Controller
    {
        private SessionHelper session;
        private ProfileModel model;
        private UserViewModel user;
        private IWebHostEnvironment hostingEnv;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileController(SessionHelper session, IWebHostEnvironment env)
        {
            this.session = session;
            this.model = new ProfileModel();
            this.user = session.GetUser();
            this.hostingEnv = env;
        }

        /// <summary>
        /// Main view
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //if (user != null)
            //else
            //    return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public async Task<JsonResult> Upload_File()
        {
            var result = await ProfileModel.SaveProfilePictureChange(this.user, this.Request);

            if (result)
            {
                this.session.SetUser(this.user);
                return Json(new { Status = true, Result = this.user.Profile_Image });
            }
            else
            {
                return Json(new { Status = false });
            }
        }
    }
}
