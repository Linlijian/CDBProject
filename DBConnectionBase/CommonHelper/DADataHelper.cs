using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;

namespace DataAccess
{
    public static class DADataHelper
    {
        public static string GetConnectionString(this string connectionName)
        {
            var DataSource = "OxlOlO";
            var Id = "sa";
            var Password = "P@ssw0rd";
            var InitialCatalog = "TCDB";
            var connection = "Data Source=" + DataSource + ";Persist Security Info=True;User ID=" + Id + ";Password=" + Password + ";Initial Catalog=" + InitialCatalog + "";
            var isEncript = ConfigurationManager.AppSettings["EncriptDBConnect"];
            if (isEncript == "true")
            {
                connection = connection.ToAsciiString();
            }
            return connection;
        }
        public static string GetConnectionStringEF(this string connectionName, string connectionNameEF)
        {
            var DataSource = "OxlOlO";
            var Id = "sa";
            var Password = "P@ssw0rd";
            var InitialCatalog = "TCDB";
            var connection = "Data Source=" + DataSource + ";Persist Security Info=True;User ID=" + Id + ";Password=" + Password + ";Initial Catalog=" + InitialCatalog + "";
            var connectionEF = "Data Source=" + DataSource + ";Persist Security Info=True;User ID=" + Id + ";Password=" + Password + ";Initial Catalog=" + InitialCatalog + "";
            var isEncript = ConfigurationManager.AppSettings["EncriptDBConnect"];
            if (isEncript == "true")
            {
                connection = connection.ToAsciiString();
            }
            connection = connectionEF.Replace("{tpConnectionString}", connection);
            return connection;
        }

        public static string ToAsciiString(this string data)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(data));
        }

        public static bool Success(this ExecuteResult dataSetResult, BaseDTO dto)
        {
            dto.Result.IsResult = dataSetResult.Status;
            if (!dataSetResult.Status)
            {
                dto.Result = new DTOResult();
                dto.Result.ActionResult = -1;
                dto.Result.IsResult = dataSetResult.Status;
                dto.Result.ResultMsg = dataSetResult.ErrorMessage;
            }
            return dataSetResult.Status;
        }
        public static void AddParameter(this List<SqlDBParameter> parameters, string parameterName, object value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            var param = new SqlDBParameter();
            param.DBType = SqlDBType.None;
            param.Direction = parameterDirection;
            param.ParameterName = parameterName;
            param.Size = (parameterDirection == ParameterDirection.Output || parameterDirection == ParameterDirection.InputOutput) ? 2000 : 0;
            param.Value = !value.IsNullOrEmpty() ? value : null;
            parameters.Add(param);
        }

        public static void AddParameter(this List<SqlDBParameter> parameters, string parameterName, object value, ParameterDirection parameterDirection, int size)
        {
            var param = new SqlDBParameter();
            param.DBType = SqlDBType.None;
            param.Direction = parameterDirection;
            param.ParameterName = parameterName;
            param.Size = size;
            param.Value = !value.IsNullOrEmpty() ? value : null;
            parameters.Add(param);
        }

        public static void AddParameter(this List<SqlDBParameter> parameters, string parameterName, object value, SqlDBType dbType, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            var param = new SqlDBParameter();
            param.DBType = dbType;
            param.Direction = parameterDirection;
            param.ParameterName = parameterName;
            param.Value = !value.IsNullOrEmpty() ? value : null;
            parameters.Add(param);
        }


    }
}
