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
    public class TongiaoDAL : ITongiaoDAL
    {
        private ITruyVanDuLieu _truyvan;

        public TongiaoDAL(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public TongiaoData GetById(int idtongiao)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_tongiao_by_id",
                     "@idtongiao", idtongiao);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TongiaoData>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(TongiaoData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_tongiao",

                "@tentongiao", model.tentongiao
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

        public bool Update(TongiaoData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_tongiao",
                "@idtongiao", model.idtongiao,
                "@tentongiao", model.tentongiao
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

        public bool Delete(int idtongiao)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "delete_tongiao",
                     "@idtongiao", idtongiao);
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

        public List<TongiaoData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_tongiao");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TongiaoData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(int? idtongiao, string tentongiao)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_tongiao",
                    "@idtongiao", idtongiao.HasValue ? (object)idtongiao.Value : DBNull.Value,
                    "@tentongiao", tentongiao);
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
