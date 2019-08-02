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
    public class CustomerDataController : Controller
    {
        // GET: CustomerData
        private ICustomerDataService customerService;

        public CustomerDataController()
        {
            customerService = new CustomerDataService();
        }

        [HttpGet("all")]        
        public string GetAll(int processStep)
        {
            CustomerData data = new CustomerData();
            data.processStep = processStep;
            return JsonConvert.SerializeObject(customerService.getAllCustomerData(data));
        }

        [HttpGet("getById")]
        public string GetById(int id)
        {
            CustomerData custData = new CustomerData();
            custData.customerId = id;
            return JsonConvert.SerializeObject(customerService.getCustomerDataById(custData));
        }

        
        [HttpGet("getReferenceById")]
        public string GetRefernceDataById(int customerId)
        {
            CustomerData custData = new CustomerData();
            custData.customerId = customerId;
            return JsonConvert.SerializeObject(customerService.getCustomerReferenceDataById(custData));
        }

        [HttpPost("saveData")]
        public string postCustomerData([FromBody]CustomerData request)
        {
            return JsonConvert.SerializeObject(customerService.postCustomerData(request));
           
        }
        
        [HttpPost("saveRefernceData")]
        public string postCustomerReferenceData([FromBody]CustomerData request)
        {
            return JsonConvert.SerializeObject(customerService.postCustomerReferenceData(request));

        }
    }
}