using BUS.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
namespace BUS
{
    public class DantocBUS : IDantocBUS
    {
        private IDantocDAL _dantoc;
        public DantocBUS(IDantocDAL dantoc)
        {
            _dantoc = dantoc;
        }
        public DantocData GetById(int iddantoc)
        {
            return _dantoc.GetById(iddantoc);
        }
        public bool Create(DantocData model)
        {
            return _dantoc.Create(model);
        }
        public bool Update(DantocData model)
        {
            return _dantoc.Update(model);
        }
        public bool Delete(int iddantoc)
        {
            return _dantoc.Delete(iddantoc);
        }
        public List<DantocData> GetAll()
        {
            return _dantoc.GetAll();
        }
        public bool Save(int? iddantoc, string tendantoc) 
        {
            return _dantoc.Save(iddantoc, tendantoc);
        }
    }
}
