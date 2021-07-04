using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Services.InvoiceDetailAppService.Dto;
using app.api.Services.InvoiceDetailAppService.Requests;

namespace app.api.Services.InvoiceDetailAppService
{
    public interface IInvoiceDetailAppService
    {
        Task<List<InvoiceDetailDto>> GetFilteredAsync(int invoiceId);
        Task<List<InvoiceDetailDto>> GetAllAsync();
        Task<InvoiceDetailDto> AddAsync(InvoiceDetailRequest request);
        Task<InvoiceDetailDto> RemoveAsync(int invoiceId);
    }
}