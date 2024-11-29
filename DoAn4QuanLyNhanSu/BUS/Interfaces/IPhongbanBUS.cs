using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IPhongbanBUS
    {
        PhongbanData GetById(int idphongban);
        bool Create(PhongbanData model);
        bool Update(PhongbanData model);
        bool Delete(int idphongban);
        List<PhongbanData> GetAll();
        bool Save(int? idphongban, string tenpb);
    }
}
