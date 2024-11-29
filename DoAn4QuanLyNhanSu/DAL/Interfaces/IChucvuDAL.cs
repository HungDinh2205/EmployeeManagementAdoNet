using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IChucvuDAL
    {
        ChucvuData GetById(int idchucvu);
        bool Create(ChucvuData model);
        bool Update(ChucvuData model);
        bool Delete(int idchucvu);
        bool Save(int? idchucvu, string tencv);
        List<ChucvuData> GetAll();
    }
}
