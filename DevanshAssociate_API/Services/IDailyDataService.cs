using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Services
{
    interface IDailyDataService
    {
        List<DailyData> getAllDailyData();

        string postDailyData(List<DailyData> customerData);

        string postExcelRawData(List<DailyData> customerData);
    }
}
