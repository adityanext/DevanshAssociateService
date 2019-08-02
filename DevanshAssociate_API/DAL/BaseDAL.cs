using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data;
using DevanshAssociate_API;

namespace MagathApi.DAL
{
    public class BaseDAL : DBObjectList
    {
        public static MySqlCommand GetSqlCommandProcedure(string procedureName)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, new MySqlConnection(Startup.ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            return cmd;
        }
    }
}
