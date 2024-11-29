using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DantocController : ControllerBase
    {
        public IDantocBUS _dantocbus;
        public DantocController(IDantocBUS dantocBusiness)
        {
            _dantocbus = dantocBusiness;
        }
        [Route("get_by_id/{iddantoc}")]
        [HttpGet]
        public DantocData GetById(int iddantoc)
        {
            return _dantocbus.GetById(iddantoc);
        }
        [Route("get_all")]
        [HttpGet]
        public List<DantocData> GetAll()
        {
            return _dantocbus.GetAll();

        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] DantocData model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _dantocbus.Create(model);
                if (isCreated)
                {
                    return Ok(model); // Trả về 200 OK với dữ liệu nhân viên
                }
                return BadRequest("Failed to create dantoc"); // Trả về 400 BadRequest nếu có lỗi
            }
            return BadRequest(ModelState); // Trả về lỗi 400 nếu dữ liệu không hợp lệ
        }

        [Route("Update")]
        [HttpPost]
        public async Task<DantocData> UpdateItem([FromBody] DantocData model)
        {
            _dantocbus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int iddantoc)
        {
            try
            {
                bool result = _dantocbus.Delete(iddantoc);
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
        public async Task<IActionResult> SaveItem([FromBody] DantocData model)
        {
            var result = _dantocbus.Save(model.iddantoc, model.tendantoc);
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
