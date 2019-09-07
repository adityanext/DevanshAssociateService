using DevanshAssociate_API.DAL;
using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Services
{
    public class EmpDataService: IEmpDataService
    {
        private EmpDataDAL empDataDAL;
        public EmpDataService()
        {
            empDataDAL = new EmpDataDAL();
        }
        public List<EmpData> getAllEmpData()
        {
            return empDataDAL.getAllCustomerData();
        }

        public string addEmpData(EmpData emp)
        {
            return empDataDAL.addEmpData(emp);
        }

        //public List<EmpData> getAllEmpData()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
