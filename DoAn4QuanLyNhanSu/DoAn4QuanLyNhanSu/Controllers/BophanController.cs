using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BophanController : ControllerBase
    {
        private IBophanBUS _bophanbus;

        public BophanController(IBophanBUS bophanBusiness)
        {
            _bophanbus = bophanBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<BophanData> GetAll()
        {
            return _bophanbus.GetAll();

        }
        [Route("get_by_id/{idbophan}")]
        [HttpGet]
        public BophanData GetById(int idbophan)
        {
            return _bophanbus.GetById(idbophan);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<BophanData> CreateItem([FromBody] BophanData model)
        {
            _bophanbus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<BophanData> UpdateItem([FromBody] BophanData model)
        {
            _bophanbus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idbophan)
        {
            try
            {
                bool result = _bophanbus.Delete(idbophan);
                if (result)
                {
                    return Ok("Xóa thành công");
                }
                else
                {
                    return BadRequest("Không tìm thấy hoặc xóa không thành công");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody] BophanData model)
        {
            var result = _bophanbus.Save(model.idbophan, model.tenbp);
            if (result)
            {
                return Ok("Lưu thành công!");
            }
            else
            {
                return BadRequest("Lỗi khi lưu dữ liệu.");
            }
        }
    }
}
