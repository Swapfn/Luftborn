﻿using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoreController(IStoreService storeService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStores()
        {
            return Ok(storeService.GetStores());
        }
        [HttpGet("{pageNumber},{pageSize}")]
        public IActionResult GetFilteredStoress(int pageNumber, int pageSize)
        {
            return Ok(storeService.GetStores(pageNumber, pageSize));
        }
        [HttpGet("{id}")]
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
        [HttpPut]
        public IActionResult UpdateStore(StoreDTO model)
        {
            if (ModelState.IsValid)
            {
                return Ok(storeService.UpdateStore(model));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            if (ModelState.IsValid)
            {
                storeService.DeleteStore(id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
