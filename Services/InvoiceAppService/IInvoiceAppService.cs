using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Services.InvoiceAppService.Dto;
using app.api.Services.InvoiceAppService.Requests;

namespace app.api.Services.InvoiceAppService
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetSingleAsync(int invoiceId);
        Task<List<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto> AddAsync(InvoiceRequest request);
        Task<InvoiceDto> RemoveAsync(int invoiceId);
        Task<InvoiceDto> ModifyAsync(InvoiceRequest request);
    }
}