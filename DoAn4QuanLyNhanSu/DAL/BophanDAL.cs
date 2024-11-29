using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BophanDAL : IBophanDAL
    {
        private ITruyVanDuLieu _truyvan;

        public BophanDAL(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public BophanData GetById(int idbophan)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_bophan_by_id",
                     "@idbophan", idbophan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BophanData>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(BophanData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_bophan",

                "@tenbp", model.tenbp
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(BophanData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_bophan",
                "@idbophan", model.idbophan,
                "@tenbp", model.tenbp
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int idbophan)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "delete_bophan",
                     "@idbophan", idbophan);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BophanData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_bophan");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BophanData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(int? idbophan, string tenbp)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_bophan",
                    "@idbophan", idbophan.HasValue ? (object)idbophan.Value : DBNull.Value,
                    "@tenbp", tenbp);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
