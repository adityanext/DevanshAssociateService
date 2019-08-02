using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagathApi.DAL
{
    public class DBObjectList
    {
        #region Login
        public const string ValidateUserSP = "ValidateUser";
        #endregion

        #region Customer data.

        public const string Get_All_Customer_Data_USP = "getAllCustomerData";
        public const string Get_All_Customer_Refrence_Data_USP = "getAllCustomerRefernceData";
        public const string Get_All_Emp_Data_USP = "getAllEmpData";
        #endregion

        #region Common Details
        public const string Get_All_Loan_Data_USP = "getAllLoanDetails";
        public const string Get_All_Bank_Data_USP = "getAllBankDetails";
        #endregion

        #region Daily Data
        public const string Get_All_Daily_Data_USP = "getAllDailyData";
        public const string Get_All_Excel_Raw_Data_USP = "uploadCustomerList";
        #endregion
    }
}