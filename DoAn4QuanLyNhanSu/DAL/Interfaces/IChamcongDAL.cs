using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IChamcongDAL
    {
        //bool CheckIn(ChamcongData model);
        //bool CheckOut(ChamcongData model);
        //List<ChamcongData2> GetChamcongAll(DateTime startDate, DateTime endDate);
        //List<ChamcongData3> Search(string TuKhoa);
        //List<ThoiGianLamViec> TinhThoiGianLamViec(int idnv, DateTime startDate, DateTime endDate);
        List<ChamcongData4> GetChamcongAll();
        bool CheckIn(ChamcongDataCheckIn model);
        bool CheckOut(ChamcongDataCheckOut model);
        bool Update(ChamcongData4 model);
        bool Delete(int idchamcong);
        List<ChamcongData4> GetDanhSachNgayChamCong(DateTime ngaychamcong);

    }
}
