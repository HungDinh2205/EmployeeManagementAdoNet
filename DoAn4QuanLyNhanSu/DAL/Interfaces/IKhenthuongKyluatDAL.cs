using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IKhenthuongKyluatDAL
    {
        bool Create(Khenthuong_Kyluat model);
        bool Update(Khenthuong_Kyluat model);
        bool Delete(int id);
        List<Khenthuong_Kyluat> GetAll();
        List<Khenthuong_Kyluat2> GetAllandhoten();
    }
}
