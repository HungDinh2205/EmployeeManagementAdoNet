using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ITrinhdoDAL
    {
        TrinhdoData GetById(int idtrinhdo);
        bool Create(TrinhdoData model);
        bool Update(TrinhdoData model);
        bool Delete(int idtrinhdo);
        List<TrinhdoData> GetAll();
        bool Save(int? idtrinhdo, string tentd);
    }
}
