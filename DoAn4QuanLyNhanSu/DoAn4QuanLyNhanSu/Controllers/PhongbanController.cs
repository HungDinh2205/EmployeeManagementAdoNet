using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongbanController : ControllerBase
    {
        public IPhongbanBUS _phongbanbus;
        public PhongbanController(IPhongbanBUS phongbanBusiness)
        {
            _phongbanbus = phongbanBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<PhongbanData> GetAll()
        {
            return _phongbanbus.GetAll();

        }
        [Route("get_by_id/{idphongban}")]
        [HttpGet]
        public PhongbanData GetById(int idphongban)
        {
            return _phongbanbus.GetById(idphongban);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<PhongbanData> CreateItem([FromBody] PhongbanData model)
        {
            _phongbanbus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<PhongbanData> UpdateItem([FromBody] PhongbanData model)
        {
            _phongbanbus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idphongban)
        {
            try
            {
                bool result = _phongbanbus.Delete(idphongban);
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
        public async Task<IActionResult> SaveItem([FromBody] PhongbanData model)
        {
            var result = _phongbanbus.Save(model.idphongban, model.tenpb);
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
