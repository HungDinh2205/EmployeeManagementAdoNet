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
    public class NhanvienPhucapBUS : INhanvienPhucapBUS
    {
        private INhanvienPhucapDAL _nhanvienphucap;
        public NhanvienPhucapBUS(INhanvienPhucapDAL nhanvienphucap) { _nhanvienphucap = nhanvienphucap; }
        public bool Create(Nhanvien_Phucap model) { return _nhanvienphucap.Create(model); }
        public bool Update(Nhanvien_Phucap model) { return _nhanvienphucap.Update(model); }
        public bool Delete(int idnvpc) { return _nhanvienphucap.Delete(idnvpc); }
        public List<Nhanvien_Phucap> GetAll() { return _nhanvienphucap.GetAll(); }
        public bool Save(Nhanvien_Phucap model) { return _nhanvienphucap.Save(model); } 

    }
}
