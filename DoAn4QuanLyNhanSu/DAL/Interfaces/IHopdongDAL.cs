using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IHopdongDAL
    {
        bool CheckEmployeeContract(int idnv);
        bool Create(HopdongData model);
        bool Update(HopdongData model);
        bool Delete(int idhopdong);
        List<HopdongData> GetAll();
        List<HopdongData2> GetNhanVienHopDong();
        bool Save(HopdongData model);
    }
}
