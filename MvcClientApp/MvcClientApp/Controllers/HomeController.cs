using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClientApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcClientApp.Controllers
{
    public class HomeController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Getting the token a Validating the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Users user)
        {
            string token = GetToken("https://localhost:44364/api/token", user);

            /*if (token != null)
            {
                return RedirectToAction("Index", "Meds", new { name = token });
            }*/
            if (token != null)
            {
                HttpContext.Session.SetString("JWTtoken", token);
                HttpContext.Session.SetString("Name", user.Email);
                //ViewBag.Login = user.Username;
                return RedirectToAction("Index", "Meds");
            }
            else
            {
                ViewBag.invalid = "UserId or Password invalid";
                return View();
            }
        }
        static string GetToken(string url, Users user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
