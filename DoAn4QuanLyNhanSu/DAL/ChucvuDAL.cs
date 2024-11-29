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
    public class ChucvuDAL : IChucvuDAL
    {
        private ITruyVanDuLieu _truyvan;
        public ChucvuDAL(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }

        public ChucvuData GetById(int idchucvu)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_chucvu_by_id",
                     "@idchucvu", idchucvu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChucvuData>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ChucvuData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_chucvu",

                "@tencv", model.tencv
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

        public bool Update(ChucvuData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_chucvu",
                "@idchucvu", model.idchucvu,
                "@tencv", model.tencv
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

        public bool Delete(int iddantoc)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "delete_chucvu",
                     "@idchucvu", iddantoc);
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

        public List<ChucvuData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_chucvu");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChucvuData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(int? idchucvu, string tencv)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_chucvu",
                    "@idchucvu", idchucvu.HasValue ? (object)idchucvu.Value : DBNull.Value,
                    "@tencv", tencv);
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
