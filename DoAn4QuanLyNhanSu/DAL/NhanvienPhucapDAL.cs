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
    public class NhanvienPhucapDAL : INhanvienPhucapDAL
    {
        private ITruyVanDuLieu _truyvan;
        public NhanvienPhucapDAL(ITruyVanDuLieu truyvan) { _truyvan = truyvan; }
        public bool Create(Nhanvien_Phucap model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idphucap", model.idphucap ?? (object)DBNull.Value,
                    "@ngayphucap", model.ngayphucap ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_nvpc", parameters);

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
        public bool Update(Nhanvien_Phucap model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnvpc", model.idnvpc.HasValue ? (object)model.idnvpc.Value : DBNull.Value,
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idphucap", model.idphucap ?? (object)DBNull.Value,
                    "@ngayphucap", model.ngayphucap ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_nvpc", parameters);

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
        public bool Delete(int idnvpc)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idnvpc", idnvpc };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_nvpc", parameters);

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
        public List<Nhanvien_Phucap> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_nvpc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Nhanvien_Phucap>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(Nhanvien_Phucap model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnvpc", model.idnvpc.HasValue ? (object)model.idnvpc.Value : DBNull.Value,
                    "@idnv", model.idnv ?? (object)DBNull.Value,
                    "@idphucap", model.idphucap ?? (object)DBNull.Value,
                    "@ngayphucap", model.ngayphucap ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@sotien", model.sotien ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_nvpc", parameters);

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
