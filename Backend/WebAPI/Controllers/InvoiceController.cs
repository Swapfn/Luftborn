using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;
using Services.Services;

namespace WebAPI.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController(IInvoiceService InvoiceService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoices()
        {
            return Ok(InvoiceService.GetInvoices());
        }
        [HttpGet("{pageNumber},{pageSize}")]
        public IActionResult GetFilteredInvoices(int pageNumber, int pageSize)
        {
            return Ok(InvoiceService.GetInvoices(pageNumber, pageSize));
        }
        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            return Ok(InvoiceService.GetInvoice(id));
        }
        [HttpPost]
        public IActionResult AddInvoice(InvoiceDTO model)
        {
            if (ModelState.IsValid)
            {
                return Created("", InvoiceService.AddInvoice(model));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateInvoice(InvoiceDTO model)
        {
            if (ModelState.IsValid)
            {
                return Ok(InvoiceService.UpdateInvoice(model));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            if (ModelState.IsValid)
            {
                InvoiceService.DeleteInvoice(id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
