using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevanshAssociate_API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevanshAssociate_API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EmpDataController : Controller
    {
        // GET: CustomerData
        private IEmpDataService customerService;

        public EmpDataController()
        {
            customerService = new EmpDataService();
        }

        [HttpGet("all")]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(customerService.getAllEmpData());
        }
    }
}