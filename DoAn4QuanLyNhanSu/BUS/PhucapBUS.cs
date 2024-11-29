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
    public class PhucapBUS : IPhucapBUS
    {
        private IPhucapDAL _phucap;
        public PhucapBUS(IPhucapDAL phucap)
        {
            _phucap = phucap;
        }
        public bool Create(PhucapData model)
        {
            return _phucap.Create(model);
        }
        public bool Update(PhucapData model)
        {
            return _phucap.Update(model);
        }
        public bool Delete(int? idphucap) 
        { 
            return _phucap.Delete(idphucap);
        }
        public List<PhucapData> GetAll()
        {
            return _phucap.GetAll();
        }
        public bool Save(int? idphucap, string tenphucap, float? sotien)
        {
            return _phucap.Save(idphucap, tenphucap, sotien);
        }
    }
}
