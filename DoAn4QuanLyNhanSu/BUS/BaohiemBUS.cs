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
    public class BaohiemBUS : IBaohiemBUS
    {
        private IBaohiemDAL  _baohiem;
        public BaohiemBUS(IBaohiemDAL baohiem) { _baohiem = baohiem; }
        public bool Create(BaohiemData model)
        {
            return _baohiem.Create(model);
        }
        public bool Update(BaohiemData model) { return _baohiem.Update(model); }
        public bool Delete(int? idbaohiem) { return _baohiem.Delete(idbaohiem); }
        public bool Save(BaohiemData model) { return _baohiem.Save(model); }
        public List<BaohiemData> GetAll() {  return _baohiem.GetAll(); }
    }
}
