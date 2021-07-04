using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.Services.InvoiceAppService;
using app.api.Services.InvoiceAppService.Dto;
using app.api.Services.InvoiceAppService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{

    [ApiController]
    [Route("invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;
        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            ThrowIf.Argument.IsNull(invoiceAppService, nameof(invoiceAppService));

            _invoiceAppService = invoiceAppService;
        }

        [HttpGet("all")]
        public async Task<List<InvoiceDto>> GetAllAync()
        {
            return await _invoiceAppService.GetAllAsync();
        }

        [HttpGet("{invoiceId:int}")]
        public async Task<InvoiceDto> GetSingleAync(int invoiceId)
        {
            return await _invoiceAppService.GetSingleAsync(invoiceId);
        }

        [HttpPost]
        public async Task<InvoiceDto> AddAsync(InvoiceRequest request)
        {
            return await _invoiceAppService.AddAsync(request);
        }

        [HttpDelete("{invoiceId:int}")]
        public async Task<InvoiceDto> RemoveAync(int invoiceId)
        {
            return await _invoiceAppService.RemoveAsync(invoiceId);
        }

        [HttpPut]
        public async Task<InvoiceDto> ModifyAsync(InvoiceRequest request)
        {
            return await _invoiceAppService.ModifyAsync(request);
        }
    }
}