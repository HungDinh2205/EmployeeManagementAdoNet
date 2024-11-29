using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ITongiaoDAL
    {
        TongiaoData GetById(int idtongiao);
        bool Create(TongiaoData model);
        bool Update(TongiaoData model);
        bool Delete(int idtongiao);
        List<TongiaoData> GetAll();
        bool Save(int? idtongiao, string tentongiao);
    }
}
