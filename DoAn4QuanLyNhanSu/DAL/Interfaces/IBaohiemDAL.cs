using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IBaohiemDAL
    {
        bool Create(BaohiemData model);
        bool Update(BaohiemData model);
        bool Delete(int? idbaohiem);
        List<BaohiemData> GetAll();
        bool Save(BaohiemData model);
    }
}
