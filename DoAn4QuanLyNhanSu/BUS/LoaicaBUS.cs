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
    public class LoaicaBUS : ILoaicaBUS
    {
        public ILoaicaDAL _loaica;
        public LoaicaBUS(ILoaicaDAL loaica)
        {
            _loaica = loaica;
        }
        public bool Create(LoaicaData model)
        {
            return _loaica.Create(model);
        }
        public bool Update(LoaicaData model)
        {
            return _loaica.Update(model);
        }
        public bool Delete(int idloaica) 
        {
            return _loaica.Delete(idloaica);
        }
        public List<LoaicaData> GetAll()
        {
            return _loaica.GetAll();
        }
        public bool Save(int? idloaica, string tenloaica, float? hesoca)
        {
            return _loaica.Save(idloaica, tenloaica, hesoca);
        }
    }
}
