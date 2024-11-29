using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChamcongDAL : IChamcongDAL
    {
        private ITruyVanDuLieu _truyvan;
        public ChamcongDAL(ITruyVanDuLieu dbHelper) { _truyvan = dbHelper;  }

        //public bool CheckIn(ChamcongData model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "nhanvien_checkIn",

        //        "@idnv", model.idnv
        //        );
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool CheckOut(ChamcongData model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "nhanvien_checkOut",

        //        "@idnv", model.idnv
        //        );
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<ChamcongData4> GetChamcongAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "chamcong_getall_danhsach");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChamcongData4>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ChamcongData3> Search(string TuKhoa)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_TimKiemNhanVien",

        //        "@TuKhoa", TuKhoa.ToString()
        //        );
        //        if (!string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(msgError);
        //        }
        //        return dt.ConvertTo<ChamcongData3>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Error in Search method: {ex.Message}");
        //        // Optionally rethrow or return an empty list
        //        return new List<ChamcongData3>();
        //    }
        //}
        //public List<ThoiGianLamViec> TinhThoiGianLamViec(int idnv, DateTime startDate, DateTime endDate)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "sp_TinhThoiGianLamViec",

        //        "@idnv", idnv,
        //        "@startDate", startDate.Date,
        //        "@endDate", endDate.Date
        //        );
        //        if (!string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(msgError);
        //        }
        //        return dt.ConvertTo<ThoiGianLamViec>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Error in Search method: {ex.Message}");
        //        // Optionally rethrow or return an empty list
        //        return new List<ThoiGianLamViec>();
        //    }
        //}

        public bool CheckIn(ChamcongDataCheckIn model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnv", model.idnv,
                    "@ngaychamcong", model.ngaychamcong ?? (object)DBNull.Value,
                    "@checkIn", model.checkIn ?? (object)DBNull.Value,
                    //"@checkOut", model.checkOut,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,
                    "@ghichu", model.ghichu ?? (object)DBNull.Value
                };
                //var checkInTime = model.checkIn.HasValue ? (object)model.checkIn.Value.ToString("HH:mm:ss") : DBNull.Value;
                //var checkOutTime = model.checkOut.HasValue ? (object)model.checkOut.Value.ToString("HH:mm:ss") : DBNull.Value;
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "nhanvien_CheckIn", parameters);
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

        public bool CheckOut(ChamcongDataCheckOut model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idnv", model.idnv,
                    "@ngaychamcong", model.ngaychamcong ?? (object)DBNull.Value,
                    //"@checkIn", checkInTime,
                    "@checkOut", model.checkOut ?? (object)DBNull.Value,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,
                    "@ghichu", model.ghichu ?? (object)DBNull.Value
                };
                //var checkInTime = model.checkIn.HasValue ? (object)model.checkIn.Value.ToString("HH:mm:ss") : DBNull.Value;
                //var checkOutTime = model.checkOut.HasValue ? (object)model.checkOut.Value.ToString("HH:mm:ss") : DBNull.Value;
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "nhanvien_CheckOut", parameters);
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

        public bool Update(ChamcongData4 model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idchamcong", model.idchamcong,
                    "@idnv", model.idnv,
                    "@ngaychamcong", model.ngaychamcong ?? (object)DBNull.Value,
                    "@checkIn", model.checkIn ?? (object)DBNull.Value,
                    "@checkOut", model.checkOut ?? (object)DBNull.Value,
                    "@trangthai", model.trangthai ?? (object)DBNull.Value,
                    "@ghichu", model.ghichu ?? (object)DBNull.Value
                };
                //var checkInTime = model.checkIn.HasValue ? (object)model.checkIn.Value.ToString("HH:mm:ss") : DBNull.Value;
                //var checkOutTime = model.checkOut.HasValue ? (object)model.checkOut.Value.ToString("HH:mm:ss") : DBNull.Value;
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_chamcong",parameters);
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

        public bool Delete(int idchamcong)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idchamcong", idchamcong };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_chamcong", parameters);

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

        public  List<ChamcongData4> GetDanhSachNgayChamCong(DateTime ngaychamcong)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "danhsach_chamcong_theongay",
                    "@ngaychamcong", ngaychamcong
                    );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<ChamcongData4>().ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in Search method: {ex.Message}");
                // Optionally rethrow or return an empty list
                return new List<ChamcongData4>();
            }

        }
    }
}
