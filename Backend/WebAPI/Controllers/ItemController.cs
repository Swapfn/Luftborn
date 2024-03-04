using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController(IItemService ItemService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(ItemService.GetItems());
        }
        [HttpGet("{pageNumber},{pageSize}")]
        public IActionResult GetFilteredItems(int pageNumber, int pageSize)
        {
            var (Items, Count) = ItemService.GetItems(pageNumber, pageSize);
            return Ok(new PagedList<ItemDTO>(Items, Count));
        }
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            return Ok(ItemService.GetItem(id));
        }
        [HttpPost]
        public IActionResult AddItem(ItemDTO model)
        {
            if (ModelState.IsValid)
            {
                return Created("", ItemService.AddItem(model));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateItem(ItemDTO model)
        {
            if (ModelState.IsValid)
            {
                return Ok(ItemService.UpdateItem(model));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (ModelState.IsValid)
            {
                ItemService.DeleteItem(id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
