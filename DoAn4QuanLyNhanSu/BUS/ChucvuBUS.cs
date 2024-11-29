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
    public class ChucvuBUS : IChucvuBUS
    {
        private IChucvuDAL _chucvu;
        public ChucvuBUS(IChucvuDAL chucvu)
        {
            _chucvu = chucvu;
        }
        public ChucvuData GetById(int idchucvu)
        {
            return _chucvu.GetById(idchucvu);
        }
        public bool Create(ChucvuData model)
        {
            return _chucvu.Create(model);
        }
        public bool Update(ChucvuData model)
        {
            return _chucvu.Update(model);
        }
        public bool Delete(int idchucvu)
        {
            return _chucvu.Delete(idchucvu);
        }
        public List<ChucvuData> GetAll()
        {
            return _chucvu.GetAll();
        }
        public bool Save(int? idchucvu, string tencv)
        {
            return _chucvu.Save(idchucvu, tencv);
        }
    }
}
