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
    public class LoaicaDAL : ILoaicaDAL
    {
        private ITruyVanDuLieu _truyvan;
        public LoaicaDAL(ITruyVanDuLieu dbHelper) {
            _truyvan = dbHelper;
        }
        public bool Create(LoaicaData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_loaica",

                "@tenloaica", model.tenloaica
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

        public bool Update(LoaicaData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_loaica",
                "@idloaica", model.idloaica,
                "@tenloaica", model.tenloaica
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

        public bool Delete(int idloaica)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "delete_loaica",
                     "@idloaica", idloaica);
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

        public List<LoaicaData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_loaica");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaicaData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(int? idloaica, string tenloaica, float? hesoca)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_loaica",
                    "@idloaica", idloaica.HasValue ? (object)idloaica.Value : DBNull.Value,
                    "@tenloaica", tenloaica,
                    "@hesoca", hesoca);
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
