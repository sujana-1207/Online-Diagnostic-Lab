using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using TestResultService.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace TestResultService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetResultController : ControllerBase
    {
        private readonly ITestResult _resultRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(GetResultController));
        public GetResultController(ITestResult resultRepository)
        {
            _resultRepository = resultRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _log4net.Info("Get All is accessed");
                var t = _resultRepository.GetAll();
                if(t!=null)
                {
                    _log4net.Info("All information fetched.");
                    return new OkObjectResult(t);
                }
                _log4net.Info("Unable to fetch all details");
                return new NoContentResult();
                
            }
            catch
            {
                _log4net.Error("Error in getting all details");
                return new BadRequestResult();
            }
        }
        // GET: api/GetResult/3
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                _log4net.Info("Get TestResults by Id accessed");
                var t = _resultRepository.GetTestResult(id);
                if (t != null)
                {
                    _log4net.Info("Successfully retrieved details for Id: "+id);
                    return new OkObjectResult(t);
                }
                else
                {
                    _log4net.Error("No such result found for Id: "+id);
                    return new NotFoundResult();
                }
            }   
            catch
            {
                _log4net.Error("Error in Getting Test Result Details");
                return new NoContentResult();
            }
        }
    }
}
