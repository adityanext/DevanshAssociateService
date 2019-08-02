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
    public class CustomerDataDAL: BaseDAL
    {
        public List<CustomerData> getAllCustomerData(CustomerData customer) {
            string response = JsonConvert.SerializeObject(customer);

            MySqlDataReader dr = CallcustomerDetail_USP(response, OperationType.GET_All);

            List<CustomerData> customersData = new List<CustomerData>();
            while (dr.Read())
            {
                CustomerData customerData = ConvertDataReaderIntoModel(dr);
                customersData.Add(customerData);
            }
            dr.Close();
            return customersData;

        }

        public CustomerData getCustomerDataById(CustomerData id)
        {
            string response = JsonConvert.SerializeObject(id);
            CustomerData customerData = new CustomerData();
            MySqlDataReader dr = CallcustomerDetail_USP(response, OperationType.GET);

           
            while (dr.Read())
            {
                customerData = ConvertDataReaderIntoModel(dr);                
            }
            dr.Close();

            return customerData;
        }

        public List<CustomerData> getCustomerReferenceDataById(CustomerData request)
        {
            string response = JsonConvert.SerializeObject(request);
            MySqlDataReader dr = CallcustomerReferenceDetail_USP(response, OperationType.GET_All);


            List<CustomerData> customersData = new List<CustomerData>();
            while (dr.Read())
            {
                CustomerData customerData = ConvertDataReaderIntoModel(dr);
                customersData.Add(customerData);
            }
            dr.Close();
            return customersData;
        }

        public string postCustomerData(CustomerData customerData)
        {
            string request = JsonConvert.SerializeObject(customerData);
            string response = "";
            MySqlDataReader dr = CallcustomerDetail_USP(request, OperationType.SAVE);

            
            while (dr.Read())
            {
                response = Convert.ToString(dr["_errorOutput"]);
            }
            dr.Close();
            return response;

        }

        public string postCustomerRefernceData(CustomerData customerData)
        {
            string request = JsonConvert.SerializeObject(customerData);
            string response = "";
            MySqlDataReader dr = CallcustomerReferenceDetail_USP(request, OperationType.SAVE);


            while (dr.Read())
            {
                response = Convert.ToString(dr["_errorOutput"]);
            }
            dr.Close();
            return response;

        }

        /**
        * This method calls the procedure to perform all operation on basis of OperationType.
        */
        private MySqlDataReader CallcustomerDetail_USP(string customerDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter customerDetailParam = new MySqlParameter("@customerData", customerDataJson);
                customerDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Customer_Data_USP);
                cmd.Parameters.Add(customerDetailParam);
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

        /**
       * This method calls the procedure to perform all operation on basis of OperationType.
       */
        private MySqlDataReader CallcustomerReferenceDetail_USP(string customerDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter customerDetailParam = new MySqlParameter("@customerData", customerDataJson);
                customerDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Customer_Refrence_Data_USP);
                cmd.Parameters.Add(customerDetailParam);
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

        /**
       * This method calls the procedure to perform all operation on basis of OperationType.
       */
        private MySqlDataReader CallcustomerRefenceDetail_USP(string customerDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter customerDetailParam = new MySqlParameter("@customerData", customerDataJson);
                customerDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Customer_Refrence_Data_USP);
                cmd.Parameters.Add(customerDetailParam);
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

        private CustomerData ConvertDataReaderIntoModel(MySqlDataReader dr)
        {
            CustomerData obj = new CustomerData();
            obj.customerId = Convert.ToInt32(dr["CustomerId"]);
            obj.customerName = Convert.ToString(dr["CustomerName"]);
            obj.buisnessName = Convert.ToString(dr["BuisnessName"]);
            obj.loanType = Convert.ToInt32(dr["LoanType"]);
            obj.buisnessAddress = Convert.ToString(dr["BuisnessAddress"]);
            obj.buisnessName = Convert.ToString(dr["BuisnessName"]);
            obj.permanentAddress = Convert.ToString(dr["PermanentAddress"]);
            obj.primaryContactNumber = Convert.ToString(dr["PrimaryContactNumber"]);
            obj.secondaryContactNumber = Convert.ToString(dr["SecondaryContactNumber"]);
            obj.workInPeriod = Convert.ToInt32(dr["WorkInPeriod"]);
            obj.lineOfBuisness = Convert.ToString(dr["LineOfBuisness"]);
            obj.monthlyIncome = Convert.ToInt32(dr["MonthlyIncome"]);
            obj.netMonthlyIncome = Convert.ToInt32(dr["NetMonthlyIncome"]);
            obj.loanAmount = Convert.ToInt32(dr["LoanAmount"]);
            obj.otherFaimlyIncome = Convert.ToInt32(dr["OtherFaimlyIncome"]);
            obj.currentAccountingAndSavingAccount = Convert.ToString(dr["CurrentAccountingAndSavingAccount"]);
            obj.loanDetails = Convert.ToString(dr["LoanDetails"]);
            obj.bankName = Convert.ToString(dr["BankName"]);
            obj.eMI = Convert.ToInt32(dr["EMI"]);
            obj.buisnessProofAnyRegistration = Convert.ToString(dr["BuisnessProofAnyRegistration"]);
            obj.propertyValuation = Convert.ToString(dr["PropertyValuation"]);
            obj.refrenceOne = Convert.ToString(dr["RefrenceOne"]);
            obj.refrenceTwo = Convert.ToString(dr["RefrenceTwo"]);
            obj.iTR3Year = Convert.ToString(dr["ITR3Year"]);
            obj.visitBy = Convert.ToString(dr["VisitBy"]);
            obj.companyName = Convert.ToString(dr["CompanyName"]);
            obj.companyAddress = Convert.ToString(dr["CompanyAddress"]);
            obj.panCard = Convert.ToString(dr["PanCard"]);
            obj.referBy = Convert.ToString(dr["ReferBy"]);
            obj.customerReaction = Convert.ToBoolean(dr["CustomerReaction"]);
            obj.assignTo = Convert.ToString(dr["AssignTo"]);
            obj.isReference = Convert.ToInt32(dr["IsReference"]);
            obj.referenceId = Convert.ToInt32(dr["ReferenceId"]);
            obj.referenceCount = Convert.ToInt32(dr["ReferenceCount"]);
            return obj;
        }
    }
}
