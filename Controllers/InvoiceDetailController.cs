using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.Services.InvoiceDetailAppService;
using app.api.Services.InvoiceDetailAppService.Dto;
using app.api.Services.InvoiceDetailAppService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{
    [ApiController]
    [Route("invoices-detail")]
    public class InvoiceDetailController : ControllerBase
    {

         private readonly IInvoiceDetailAppService _invoiceDetailAppService;
        public InvoiceDetailController(IInvoiceDetailAppService invoiceDetailAppService)
        {
            ThrowIf.Argument.IsNull(invoiceDetailAppService, nameof(invoiceDetailAppService));

            _invoiceDetailAppService = invoiceDetailAppService;
        }

        [HttpGet("all")]
        public async Task<List<InvoiceDetailDto>> GetAllAync()
        {
            return await _invoiceDetailAppService.GetAllAsync();
        }

        [HttpGet("{invoiceId:int}")]
        public async Task<List<InvoiceDetailDto>> GetSingleAync(int invoiceId)
        {
            return await _invoiceDetailAppService.GetFilteredAsync(invoiceId);
        }

        [HttpPost]
        public async Task<InvoiceDetailDto> AddAsync(InvoiceDetailRequest request)
        {
            return await _invoiceDetailAppService.AddAsync(request);
        }

        [HttpDelete("{invoiceId:int}")]
        public async Task<InvoiceDetailDto> RemoveAync(int invoiceId)
        {
            return await _invoiceDetailAppService.RemoveAsync(invoiceId);
        }
    }
}