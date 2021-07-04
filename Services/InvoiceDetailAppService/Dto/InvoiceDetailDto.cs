using app.api.Core.Dto;
using app.api.Services.ClientService.Dto;
using app.api.Services.InvoiceAppService.Dto;
using app.api.Services.ProductAppService.Dto;

namespace app.api.Services.InvoiceDetailAppService.Dto
{
    public class InvoiceDetailDto : BaseDto
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
        public ClientDto ClientDto { get; set; }
        public InvoiceDto InvoiceDto { get; set; }
        public float? Quantity { get; set; }
        public float? SubTotal { get; set; }
    }
}