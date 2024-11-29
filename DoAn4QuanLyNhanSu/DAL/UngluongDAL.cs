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
    public class UngluongDAL : IUngluongDAL 
    {
        private ITruyVanDuLieu _truyvan;
        public UngluongDAL(ITruyVanDuLieu truyvan) { _truyvan = truyvan; }
        public bool Create(UngluongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,  // Đây là kiểu bool, không nullable
                    "@idnv", model.idnv  // Đây là kiểu int, không nullable
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_ungluong", parameters);

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
        public bool Update(UngluongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idungluong", model.idungluong ?? (object)DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,  // Đây là kiểu bool, không nullable
                    "@idnv", model.idnv  // Đây là kiểu int, không nullable
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_ungluong", parameters);

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
        public bool Delete(int idungluong) 
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idungluong", idungluong };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_ungluong", parameters);

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
        public List<UngluongData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_ungluong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UngluongData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(UngluongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idungluong", model.idungluong ?? (object)DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,  // Đây là kiểu bool, không nullable
                    "@idnv", model.idnv  // Đây là kiểu int, không nullable
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_ungluong", parameters);

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
    }
}
