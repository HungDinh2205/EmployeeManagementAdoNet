using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DAO.Helper;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TangcaDAL : ITangcaDAL
    {
        private ITruyVanDuLieu _truyvan;
        public TangcaDAL(ITruyVanDuLieu truyvan) { _truyvan = truyvan; }
        public bool Create(TangcaData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sogio", model.sogio ?? (object)DBNull.Value,
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idloaica", model.idloaica ?? (object)DBNull.Value
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_tangca", parameters);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception($"{result} {msgError}");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }
        public bool Update(TangcaData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idtangca", model.idtangca.HasValue ? (object)model.idtangca.Value : DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sogio", model.sogio ?? (object)DBNull.Value,
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idloaica", model.idloaica ?? (object)DBNull.Value
                };

                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_tangca", parameters);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception($"{result} {msgError}");
                }
                return true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw ex;
            }
        }
        public bool Delete(int idtangca)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idtangca", idtangca };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_tangca", parameters);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true; // Thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                throw ex;
            }
        }
        public bool Save(TangcaData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idtangca", model.idtangca.HasValue ? (object)model.idtangca.Value : DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sogio", model.sogio ?? (object)DBNull.Value,
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idloaica", model.idloaica ?? (object)DBNull.Value
                };

                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_tangca", parameters);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception($"{result} {msgError}");
                }
                return true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw ex;
            }
        }
        public List<TangcaData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_tangca");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TangcaData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
