using DevanshAssociate_API.DAL;
using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Services
{
    public class CustomerDataService: ICustomerDataService
    {
        private CustomerDataDAL customerDataDAL;
        public CustomerDataService()
        {
            customerDataDAL = new CustomerDataDAL();
        }
        public List<CustomerData> getAllCustomerData(CustomerData customerData)
        {
            return customerDataDAL.getAllCustomerData(customerData);
        }

        public List<CustomerData> getAllWithoutProcessStep()
        {
            return customerDataDAL.getAllCustomerDataWithoutProcessStep();
        }

        public CustomerData getCustomerDataById(CustomerData id)
        {
            return customerDataDAL.getCustomerDataById(id);
        }

        public List<CustomerData> getCustomerReferenceDataById(CustomerData id)
        {
            return customerDataDAL.getCustomerReferenceDataById(id);
        }

        public string postCustomerData(CustomerData customerData)
        {
            return customerDataDAL.postCustomerData(customerData);
        }

        public string postCustomerReferenceData(CustomerData customerData)
        {
            return customerDataDAL.postCustomerRefernceData(customerData);
        }

        public string updateCustormerProcessStepData(CustomerData customerData)
        {
            return customerDataDAL.updateCustormerProcessStep(customerData);
        }
    }
}
