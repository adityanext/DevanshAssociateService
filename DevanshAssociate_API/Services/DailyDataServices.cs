using DevanshAssociate_API.DAL;
using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Services
{
    public class DailyDataServices: IDailyDataService
    {
        private DailyDataDAL dailyDataDAL;
        public DailyDataServices()
        {
            dailyDataDAL = new DailyDataDAL();
        }
        public List<DailyData> getAllDailyData()
        {
            return dailyDataDAL.getAllCustomerData();
        }

        public string postDailyData(List<DailyData> customerData)
        {
            string str = "";
            foreach(DailyData data in customerData)
            {
                str = dailyDataDAL.postDailyDataDAL(data);
            }
            return str;
        }

        public string postExcelRawData(List<DailyData> customerData)
        {
            string str = "";

            str = dailyDataDAL.postExcelRawDataDAL(customerData);

            return str;
        }
    }
}
