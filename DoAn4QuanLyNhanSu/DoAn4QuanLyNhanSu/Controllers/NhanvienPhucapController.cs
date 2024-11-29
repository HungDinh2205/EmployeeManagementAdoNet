using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienPhucapController : ControllerBase
    {
        private INhanvienPhucapBUS _nhanvienphucap;
        public NhanvienPhucapController(INhanvienPhucapBUS nhanvienphucap)
        {
            _nhanvienphucap = nhanvienphucap;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]Nhanvien_Phucap model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _nhanvienphucap.Create(model);
                if (isCreated)
                {
                    return Ok(model); // Trả về 200 OK với dữ liệu nhân viên
                }
                return BadRequest("Failed to create "); // Trả về 400 BadRequest nếu có lỗi
            }
            return BadRequest(ModelState);
        }
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateItem([FromBody] Nhanvien_Phucap model)
        {
            if (!ModelState.IsValid)
            {
                var isUpdated = _nhanvienphucap.Update(model);
                if (isUpdated)
                {
                    return Ok(model);
                }
                return BadRequest("Failed to update employee");
            }
            return BadRequest(ModelState);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idnvpc)
        {
            var isDeleted = _nhanvienphucap.Delete(idnvpc);
            if (isDeleted)
            {
                return Ok("Xoá thành công");
            }
            return BadRequest("Xoá thất bại");
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody]Nhanvien_Phucap model)
        {

            if (ModelState.IsValid)
            {
                var isSaved = _nhanvienphucap.Save(model);
                if (isSaved)
                {
                    return Ok("lưu thành công");
                }
                return BadRequest("Không thành công");
            }
            return BadRequest(ModelState);
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllItem()
        {
            var items = _nhanvienphucap.GetAll();

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
    }
}
