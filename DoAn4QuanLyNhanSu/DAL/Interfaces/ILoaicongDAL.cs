using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ILoaicongDAL
    {
        bool Create(LoaicongData model);
        bool Update(LoaicongData model);
        bool Delete(int iddantoc);
        List<LoaicongData> GetAll();
        bool Save(int? idloaicong, string tenloaicong, float? hesocong);
    }
}
