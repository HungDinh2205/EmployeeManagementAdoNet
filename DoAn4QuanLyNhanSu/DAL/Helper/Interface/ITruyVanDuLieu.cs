﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper.Interface
{
    public class StoreParameterInfo
    {
        public string StoreProcedureName { get; set; }
        public List<object> StoreProcedureParams { get; set; }
    }
    public interface ITruyVanDuLieu
    {
        void SetConnectionString(string connectionString);
        string OpenConnection();
        string OpenConnectionAndBeginTransaction();
        string CloseConnection();
        string CloseConnectionAndEndTransaction(bool isRollbackTransaction);
        string ExecuteNoneQuery(string strquery);
        DataTable ExecuteQueryToDataTable(string strquery, out string msgError);
        object ExecuteScalar(string strquery, out string msgError);
        object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects);
        DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects);
        string ExecuteSProcedureNonQuery(string sprocedureName, params object[] paramObjects);
    }
}
