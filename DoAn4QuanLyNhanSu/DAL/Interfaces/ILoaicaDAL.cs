using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ILoaicaDAL
    {
        bool Create(LoaicaData model);
        bool Update(LoaicaData model);
        bool Delete(int idloaica);
        List<LoaicaData> GetAll();
        bool Save(int? idloaica, string tenloaica, float? hesoca);
    }
}
