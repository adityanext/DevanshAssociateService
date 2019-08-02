using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Services
{
    interface ICustomerDataService
    {
        List<CustomerData> getAllCustomerData(CustomerData request);

        CustomerData getCustomerDataById(CustomerData id);

        List<CustomerData> getCustomerReferenceDataById(CustomerData id);

        string postCustomerData(CustomerData request);

        string postCustomerReferenceData(CustomerData request);
    }
}
