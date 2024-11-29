using BUS.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanvienBUS : INhanvienBUS
    {
        private INhanvienDAL _nhanvien;
        public NhanvienBUS(INhanvienDAL nhanvien) 
        {
            _nhanvien = nhanvien;
        }
        public bool Create(NhanVienData model)
        {
            return _nhanvien.Create(model);
        }
        public bool Update(NhanVienData model)
        {
            return _nhanvien.Update(model);
        }
        public bool Delete(int idnv)
        {
            return _nhanvien.Delete(idnv);
        }
        public List<NhanVienData> GetAll()
        {
            return _nhanvien.GetAll();
        }
        public List<NhanVienData2> GetDetailById()
        {
            return _nhanvien.GetDetailById();
        }

        public List<NhanVienData> GetNhanVienHopDong()
        {
            return _nhanvien.GetNhanVienHopDong();
        }
        public NhanVienData GetHotenNhanVienHopDong(int idnv)
        {
            return _nhanvien.GetHotenNhanVienHopDong(idnv);
        }
        public bool Save(NhanVienData model)
        {
            return _nhanvien.Save(model);
        }
    }
}
