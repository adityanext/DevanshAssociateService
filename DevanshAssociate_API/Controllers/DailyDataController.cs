using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevanshAssociate_API.Models;
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
    public class DailyDataController : Controller
    {
        private IDailyDataService customerService;

        public DailyDataController()
        {
            customerService = new DailyDataServices();
        }

        [HttpGet("all")]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(customerService.getAllDailyData());
        }

        [HttpPost("saveDailyData")]
        public string postDailyData([FromBody] List<DailyData> request)
        {
            return customerService.postDailyData(request);
        }

        [HttpPost("saveExcelData")]
        public string postExcelRawData([FromBody] List<DailyData> request)
        {
            return JsonConvert.SerializeObject(customerService.postExcelRawData(request));
        }
    }
}