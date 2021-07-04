using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.api.Core;
using app.api.DataContext;
using app.api.DataContext.Models;
using app.api.DataContext.Repository;
using app.api.Services.InvoiceDetailAppService.Dto;
using app.api.Services.InvoiceDetailAppService.Requests;

namespace app.api.Services.InvoiceDetailAppService
{
    public class InvoiceDetailAppService : IInvoiceDetailAppService
    {
        private readonly IGenericRepository<DBDataContext> _genericRepository;
        public InvoiceDetailAppService(IGenericRepository<DBDataContext> genericRepository)
        {
            ThrowIf.Argument.IsNull(genericRepository, nameof(genericRepository));

            _genericRepository = genericRepository;
        }

        public async Task<InvoiceDetailDto> AddAsync(InvoiceDetailRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));

            _genericRepository.Add<InvoiceDetail>(new InvoiceDetail
            {
                IdProduct = request.IdProduct,
                IdClient = request.IdClient,
                IdInvoice = request.IdInvoice,
                Quantity = request.Quantity,
                SubTotal = request.SubTotal
            });

            await _genericRepository.UnitOfWork.Commit();

            return new InvoiceDetailDto();
        }

        public async Task<List<InvoiceDetailDto>> GetAllAsync()
        {
            List<InvoiceDetail> invoiceDetails = await _genericRepository.GetAllAsync<InvoiceDetail>();

            return invoiceDetails.ProjectedAsCollection<InvoiceDetailDto>();
        }

        public async Task<List<InvoiceDetailDto>> GetFilteredAsync(int invoiceId)
        {
            List<InvoiceDetail> invoiceDetail = await _genericRepository.GetFilteredAsync<InvoiceDetail>(s => s.IdInvoice == invoiceId);

            return invoiceDetail.ProjectedAsCollection<InvoiceDetailDto>();
        }

        public async Task<InvoiceDetailDto> RemoveAsync(int invoiceId)
        {
            ThrowIf.Argument.IsNull(invoiceId, nameof(invoiceId));

            List<InvoiceDetail> detail = await _genericRepository.GetFilteredAsync<InvoiceDetail>(s => s.IdInvoice == invoiceId);

            if (!detail.Any()) return NotFount();

            _genericRepository.RemoveRange(detail);

            await _genericRepository.UnitOfWork.Commit();

            return new InvoiceDetailDto();
        }

        private InvoiceDetailDto NotFount()
        {
            return new InvoiceDetailDto
            {
                Code = 404,
                Message = "El detalle de factura no existe."
            };
        }
    }
}