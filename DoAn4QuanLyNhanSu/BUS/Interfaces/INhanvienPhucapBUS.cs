using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface INhanvienPhucapBUS
    {
        bool Create(Nhanvien_Phucap model);
        bool Update(Nhanvien_Phucap model);
        bool Delete(int idnvpc);
        List<Nhanvien_Phucap> GetAll();
        bool Save(Nhanvien_Phucap model);
    }
}
