using DevanshAssociate_API.Models;
using DevanshAssociate_API.Models.ENUM;
using MagathApi.DAL;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.DAL
{
    public class CommonDal: BaseDAL
    {

        public List<LoanData> getAllLoanData()
        {
            string response = JsonConvert.SerializeObject(null);

            MySqlDataReader dr = CallLoanDetail_USP(response, OperationType.GET_All);

            List<LoanData> LoanDataList = new List<LoanData>();
            while (dr.Read())
            {
                LoanData LoanData = ConvertDataReaderIntoModelForLoan(dr);
                LoanDataList.Add(LoanData);
            }
            dr.Close();
            return LoanDataList;
        }

        /**
       * This method calls the procedure to perform all operation on basis of OperationType.
       */
        private MySqlDataReader CallLoanDetail_USP(string loanDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter loanDetailParam = new MySqlParameter("@loanData", loanDataJson);
                loanDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Loan_Data_USP);
                cmd.Parameters.Add(loanDetailParam);
                cmd.Parameters.Add(operationTypeParam);
                cmd.Parameters.Add(outputParam);

                dr = cmd.ExecuteReader();
            }
            catch (MySqlException execption)
            {
                throw new Exception("Internal Error occurred: " + execption.Message);
            }

            return dr;
        }


        private LoanData ConvertDataReaderIntoModelForLoan(MySqlDataReader dr)
        {
            LoanData obj = new LoanData();
            obj.loanId = Convert.ToInt32(dr["Id"]);
            obj.loanName = Convert.ToString(dr["LoanName"]);
            obj.loanDisplayName = Convert.ToString(dr["LoanDescription"]);  

            return obj;
        }



        public List<BankData> getAllBankData()
        {
            string response = JsonConvert.SerializeObject(null);

            MySqlDataReader dr = CallBankDetail_USP(response, OperationType.GET_All);

            List<BankData> BankDataList = new List<BankData>();
            while (dr.Read())
            {
                BankData bankData = ConvertDataReaderIntoModelForBank(dr);
                BankDataList.Add(bankData);
            }
            dr.Close();
            return BankDataList;
        }

        /**
      * This method calls the procedure to perform all operation on basis of OperationType.
      */
        private MySqlDataReader CallBankDetail_USP(string bankDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter bankDetailParam = new MySqlParameter("@bankData", bankDataJson);
                bankDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Bank_Data_USP);
                cmd.Parameters.Add(bankDetailParam);
                cmd.Parameters.Add(operationTypeParam);
                cmd.Parameters.Add(outputParam);

                dr = cmd.ExecuteReader();
            }
            catch (MySqlException execption)
            {
                throw new Exception("Internal Error occurred: " + execption.Message);
            }

            return dr;
        }


        private BankData ConvertDataReaderIntoModelForBank(MySqlDataReader dr)
        {
            BankData obj = new BankData();
            obj.bankId = Convert.ToInt32(dr["Id"]);
            obj.bankName = Convert.ToString(dr["BankName"]);
            obj.bankType = Convert.ToString(dr["BankType"]);

            return obj;
        }
    }
}
