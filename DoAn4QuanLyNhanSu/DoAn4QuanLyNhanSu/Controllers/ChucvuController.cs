using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucvuController : ControllerBase
    {
        private IChucvuBUS _chucvubus;

        public ChucvuController(IChucvuBUS chucvuBusiness)
        {
            _chucvubus = chucvuBusiness;
        }
        [Route("get_by_id/{idchucvu}")]
        [HttpGet]
        public ChucvuData GetById(int idchucvu)
        {
            return _chucvubus.GetById(idchucvu);
        }
        [Route("get_all")]
        [HttpGet]
        public List<ChucvuData> GetAll()
        {
            return _chucvubus.GetAll();

        }
        [Route("Create")]
        [HttpPost]
        public async Task<ChucvuData> CreateItem([FromBody] ChucvuData model)
        {
            _chucvubus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<ChucvuData> UpdateItem([FromBody] ChucvuData model)
        {
            _chucvubus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idchucvu)
        {
            try
            {
                bool result = _chucvubus.Delete(idchucvu);
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
        public async Task<IActionResult> SaveItem([FromBody] ChucvuData model)
        {
            var result = _chucvubus.Save(model.idchucvu, model.tencv);
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
