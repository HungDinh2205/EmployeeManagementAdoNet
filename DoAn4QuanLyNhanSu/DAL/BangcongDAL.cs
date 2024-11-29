using DAL.Helper;
using DAL.Helper.Interface;
using DAL.Interfaces;
using DataModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangcongDAL : IBangcongDAL
    {
        private ITruyVanDuLieu _truyvan;
        public BangcongDAL(ITruyVanDuLieu dbHelper) 
        {
            _truyvan = dbHelper;
        }
        public bool Create(BangcongData model)
        {
            string msgError = "";
            try
            {
                // Tạo danh sách các tham số
                object[] parameters = new object[]
                {
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@giovao", model.giovao ?? (object)DBNull.Value,
                    "@phutvao", model.phutvao ?? (object)DBNull.Value,
                    "@giora", model.giora ?? (object)DBNull.Value,
                    "@phutra", model.phutra ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                    "@idloaicong", model.idloaicong
                };

                // Thực hiện thủ tục lưu trữ với tham số
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_bangcong", parameters);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true; // Cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw ex;
            }
        }
        public bool Update(BangcongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idbangcong", model.idbangcong ?? (object)DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@giovao", model.giovao ?? (object)DBNull.Value,
                    "@phutvao", model.phutvao ?? (object)DBNull.Value,
                    "@giora", model.giora ?? (object)DBNull.Value,
                    "@phutra", model.phutra ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                    "@idloaicong", model.idloaicong
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_bangcong");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                   throw new Exception(Convert.ToString(result) + msgError);
                }
                return true; // Cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw ex;
            }
        }
        public bool Delete(int? idbangcong)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[] { "@idbangcong", idbangcong };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_bangcong", parameters);

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
        public List<BangcongData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_bangcong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BangcongData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(BangcongData model)
        {
            string msgError = "";
            try
            {
                object[] parameters = new object[]
                {
                    "@idbangcong", model.idbangcong.HasValue ? (object)model.idbangcong.Value : DBNull.Value,
                    "@nam", model.nam ?? (object)DBNull.Value,
                    "@thang", model.thang ?? (object)DBNull.Value,
                    "@ngay", model.ngay ?? (object)DBNull.Value,
                    "@giovao", model.giovao ?? (object)DBNull.Value,
                    "@phutvao", model.phutvao ?? (object)DBNull.Value,
                    "@giora", model.giora ?? (object)DBNull.Value,
                    "@phutra", model.phutra ?? (object)DBNull.Value,
                    "@idnv", model.idnv,
                    "@idloaicong", model.idloaicong
                };
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_bangcong", parameters);
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
