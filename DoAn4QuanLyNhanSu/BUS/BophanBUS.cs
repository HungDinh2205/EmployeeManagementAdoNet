using BUS.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BophanBUS : IBophanBUS
    {
        private IBophanDAL _bophan;
        public BophanBUS(IBophanDAL bophan)
        {
            _bophan = bophan;
        }
        public BophanData GetById(int idbophan)
        {
            return _bophan.GetById(idbophan);
        }
        public bool Create(BophanData model)
        {
            return _bophan.Create(model);
        }
        public bool Update(BophanData model)
        {
            return _bophan.Update(model);
        }
        public bool Delete(int idbophan)
        {
            return _bophan.Delete(idbophan);
        }
        public List<BophanData> GetAll()
        {
            return _bophan.GetAll();
        }
        public bool Save(int? idbophan, string tenbp)
        {
            return _bophan.Save(idbophan, tenbp);
        }
    }
}
