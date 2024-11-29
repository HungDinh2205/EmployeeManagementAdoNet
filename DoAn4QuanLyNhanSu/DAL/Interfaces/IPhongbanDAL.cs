using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IPhongbanDAL
    {
        PhongbanData GetById(int idphongban);
        bool Create(PhongbanData model);
        bool Update(PhongbanData model);
        bool Delete(int idtongiao);
        List<PhongbanData> GetAll();
        bool Save(int? idphongban, string tenpb);
    }
}
