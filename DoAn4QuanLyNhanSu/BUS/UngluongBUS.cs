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
    public class UngluongBUS : IUngluongBUS
    {
        private IUngluongDAL _ungluongbus;
        public UngluongBUS(IUngluongDAL ungluong) { _ungluongbus = ungluong; }
        public bool Create(UngluongData model) { return _ungluongbus.Create(model);}
        public bool Update(UngluongData model) { return _ungluongbus.Update(model);}
        public bool Delete(int idungluong) { return _ungluongbus.Delete(idungluong);}
        public bool Save(UngluongData model) { return _ungluongbus.Save(model);}
        public List<UngluongData> GetAll() { return _ungluongbus.GetAll(); }
    }
}
