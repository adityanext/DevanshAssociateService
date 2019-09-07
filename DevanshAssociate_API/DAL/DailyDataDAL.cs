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
    public class DailyDataDAL: BaseDAL
    {
        public List<DailyData> getAllCustomerData()
        {
            string response = JsonConvert.SerializeObject(null);

            MySqlDataReader dr = CallDailyDataDetail_USP(response, OperationType.GET_All);

            List<DailyData> dailyData = new List<DailyData>();
            while (dr.Read())
            {
                DailyData singleData = ConvertDataReaderIntoModel(dr);
                dailyData.Add(singleData);
            }
            dr.Close();
            return dailyData;

        }

        public string postDailyDataDAL(List<DailyData> customerData)
        {
            string request = JsonConvert.SerializeObject(customerData);
            string response = "";
            MySqlDataReader dr = CallDailyDataDetail_USP(request, OperationType.SAVE);

            List<DailyData> customersData = new List<DailyData>();
            while (dr.Read())
            {
                //CustomerData customerData = ConvertDataReaderIntoModel(dr);
                //customersData.Add(customerData);

            }
            dr.Close();
            return null;

        }

        public string postExcelRawDataDAL(List<DailyData> customerData)
        {
            string request = JsonConvert.SerializeObject(customerData);
            string response = "";
            MySqlDataReader dr = CallExcelrawDataDetail_USP(request);

            List<DailyData> customersData = new List<DailyData>();
            while (dr.Read())
            {
                response = Convert.ToString(dr["_errorOutput"]);
            }
            dr.Close();
            return response;
        }


        private MySqlDataReader CallExcelrawDataDetail_USP(string excelDataJson)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter excelParam = new MySqlParameter("@customerListData", excelDataJson);
                excelParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Excel_Raw_Data_USP);
                cmd.Parameters.Add(excelParam);
                cmd.Parameters.Add(outputParam);

                dr = cmd.ExecuteReader();
            }
            catch (MySqlException execption)
            {
                throw new Exception("Internal Error occurred: " + execption.Message);
            }

            return dr;
        }

        private MySqlDataReader CallDailyDataDetail_USP(string dailyDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter customerDetailParam = new MySqlParameter("@dailyData", dailyDataJson);
                customerDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Daily_Data_USP);
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

        private DailyData ConvertDataReaderIntoModel(MySqlDataReader dr)
        {
            DailyData obj = new DailyData();
            obj.id = Convert.ToInt32(dr["Id"]);
            obj.name = Convert.ToString(dr["CustomerName"]);
            obj.primaryContactNumber = Convert.ToString(dr["CustomerPrimaryNumber"]);
            obj.secondaryContactNumber = Convert.ToString(dr["CustomerSecondaryNumber"]);
            obj.customerReaction = Convert.ToInt32(dr["CustomerReaction"]);
            obj.assignTo = Convert.ToString(dr["AssignTo"]);
            return obj;
        }
    }
}
