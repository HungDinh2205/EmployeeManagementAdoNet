using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface ITrinhdoBUS
    {
        TrinhdoData GetById(int idtrinhdo);
        bool Create(TrinhdoData model);
        bool Update(TrinhdoData model);
        bool Delete(int idbophan);
        List<TrinhdoData> GetAll();
        bool Save(int? idbophan, string tenbp);
    }
}
