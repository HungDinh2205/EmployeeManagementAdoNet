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
    public class KhenthuongKyluatDAL : IKhenthuongKyluatDAL
    {
        private ITruyVanDuLieu _truyvan;
        public KhenthuongKyluatDAL(ITruyVanDuLieu truyvan) { _truyvan = truyvan; }
        public bool Create(Khenthuong_Kyluat model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@soktkl", model.soktkl ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@ngayktkl", model.ngayktkl ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                    "@loai", model.loai ?? (object)DBNull.Value,
                    "@tungay", model.tungay ?? (object)DBNull.Value,
                    "@denngay", model.denngay ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_ktkl", parameters);
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
        public bool Update(Khenthuong_Kyluat model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@id", model.id ?? (object)DBNull.Value,
                    "@soktkl", model.soktkl ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@ngayktkl", model.ngayktkl ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                    "@loai", model.loai ?? (object)DBNull.Value,
                    "@tungay", model.tungay ?? (object)DBNull.Value,
                    "@denngay", model.denngay ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_ktkl", parameters);
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
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@id", id };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_ktkl", parameters);
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
        public List<Khenthuong_Kyluat> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_ktkl");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Khenthuong_Kyluat>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Khenthuong_Kyluat2> GetAllandhoten()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_khenthuongkyluat_nhanvien_danhsach");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Khenthuong_Kyluat2>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
