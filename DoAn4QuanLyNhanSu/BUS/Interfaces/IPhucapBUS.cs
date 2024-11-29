using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IPhucapBUS
    {
        bool Create(PhucapData model);
        bool Update(PhucapData model);
        bool Delete(int? idphucap);
        List<PhucapData> GetAll();
        bool Save(int? idphucap, string tenphucap, float? sotien);
    }
}
