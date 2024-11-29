using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DAO.Helper;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HopdongDAL : IHopdongDAL
    {
        private ITruyVanDuLieu _truyvan;
        public HopdongDAL(ITruyVanDuLieu truyvan) { _truyvan = truyvan; }

        public bool CheckEmployeeContract(int idnv)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idnv", idnv };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "Check_id_nhanvien_hopdong", parameters);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception($"Có lỗi trong quá trình thực thi: {msgError}");
                }

                // Kiểm tra nếu result không phải là null và có thể ép kiểu sang int
                if (result == null || !(result is int))
                {
                    return false; // Không có hợp đồng
                }

                // Trả về true nếu đã có hợp đồng
                return (int)result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi kiểm tra hợp đồng của nhân viên.", ex);
            }
        }
        public bool Create(HopdongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@ngaybatdau", model.ngaybatdau ?? (object)DBNull.Value,
                    "@ngayketthuc", model.ngayketthuc ?? (object)DBNull.Value,
                    "@ngayky", model.ngayky ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@lanky", model.lanky.HasValue ? (object)model.lanky.Value : DBNull.Value,
                    "@hesoluong", model.hesoluong.HasValue ? (object)model.hesoluong.Value : DBNull.Value,
                    "@thoihan", model.thoihan ?? (object)DBNull.Value,
                    "@idnv", model.idnv
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_hopdong", parameters);
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
        
        public bool Update(HopdongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idhopdong", model.idhopdong.HasValue ? (object)model.idhopdong.Value : DBNull.Value,
                    "@ngaybatdau", model.ngaybatdau ?? (object)DBNull.Value,
                    "@ngayketthuc", model.ngayketthuc ?? (object)DBNull.Value,
                    "@ngayky", model.ngayky ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@lanky", model.lanky.HasValue ? (object)model.lanky.Value : DBNull.Value,
                    "@hesoluong", model.hesoluong.HasValue ? (object)model.hesoluong.Value : DBNull.Value,
                    "@thoihan", model.thoihan ?? (object)DBNull.Value,
                    "@idnv", model.idnv
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_hopdong", parameters);

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
        public bool Delete(int idhopdong)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idhopdong", idhopdong };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_hopdong", parameters);
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
        public bool Save(HopdongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idhopdong", model.idhopdong.HasValue ? (object)model.idhopdong.Value : DBNull.Value,
                    "@ngaybatdau", model.ngaybatdau ?? (object)DBNull.Value,
                    "@ngayketthuc", model.ngayketthuc ?? (object)DBNull.Value,
                    "@ngayky", model.ngayky ?? (object)DBNull.Value,
                    "@noidung", model.noidung ?? (object)DBNull.Value,
                    "@lanky", model.lanky.HasValue ? (object)model.lanky.Value : DBNull.Value,
                    "@hesoluong", model.hesoluong.HasValue ? (object)model.hesoluong.Value : DBNull.Value,
                    "@thoihan", model.thoihan ?? (object)DBNull.Value,
                    "@idnv", model.idnv
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_hopdong", parameters);

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
        public List<HopdongData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_hopdong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HopdongData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HopdongData2> GetNhanVienHopDong()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_hopdong_nhanvien_danhsach"
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HopdongData2>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên", ex);
            }
        }
    }
}
