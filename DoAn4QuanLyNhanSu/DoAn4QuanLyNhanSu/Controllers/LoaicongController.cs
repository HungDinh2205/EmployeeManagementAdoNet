using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaicongController : ControllerBase
    {
        public ILoaicongBUS _loaicongbus;
        public LoaicongController(ILoaicongBUS loaicongBusiness)
        {
            _loaicongbus = loaicongBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<LoaicongData> GetAll()
        {
            return _loaicongbus.GetAll();

        }

        [Route("Create")]
        [HttpPost]
        public async Task<LoaicongData> CreateItem([FromBody] LoaicongData model)
        {
            _loaicongbus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<LoaicongData> UpdateItem([FromBody] LoaicongData model)
        {
            _loaicongbus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idloaicong)
        {
            try
            {
                bool result = _loaicongbus.Delete(idloaicong);
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
        public async Task<IActionResult> SaveItem([FromBody] LoaicongData model)
        {
            var result = _loaicongbus.Save(model.idloaicong, model.tenloaicong, model.hesocong);
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
