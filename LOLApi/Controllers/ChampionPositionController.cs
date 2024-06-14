using LOLApi.Interface;
using LOLApi.Model;
using LOLApi.Service;
using LOLApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LOLApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ChampionPositionController : ControllerBase
    {
        private readonly IChampionPosition _champPositionRepo;

        public ChampionPositionController(IChampionPosition champPositionRepo)
        {
            _champPositionRepo = champPositionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetOneChampionPosition([FromQuery] int id)
        {
            try
            {
                var response = await _champPositionRepo.GetChampionPosition(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChampionPosition()
        {
            try
            {
                var response = await _champPositionRepo.GetAllChampionPosition();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChampion([FromBody] UpdateChampionVM vm)
        {
            try
            {
                if (vm == null)
                {
                    return BadRequest();
                }
                var ifExist = await _champPositionRepo.IfPositionExists(vm.Id);
                if (!ifExist)
                {
                    return NotFound();
                }
                var model = new ChampionPosition()
                {
                    Id = vm.Id,
                    PositionName = vm.PositionName
                };
                _champPositionRepo.UpdateData(model);
                await _champPositionRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChampion([FromQuery] int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest();
                }
                var dataToDelete = await _champPositionRepo.GetDataById(id);
                if(dataToDelete == null)
                {
                    return NoContent();
                }
                _champPositionRepo.RemoveData(dataToDelete);
                await _champPositionRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
