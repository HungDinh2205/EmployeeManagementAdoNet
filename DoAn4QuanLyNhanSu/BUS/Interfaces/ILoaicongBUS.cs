using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface ILoaicongBUS
    {
        bool Create(LoaicongData model);
        bool Update(LoaicongData model);
        bool Delete(int idloaicong);
        List<LoaicongData> GetAll();
        bool Save(int? idloaicong, string tenloaicong, float? hesocong);
    }
}
