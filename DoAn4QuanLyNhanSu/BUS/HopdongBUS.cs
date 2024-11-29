using BUS.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HopdongBUS : IHopdongBUS
    {
        private IHopdongDAL _hopdong;
        public HopdongBUS(IHopdongDAL hopdong)
        {
            _hopdong = hopdong;
        }
        public bool CheckEmployeeContract(int idnv)
        {
            return !_hopdong.CheckEmployeeContract(idnv); // Trả về true nếu có thể thêm hợp đồng
        }
        public bool Create(HopdongData model)
        {
            return _hopdong.Create(model);
        }
        public bool Update(HopdongData model) { return _hopdong.Update(model); }
        public bool Delete(int idhopdong) { return _hopdong.Delete(idhopdong); }
        public bool Save(HopdongData model) { return _hopdong.Save(model); }
        public List<HopdongData> GetAll() { return _hopdong.GetAll(); }
        public List<HopdongData2> GetNhanVienHopDong(){return _hopdong.GetNhanVienHopDong(); }
    }
}
