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
    public class BaohiemDAL : IBaohiemDAL
    {
        private ITruyVanDuLieu _truyvan;
        public BaohiemDAL(ITruyVanDuLieu dbHelper) { _truyvan = dbHelper; }
        public bool Create(BaohiemData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@sobaohiem", model.sobaohiem ?? (object)DBNull.Value,
                    "@ngaycap", model.ngaycap ?? (object)DBNull.Value,
                    "@noicap", model.noicap ?? (object)DBNull.Value,
                    "@noikhambenh", model.noikhambenh ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_baohiem", parameters);
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
        public bool Update(BaohiemData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idbaohiem", model.idbaohiem.HasValue ? (object)model.idbaohiem.Value : DBNull.Value,
                    "@sobaohiem", model.sobaohiem ?? (object)DBNull.Value,
                    "@ngaycap", model.ngaycap ?? (object)DBNull.Value,
                    "@noicap", model.noicap ?? (object)DBNull.Value,
                    "@noikhambenh", model.noikhambenh ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_baohiem", parameters);
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
        public bool Delete(int? idbangcong) 
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idbangcong", idbangcong };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_baohiem");
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
        public bool Save(BaohiemData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idbaohiem", model.idbaohiem.HasValue ? (object)model.idbaohiem.Value : DBNull.Value,
                    "@sobaohiem", model.sobaohiem ?? (object)DBNull.Value,
                    "@ngaycap", model.ngaycap ?? (object)DBNull.Value,
                    "@noicap", model.noicap ?? (object)DBNull.Value,
                    "@noikhambenh", model.noikhambenh ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_baohiem", parameters);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true; // Return true if successful
            }
            catch (Exception ex)
            {
                // Log or handle the exception here
                throw ex; // You can log it or throw it further up the stack
            }
        
        }
        public List<BaohiemData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_baohiem");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BaohiemData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
