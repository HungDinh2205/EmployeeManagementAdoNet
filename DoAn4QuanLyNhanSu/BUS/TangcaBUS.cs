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
    public class TangcaBUS : ITangcaBUS
    {
        private ITangcaDAL  _tangca;
        public TangcaBUS(ITangcaDAL tangca) { _tangca = tangca; }
        public bool Create(TangcaData model) {  return _tangca.Create(model);}
        public bool Update(TangcaData model) { return _tangca.Update(model);}
        public bool Delete(int  idtangca) { return _tangca.Delete(idtangca); }
        public bool Save(TangcaData model) { return _tangca.Save(model);}
        public List<TangcaData> GetAll() { return _tangca.GetAll(); }

    }
}
