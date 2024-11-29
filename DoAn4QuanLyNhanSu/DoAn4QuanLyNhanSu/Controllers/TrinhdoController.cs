using BUS;
using BUS.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrinhdoController : ControllerBase
    {
        public ITrinhdoBUS _trinhdobus;
        public TrinhdoController(ITrinhdoBUS trinhdoBusiness)
        {
            _trinhdobus = trinhdoBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<TrinhdoData> GetAll()
        {
            return _trinhdobus.GetAll();

        }
        [Route("get_by_id/{idtrinhdo}")]
        [HttpGet]
        public TrinhdoData GetById(int idtrinhdo)
        {
            return _trinhdobus.GetById(idtrinhdo);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<TrinhdoData> CreateItem([FromBody] TrinhdoData model)
        {
            _trinhdobus.Create(model);
            return model;

        }

        [Route("Update")]
        [HttpPost]
        public async Task<TrinhdoData> UpdateItem([FromBody] TrinhdoData model)
        {
            _trinhdobus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idtrinhdo)
        {
            try
            {
                bool result = _trinhdobus.Delete(idtrinhdo);
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
        public async Task<IActionResult> SaveItem([FromBody] TrinhdoData model)
        {
            var result = _trinhdobus.Save(model.idtrinhdo, model.tentd);
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
