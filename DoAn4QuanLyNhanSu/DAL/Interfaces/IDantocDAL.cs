using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IDantocDAL
    {
        DantocData GetById(int iddantoc);
        bool Create(DantocData model);
        bool Update(DantocData model);
        bool Delete(int iddantoc);
        List<DantocData> GetAll();
        bool Save(int? iddantoc, string tendantoc);
    }
}
