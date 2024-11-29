using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IBangcongDAL
    {
        bool Create(BangcongData model);
        bool Update(BangcongData model);
        bool Delete(int? idbangcong);
        List<BangcongData> GetAll();
        bool Save(BangcongData model);
    }
}
