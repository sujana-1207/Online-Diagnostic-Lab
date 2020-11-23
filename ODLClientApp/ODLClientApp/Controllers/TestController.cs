using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ODLClientApp.Models;
namespace ODLClientApp.Controllers
{
    public class TestController : Controller
    {
        LoginController ac = new LoginController();

        [HttpGet]
        public IActionResult SelectAction()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        public IActionResult Appoint()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Appoint(Appointment model)
        {
            if (HttpContext.Session.GetString("Logged In") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            client.BaseAddress = new Uri("https://localhost:44310");
            var jsonstring = JsonConvert.SerializeObject(model);
            var message = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/BookAppointment", message);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var appointmentDetails = JsonConvert.DeserializeObject<Appointment>(jsonContent);
                ViewBag.Id = appointmentDetails.BookingId;
                ViewBag.Name = appointmentDetails.FirstName;
                return View("SuccessfullyBooked");
            }
            else
            {
                return RedirectToAction("Appoint", "Test");
            }

        }
        public IActionResult Result()
        {
            if (HttpContext.Session.GetString("Logged In") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Result(GetResult model)
        {
            if (HttpContext.Session.GetString("Logged In") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            client.BaseAddress = new Uri("https://localhost:44345");
            var jsonstring = JsonConvert.SerializeObject(model);
            var message = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
            var id = message.ReadAsStringAsync().Result;
            var response = await client.GetAsync("/api/GetResult/"+ model.Id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var testResultDetails = JsonConvert.DeserializeObject<Resultss>(jsonContent);
                  ViewBag.mod = testResultDetails;
                return View("Results");
            }
            else
            {
                return RedirectToAction("Result", "Test");
            }
        }
    }
}