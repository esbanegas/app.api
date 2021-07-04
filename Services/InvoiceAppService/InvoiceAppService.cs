using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.DataContext;
using app.api.DataContext.Models;
using app.api.DataContext.Repository;
using app.api.Services.InvoiceAppService.Dto;
using app.api.Services.InvoiceAppService.Requests;

namespace app.api.Services.InvoiceAppService
{
    public class InvoiceAppService : IInvoiceAppService
    {
        private readonly IGenericRepository<DBDataContext> _genericRepository;
        public InvoiceAppService(IGenericRepository<DBDataContext> genericRepository)
        {
            ThrowIf.Argument.IsNull(genericRepository, nameof(genericRepository));

            _genericRepository = genericRepository;
        }
        public async Task<InvoiceDto> AddAsync(InvoiceRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));

            _genericRepository.Add<Invoice>(new Invoice
            {
                IndentifierClient = request.IndentifierClient,
                Date = request.Date,
                Total = request.Total
            });

            await _genericRepository.UnitOfWork.Commit();

            return new InvoiceDto();
        }

        public async Task<List<InvoiceDto>> GetAllAsync()
        {
            List<Invoice> invoices = await _genericRepository.GetAllAsync<Invoice>();

            return invoices.ProjectedAsCollection<InvoiceDto>();
        }

        public async Task<InvoiceDto> GetSingleAsync(int invoiceId)
        {
            ThrowIf.Argument.IsNull(invoiceId, nameof(invoiceId));

            Invoice invoice = await _genericRepository.GetSingleAsync<Invoice>(s => s.Id == invoiceId);

            if (invoice == null) return new InvoiceDto();

            return invoice.ProjectedAsItem<InvoiceDto>();
        }

        public async Task<InvoiceDto> RemoveAsync(int invoiceId)
        {
            ThrowIf.Argument.IsNull(invoiceId, nameof(invoiceId));

            Invoice invoice = await _genericRepository.GetSingleAsync<Invoice>(s => s.Id == invoiceId);

            if (invoice == null) return NotFount();

            _genericRepository.Remove<Invoice>(invoice);

            await _genericRepository.UnitOfWork.Commit();

            return new InvoiceDto();
        }

        public async Task<InvoiceDto> ModifyAsync(InvoiceRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.Id, nameof(request.Id));

            Invoice invoice = await _genericRepository.GetSingleAsync<Invoice>(s => s.Id == request.Id);

            if (invoice == null) return NotFount();

            invoice.IndentifierClient = request.IndentifierClient;
            invoice.Date = request.Date;
            invoice.Total = request.Total;

            await _genericRepository.UnitOfWork.Commit();

            return new InvoiceDto
            {
                Code = 200,
                Message = "Invoice is modified"
            };
        }

        private InvoiceDto NotFount()
        {
            return new InvoiceDto
            {
                Code = 404,
                Message = "La factura no existe."
            };
        }
    }
}