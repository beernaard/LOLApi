using LOLApi.Interface;
using LOLApi.Model;
using LOLApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LOLApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private readonly IChampion _championRepo;
        private readonly IChampionService _championService;

        public ChampionController(IChampion championRepo,IChampionService championService)
        {
            _championRepo = championRepo;
            _championService = championService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var response = await _championRepo.GetAllData();
                if (response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("/basicdetails/{id}")]
        public async Task<IActionResult> GetOneBasicChampionData([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var response = await _championRepo.GetBasicInfoOfOneChampion(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllChampionBasicData()
        {
            try
            {
                var response = await _championRepo.GetBasicInfoOfAllChampion();
                if (response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public async Task<IActionResult> PaginatedGetAllChampionBasicData([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var response = await _championRepo.PaginatedOfFullDetailChampion(pageNumber, pageSize);
                if (response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllChampionFullDetails()
        {
            try
            {
                var response = await _championRepo.GetAllCompleteDetails();
                if (response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchChampionByName([FromQuery] string searchString)
        {
            try
            {
                if (searchString.IsNullOrEmpty())
                {
                    return BadRequest();
                }
                var response = await _championRepo.GetChampionByName(searchString);
                if(response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionByPosition([FromQuery] int positionId)
        {
            try
            {
                if (positionId == 0)
                {
                    return BadRequest();
                }
                var response = await _championRepo.GetChampionByPosition(positionId);
                if (response.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/fulldetails/{id}")]
        public async Task<IActionResult> GetOneChampionFullDetails([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var response = await _championRepo.GetOneCompleteDetails(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneChampion([FromBody] CreateChampionViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }
                var mappedResponse = new Champion()
                {
                    ChampionName = viewModel.ChampionName,
                    championTitle = viewModel.championTitle,
                    championImage = viewModel.championImage,
                    championDescription = viewModel.championDescription,
                    PositionId = viewModel.PositionId,
                };
                await _championRepo.AddData(mappedResponse);
                await _championRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateListOfChampion([FromBody] List<Champion> listOfModel)
        {
            try
            {
                if (listOfModel.Count == 0)
                {
                    return BadRequest();
                }
                await _championRepo.AddRange(listOfModel);
                await _championRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateChampion([FromBody] Champion model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var ifExist = await _championService.ChampionExists(model.Id);
                if (!ifExist)
                {
                    return NotFound();
                }

                _championRepo.UpdateData(model);
                await _championRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOneChampion([FromBody] ListOfIdModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var response = await _championRepo.GetDataById(model.id);
                if (response == null)
                {
                    return NotFound();
                }

                _championRepo.RemoveData(response);
                await _championRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteListOfChampion([FromBody] List<ListOfIdModel> model)
        {
            try
            {
                if (model.Count() == 0)
                {
                    return BadRequest();
                }
                var listOfId = _championService.GetListOfId(model);
                var listOfModel = await _championService.GetListOfChampionBasedOnListOfId(listOfId);
                _championRepo.RemoveRange(listOfModel);
                await _championRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
