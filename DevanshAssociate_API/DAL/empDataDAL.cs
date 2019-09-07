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
    public class EmpDataDAL : BaseDAL
    {

        public List<EmpData> getAllCustomerData()
        {
            string response = JsonConvert.SerializeObject(null);

            MySqlDataReader dr = CallEmpDetail_USP(response, OperationType.GET_All);

            List<EmpData> customersData = new List<EmpData>();
            while (dr.Read())
            {
                EmpData customerData = ConvertDataReaderIntoModel(dr);
                customersData.Add(customerData);
            }
            dr.Close();
            return customersData;

        }


        public string addEmpData(EmpData emp)
        {
            string request = JsonConvert.SerializeObject(emp);
            string response = "";

            MySqlDataReader dr = CallEmpDetail_USP(request, OperationType.SAVE);
            
            while (dr.Read())
            {
                response = Convert.ToString(dr["_errorOutput"]);
            }

            dr.Close();
            return response;
        }
        private MySqlDataReader CallEmpDetail_USP(string empDataJson, OperationType operationType)
        {
            MySqlDataReader dr = null;
            var errorOutput = "";
            try
            {
                MySqlParameter empDetailParam = new MySqlParameter("@empData", empDataJson);
                empDetailParam.Direction = ParameterDirection.Input;
                MySqlParameter operationTypeParam = new MySqlParameter("@operationType", operationType);
                operationTypeParam.Direction = ParameterDirection.Input;
                MySqlParameter outputParam = new MySqlParameter("@_errorOutput", errorOutput);
                outputParam.Direction = ParameterDirection.Output;

                MySqlCommand cmd = BaseDAL.GetSqlCommandProcedure(Get_All_Emp_Data_USP);
                cmd.Parameters.Add(empDetailParam);
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

        private EmpData ConvertDataReaderIntoModel(MySqlDataReader dr)
        {
            EmpData obj = new EmpData();
            obj.employeeName = Convert.ToString(dr["UserName"]);

            return obj;
        }
    }
}
