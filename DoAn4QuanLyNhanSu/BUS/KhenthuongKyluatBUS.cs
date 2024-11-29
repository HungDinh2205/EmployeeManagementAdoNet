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
    public class KhenthuongKyluatBUS : IKhenthuongKyluatBUS
    {
        private IKhenthuongKyluatDAL _khenthuongkyluat;
        public KhenthuongKyluatBUS(IKhenthuongKyluatDAL khenthuongkyluat)
        {
            _khenthuongkyluat = khenthuongkyluat;
        }
        public bool Create(Khenthuong_Kyluat model) { return _khenthuongkyluat.Create(model); }
        public bool Update(Khenthuong_Kyluat model) { return _khenthuongkyluat.Update(model); }
        public bool Delete(int id) { return _khenthuongkyluat.Delete(id); }
        public List<Khenthuong_Kyluat> GetAll() { return _khenthuongkyluat.GetAll(); }
        public List<Khenthuong_Kyluat2> GetAllandhoten() { return _khenthuongkyluat.GetAllandhoten(); } 
    }
}
