using BUS.Interfaces;
using DAL.Interfaces;
using DataModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TrinhdoBUS : ITrinhdoBUS
    {
        private ITrinhdoDAL _trinhdo;
        public TrinhdoBUS(ITrinhdoDAL trinhdo)
        {
            _trinhdo = trinhdo;
        }
        public TrinhdoData GetById(int idtrinhdo)
        {
            return _trinhdo.GetById(idtrinhdo);
        }
        public bool Create(TrinhdoData model)
        {
            return _trinhdo.Create(model);
        }
        public bool Update(TrinhdoData model)
        {
            return _trinhdo.Update(model);
        }
        public bool Delete(int idtrinhdo)
        {
            return _trinhdo.Delete(idtrinhdo);
        }
        public List<TrinhdoData> GetAll()
        {
            return _trinhdo.GetAll();
        }
        public bool Save(int? idtrinhdo, string tentd)
        {
            return _trinhdo.Save(idtrinhdo, tentd);
        }

        
    }
}