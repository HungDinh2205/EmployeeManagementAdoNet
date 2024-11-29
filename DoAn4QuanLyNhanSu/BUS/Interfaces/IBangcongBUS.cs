using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IBangcongBUS
    {
        bool Create(BangcongData model);
        bool Update(BangcongData model);
        bool Delete(int idbangcong);
        List<BangcongData> GetAll();
        bool Save(BangcongData model);
    }
}
