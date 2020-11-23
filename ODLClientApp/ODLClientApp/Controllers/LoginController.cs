using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ODLClientApp.Models;

namespace ODLClientApp.Controllers
{
    public class LoginController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            if (!ModelState.IsValid)
            {
                _log4net.Error("Wrong details have been entered by :" + model.Username);
                return View(model);
            }
            var client = new HttpClient();
            client.BaseAddress=new Uri("https://localhost:44351");
            var jsonstring = JsonConvert.SerializeObject(model);
            var message = new StringContent(jsonstring,System.Text.Encoding.UTF8,"application/json");
            var response = await client.PostAsync("/api/Login", message);
            if(!response.IsSuccessStatusCode)
            {
                _log4net.Error("Error while " + model.Username + " is trying to login");
                return View();
            }
            _log4net.Info(model.Username + " has succesfully logged in.");
            string stringJWT = await response.Content.ReadAsStringAsync();
            var jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
            HttpContext.Session.SetString("token", jwt.Token);

            HttpContext.Session.SetString("Logged In", "1");
            return RedirectToAction("SelectAction", "Test");

        }
        [HttpGet]
        public IActionResult Logout()
        {
            _log4net.Info("Logged Out");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}