using BUS.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhongbanBUS : IPhongbanBUS
    {
        private IPhongbanDAL _phongban;
        public PhongbanBUS(IPhongbanDAL tongiao)
        {
            _phongban = tongiao;
        }
        public PhongbanData GetById(int idphongban)
        {
            return _phongban.GetById(idphongban);
        }
        public bool Create(PhongbanData model)
        {
            return _phongban.Create(model);
        }
        public bool Update(PhongbanData model)
        {
            return _phongban.Update(model);
        }
        public bool Delete(int idphongban)
        {
            return _phongban.Delete(idphongban);
        }
        public List<PhongbanData> GetAll()
        {
            return _phongban.GetAll();
        }
        public bool Save(int? idphongban, string tenpb)
        {
            return _phongban.Save(idphongban, tenpb);
        }
    }
}
