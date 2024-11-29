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
    public class ChamcongBUS : IChamcongBUS
    {
        private IChamcongDAL _chamcong;
        public ChamcongBUS(IChamcongDAL chamcong) { _chamcong = chamcong; }
        //public bool CheckIn(ChamcongData model) { return  _chamcong.CheckIn(model);}
        //public bool CheckOut(ChamcongData model) { return _chamcong.CheckOut(model); }
        //public List<ChamcongData2> GetChamcongAll(DateTime startDate, DateTime endDate) { return _chamcong.GetChamcongAll(startDate, endDate); }
        //public List<ChamcongData3> Search(string TuKhoa) { return _chamcong.Search(TuKhoa); }
        //public List<ThoiGianLamViec> TinhThoiGianLamViec(int idnv, DateTime startDate, DateTime endDate) { return _chamcong.TinhThoiGianLamViec(idnv, startDate, endDate); }
        public List<ChamcongData4> GetChamcongAll() { return _chamcong.GetChamcongAll(); }
        public bool CheckIn(ChamcongDataCheckIn model) { return _chamcong.CheckIn(model); }
        public bool CheckOut(ChamcongDataCheckOut model) { return _chamcong.CheckOut(model); }
        public bool Update(ChamcongData4 model) {  return _chamcong.Update(model);}
        public bool Delete(int idchamcong) { return _chamcong.Delete(idchamcong); }
        public List<ChamcongData4> GetDanhSachNgayChamCong(DateTime ngaychamcong) { return _chamcong.GetDanhSachNgayChamCong(ngaychamcong); }
    }
}
