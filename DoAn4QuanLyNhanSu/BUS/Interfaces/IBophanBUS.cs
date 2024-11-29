using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IBophanBUS
    {
        BophanData GetById(int idbophan);
        bool Create(BophanData model);
        bool Update(BophanData model);
        bool Delete(int idbophan);
        List<BophanData> GetAll();
        bool Save(int? idbophan, string tenbp);
    }
}
