using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface INhanvienBUS
    {
        bool Create(NhanVienData model);
        bool Update(NhanVienData model);
        bool Delete(int idnv);
        List<NhanVienData> GetAll();
        List<NhanVienData2> GetDetailById();
        List<NhanVienData> GetNhanVienHopDong();
        NhanVienData GetHotenNhanVienHopDong(int idnv);
        //NhanVienData GetNhanVienHopDong(int idnv);
        bool Save(NhanVienData model);
    }
}
