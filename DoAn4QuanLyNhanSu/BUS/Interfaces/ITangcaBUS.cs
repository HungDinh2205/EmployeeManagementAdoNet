using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface ITangcaBUS
    {
        bool Create(TangcaData model);
        bool Update(TangcaData model);
        bool Delete(int idtangca);
        List<TangcaData> GetAll();
        bool Save(TangcaData model);
    }
}
