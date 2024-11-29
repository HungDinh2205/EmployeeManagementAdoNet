using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangcongController : ControllerBase
    {
        private IBangcongBUS _bangcongbus;
        public BangcongController(IBangcongBUS bangcong)
        {
            _bangcongbus = bangcong;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]BangcongData model)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _bangcongbus.Create(model);
                if (isCreated)
                {
                    return Ok(model);
                }
                return BadRequest("Thêm 0 thành công");
            }
            return BadRequest(ModelState);
        }
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateItem([FromBody] BangcongData model)
        {

            if (ModelState.IsValid)
            {
                var isUpdated = _bangcongbus.Update(model);
                if (!isUpdated)
                {
                    return Ok(model);
                }
                return BadRequest("Sửa 0 thành công");
            }
            return BadRequest(ModelState);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idbangcong) 
        {

                var isDeleted = _bangcongbus.Delete(idbangcong);
                if (!isDeleted)
                {
                    return Ok("Xoá thành công");
                }
                return BadRequest("Xoá không thành công");

        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _bangcongbus.GetAll();
            if (items != null && items.Any())
            {
                return Ok(new
                {
                    Message = " thành công",
                    Status = true,
                    Data = items
                });
            }
            return NotFound(new
            {
                Message = "Không có dữ liệu",
                Status = false
            });
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> SaveItem([FromBody] BangcongData model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = _bangcongbus.Save(model);
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
