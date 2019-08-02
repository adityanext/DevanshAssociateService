using System;
using DevanshAssociate_API.DAL;
using DevanshAssociate_API.Models;
using System;
using System.Collections.Generic;

namespace DevanshAssociate_API.Services
{
    public class CommonService: ICommonService
    {
        private CommonDal commonDataDAL;
        public CommonService()
        {
            commonDataDAL = new CommonDal();
        }

        public List<LoanData> getAllLoanData()
        {
            return commonDataDAL.getAllLoanData();
        }

        public List<BankData> getAllBankData()
        {
            return commonDataDAL.getAllBankData();
        }
    }
}
