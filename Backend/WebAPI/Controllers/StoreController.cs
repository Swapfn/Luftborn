using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoreController(IStoreService storeService) : ControllerBase
    {
        [HttpGet("/{id}")]
        public IActionResult GetStore(int id)
        {
            return Ok(storeService.GetStore(id));
        }
        [HttpPost]
        public IActionResult AddStore(StoreDTO model)
        {
            if (ModelState.IsValid)
            {
                return Created("", storeService.AddStore(model));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
