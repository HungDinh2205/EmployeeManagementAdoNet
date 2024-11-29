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
    public class LoaicongBUS : ILoaicongBUS
    {
        private ILoaicongDAL _loaicong;
        public LoaicongBUS(ILoaicongDAL loaicong)
        {
            _loaicong = loaicong;
        }
        public bool Create(LoaicongData model)
        {
            return _loaicong.Create(model);
        }
        public bool Update(LoaicongData model)
        {
            return _loaicong.Update(model);
        }
        public bool Delete(int idloaicong)
        {
            return _loaicong.Delete(idloaicong);
        }
        public bool Save(int? idloaicong, string tenloaicong, float? hesocong) {
            return _loaicong.Save(idloaicong, tenloaicong, hesocong);
        }
        public List<LoaicongData> GetAll()
        {
            return _loaicong.GetAll();
        }
    }
}
