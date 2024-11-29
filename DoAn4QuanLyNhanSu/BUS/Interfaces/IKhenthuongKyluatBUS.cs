using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IKhenthuongKyluatBUS
    {
        bool Create(Khenthuong_Kyluat model);
        bool Update(Khenthuong_Kyluat model);
        bool Delete(int id);
        List<Khenthuong_Kyluat> GetAll();
        List<Khenthuong_Kyluat2> GetAllandhoten();
    }
}
