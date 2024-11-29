using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanvienDAL : INhanvienDAL
    {
        private ITruyVanDuLieu _truyvan;
        public NhanvienDAL(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public bool Create(NhanVienData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@hoten", model.hoten ?? (object)DBNull.Value,
                    "@gioitinh", model.gioitinh ?? (object)DBNull.Value,
                    "@ngaysinh", model.ngaysinh ?? (object)DBNull.Value,
                    "@sdt", model.sdt ?? (object)DBNull.Value,
                    "@cccd", model.cccd ?? (object)DBNull.Value,
                    "@diachi", model.diachi ?? (object)DBNull.Value,
                    "@anh", model.anh ?? (object)DBNull.Value,
                    "@idphongban", model.idphongban,
                    "@idbophan", model.idbophan,
                    "@idchucvu", model.idchucvu,
                    "@idtrinhdo", model.idtrinhdo,
                    "@iddantoc", model.iddantoc,
                    "@idtongiao", model.idtongiao,
                    "@quoctich", model.quoctich ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_nhanvien", parameters);
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
        
        public bool Update(NhanVienData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "idnv", model.idnv ?? (object)DBNull.Value,
                    "@hoten", model.hoten ?? (object)DBNull.Value,
                    "@gioitinh", model.gioitinh ?? (object)DBNull.Value,
                    "@ngaysinh", model.ngaysinh ?? (object)DBNull.Value,
                    "@sdt", model.sdt ?? (object)DBNull.Value,
                    "@cccd", model.cccd ?? (object)DBNull.Value,
                    "@diachi", model.diachi ?? (object)DBNull.Value,
                    "@anh", model.anh ?? (object)DBNull.Value,
                    "@idphongban", model.idphongban,
                    "@idbophan", model.idbophan,
                    "@idchucvu", model.idchucvu,
                    "@idtrinhdo", model.idtrinhdo,
                    "@iddantoc", model.iddantoc,
                    "@idtongiao", model.idtongiao,
                    "@quoctich", model.quoctich ?? (object)DBNull.Value,
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_nhanvien", parameters);
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
        public bool Delete(int idnv)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idnv", idnv };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_nhanvien", parameters);

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
        public List<NhanVienData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_nhanvien");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanVienData>().ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Lỗi khi lấy danh sách nhân viên", ex);
            }
        }

        public List<NhanVienData2> GetDetailById()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_nhanvien_details_by_id"
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanVienData2>().ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                //throw new Exception($"Lỗi khi lấy chi tiết nhân viên có ID {idnv}", ex);
                throw new Exception("Lỗi khi lấy danh sách nhân viên", ex);
            }
        }
        public List<NhanVienData> GetNhanVienHopDong() 
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_hopdong_nhanvien_id"
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanVienData>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên", ex);
            }
        }
        public NhanVienData GetHotenNhanVienHopDong(int idnv)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_hopdong_hoten_nhanvien_by_idnv",
                     "@idnv",idnv );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanVienData>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ", ex);
            }
        }
        public bool Save(NhanVienData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnv", model.idnv.HasValue ? (object)model.idnv.Value : DBNull.Value,
                    "@hoten", model.hoten ?? (object)DBNull.Value,
                    "@gioitinh", model.gioitinh,
                    "@ngaysinh", model.ngaysinh ?? (object)DBNull.Value,
                    "@sdt", model.sdt ?? (object)DBNull.Value,
                    "@cccd", model.cccd ?? (object)DBNull.Value,
                    "@diachi", model.diachi ?? (object)DBNull.Value,
                    "@anh", model.anh ?? (object)DBNull.Value,
                    "@idphongban", model.idphongban,
                    "@idbophan", model.idbophan,
                    "@idchucvu", model.idchucvu,
                    "@idtrinhdo", model.idtrinhdo,
                    "@quoctich", model.quoctich ?? (object)DBNull.Value,
                    "@iddantoc", model.iddantoc,
                    "@idtongiao", model.idtongiao
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_nhanvien", parameters);
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
        
    }
}
