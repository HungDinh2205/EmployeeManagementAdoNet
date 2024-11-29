using BUS.Interfaces;
using DAL.Interfaces;
using DAO.Helper;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BangcongBUS : IBangcongBUS
    {
        private IBangcongDAL _bangcong;
        public BangcongBUS(IBangcongDAL bangcong)
        {
            _bangcong = bangcong;
        }
        public bool Create(BangcongData model)
        {
            return _bangcong.Create(model);
        }

        public bool Delete(int idbangcong)
        {
            return _bangcong.Delete(idbangcong);
        }

        public List<BangcongData> GetAll()
        {
            return _bangcong.GetAll();
        }

        public bool Save(BangcongData model)
        {
            return _bangcong.Save(model);
        }

        public bool Update(BangcongData model)
        {
            return _bangcong.Update(model);
        }
    }
}
