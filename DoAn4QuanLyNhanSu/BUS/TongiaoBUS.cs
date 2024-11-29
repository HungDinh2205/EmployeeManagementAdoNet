using BUS.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TongiaoBUS : ITongiaoBUS
    {
        private ITongiaoDAL _tongiao;
        public TongiaoBUS(ITongiaoDAL tongiao)
        {
            _tongiao = tongiao;
        }
        public TongiaoData GetById(int idtongiao)
        {
            return _tongiao.GetById(idtongiao);
        }
        public bool Create(TongiaoData model)
        {
            return _tongiao.Create(model);
        }
        public bool Update(TongiaoData model)
        {
            return _tongiao.Update(model);
        }
        public bool Delete(int iddantoc)
        {
            return _tongiao.Delete(iddantoc);
        }
        public List<TongiaoData> GetAll()
        {
            return _tongiao.GetAll();
        }
        public bool Save(int? idtongiao, string tentongiao)
        {
            return _tongiao.Save(idtongiao, tentongiao);
        }
    }
}
