using BUS.Interfaces;
using DataModel;
using BUS;
using Microsoft.AspNetCore.Mvc;

namespace DoAn4QuanLyNhanSuAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TongiaoController : ControllerBase
    {
        public ITongiaoBUS _tongiaobus;
        public TongiaoController(ITongiaoBUS tongiaoBusiness)
        {
            _tongiaobus = tongiaoBusiness;
        }
        [Route("get_all")]
        [HttpGet]
        public List<TongiaoData> GetAll()
        {
            return _tongiaobus.GetAll();

        }
        [Route("get_by_id/{idtongiao}")]
        [HttpGet]
        public TongiaoData GetById(int idtongiao)
        {
            return _tongiaobus.GetById(idtongiao);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] TongiaoData model)
        {
            Console.WriteLine($"Received: idtongiao={model.idtongiao}, tentongiao={model.tentongiao}");
            _tongiaobus.Create(model);
            return Ok(model);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<TongiaoData> UpdateItem([FromBody] TongiaoData model)
        {
            _tongiaobus.Update(model);
            return model;
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteItem(int idtongiao)
        {
            try
            {
                bool result = _tongiaobus.Delete(idtongiao);
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
        public async Task<IActionResult> SaveItem([FromBody] TongiaoData model)
        {
            var result = _tongiaobus.Save(model.idtongiao, model.tentongiao);
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
