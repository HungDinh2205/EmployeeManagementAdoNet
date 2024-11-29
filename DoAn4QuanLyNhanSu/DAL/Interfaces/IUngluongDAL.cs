using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IUngluongDAL
    {
        bool Create(UngluongData model);
        bool Update(UngluongData model);
        bool Delete(int idungluong);
        List<UngluongData> GetAll();
        bool Save(UngluongData model);
    }
}
