using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhucapController : ControllerBase
    {
        public IPhucapBUS _phucapbus;
        public PhucapController(IPhucapBUS phucapbus)
        {
            _phucapbus = phucapbus;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] PhucapData model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _phucapbus.Create(model);
                if (isCreated)
                {
                    return Ok(model); // Trả về 200 OK với dữ liệu nhân viên
                }
                return BadRequest("Them that bai"); // Trả về 400 BadRequest nếu có lỗi
            }
            return BadRequest(ModelState);
        }
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateItem([FromBody] PhucapData model)
        {
            if (ModelState.IsValid)
            {
                var isUpdate = _phucapbus.Update(model);
                if (!isUpdate)
                {
                    return Ok(model);
                }
                return BadRequest("That bai");
            }
            return BadRequest(ModelState);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int? idphucap)
        {
            var isDeleted = _phucapbus.Delete(idphucap);
            if (isDeleted)
            {
                return Ok("Xoá thành công");
            }
            return BadRequest("Xoá thất bại");
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllItem()
        {
            var items = _phucapbus.GetAll();

            // Kiểm tra items không null và không rỗng
            if (items != null && items.Any())
            {
                return Ok(new
                {
                    Message = "Thành công",
                    Status = true,
                    Data = items
                });
            }

            // Trả về NotFound nếu không có dữ liệu
            return NotFound(new
            {
                Message = "Không có dữ liệu",
                Status = false
            });
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody] PhucapData model)
        {
            if (!ModelState.IsValid)
            {
                var isSaved = _phucapbus.Save(model.idphucap, model.tenphucap, model.sotien);
                if (isSaved)
                {
                    return Ok(new
                    {
                        Message = "Lưu thành công",
                        Status = true
                    });
                }

                return BadRequest(new
                {
                    Message = "Lưu không thành công",
                    Status = false
                });
            }
            return BadRequest(ModelState);
        }
    }
}
