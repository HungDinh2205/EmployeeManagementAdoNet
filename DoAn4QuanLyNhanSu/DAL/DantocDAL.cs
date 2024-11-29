using DAL.Helper;
using DAL.Helper.Interface;
using DataModel;
using DAL.Interfaces;

namespace DAL
{
    public class DantocDAL: IDantocDAL
    {
        private ITruyVanDuLieu _truyvan;

        public DantocDAL(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public DantocData GetById(int iddantoc)
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "get_dantoc_by_id",
                     "@iddantoc", iddantoc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DantocData>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create (DantocData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "insert_dantoc",
                
                "@tendantoc", model.tendantoc
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

        public bool Update(DantocData model)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "update_dantoc",
                "@iddantoc", model.iddantoc,
                "@tendantoc", model.tendantoc
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

        public bool Delete(int iddantoc)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "delete_dantoc",
                     "@iddantoc", iddantoc);
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

        public List<DantocData> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _truyvan.ExecuteSProcedureReturnDataTable(out msgError, "getall_dantoc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DantocData>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(int? iddantoc, string tendantoc)
        {
            string msgError = "";
            try
            {
                var result = _truyvan.ExecuteScalarSProcedureWithTransaction(out msgError, "save_dantoc",
                    "@iddantoc", iddantoc.HasValue ? (object)iddantoc.Value : DBNull.Value,
                    "@tendantoc", tendantoc);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch(Exception ex) {
            throw ex;}
        }
    }
}
