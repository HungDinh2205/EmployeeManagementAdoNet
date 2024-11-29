using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface INhanvienPhucapDAL
    {
        bool Create(Nhanvien_Phucap model);
        bool Update(Nhanvien_Phucap model);
        bool Delete(int idnvpc);
        List<Nhanvien_Phucap> GetAll();
        bool Save(Nhanvien_Phucap model);
    }
}
