using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAppointment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTestController : ControllerBase
    {
        private readonly ITestAppointment _testAppointment;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookTestController));

        public BookTestController(ITestAppointment testAppointment)
        {
            _testAppointment = testAppointment;
        }
        //Get:api/BookTest
        [HttpGet]
        public IActionResult Get()
        {
            
            try
            {
                _log4net.Info("Get All Appointments is accessed");
                return new OkObjectResult(_testAppointment.Get()) ;
            }
            catch
            {
                _log4net.Error("Not able to retrieve Appointments made to test");
                return new NoContentResult();
            }
        }
        // POST: api/BookTest
        [HttpPost]
        public IActionResult Post([FromBody] TestAppointment value)
        {
            try
            {
                _log4net.Error("Book new appointment is accessed.");
                if(ModelState.IsValid)
                {
                    var b = _testAppointment.BookAppointment(value);
                    if(b==1)
                    {
                        _log4net.Info("Appointment booked for Id: " + value.BookingId);
                        return new OkObjectResult("Apointment Booked with Id:" + value.BookingId);
                    }
                    _log4net.Info("Ërror in booking for ID: " + value.BookingId);
                }
                _log4net.Error("Model state not valid. Check what you have entered");
                return BadRequest();
            }
            catch
            {
                _log4net.Error("Error in Adding Booking Details");
                return new NoContentResult();

            }
        }

    }
}
