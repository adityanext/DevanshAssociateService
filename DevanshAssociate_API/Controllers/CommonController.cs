using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevanshAssociate_API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevanshAssociate_API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CommonController : Controller
    {
        private ICommonService commonService;

        public CommonController()
        {
            commonService = new CommonService();
        }

        [HttpGet("loanData/all")]
        public string GetAllLoanData()
        {
            return JsonConvert.SerializeObject(commonService.getAllLoanData());
        }

        [HttpGet("bankData/all")]
        public string GetAllBankData()
        {
            return JsonConvert.SerializeObject(commonService.getAllBankData());
        }
    }
}