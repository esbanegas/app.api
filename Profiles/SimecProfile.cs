
using app.api.DataContext.Models;
using app.api.Services.ClientService.Dto;
using app.api.Services.InvoiceAppService.Dto;
using app.api.Services.InvoiceDetailAppService.Dto;
using app.api.Services.ProductAppService.Dto;
using AutoMapper;

namespace app.api.Profiles
{
    public class SimecProfile : Profile
    {
        public SimecProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<Product, ProductDto>();

            var mapInvoice = CreateMap<Invoice, InvoiceDto>();
            mapInvoice.ForMember(a => a.ClientDto, b => b.MapFrom(c => c.Client));

            var mapInvoiceDetail = CreateMap<InvoiceDetail, InvoiceDetailDto>();
            mapInvoiceDetail.ForMember(a => a.ProductDto, b => b.MapFrom(c => c.Product));
            mapInvoiceDetail.ForMember(a => a.ClientDto, b => b.MapFrom(c => c.Client));
            mapInvoiceDetail.ForMember(a => a.InvoiceDto, b => b.MapFrom(c => c.Invoice));
        }
    }
}