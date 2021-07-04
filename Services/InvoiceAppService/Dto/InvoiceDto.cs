using System;
using System.Collections.Generic;
using app.api.Core.Dto;
using app.api.Services.ClientService.Dto;

namespace app.api.Services.InvoiceAppService.Dto
{
    public class InvoiceDto : BaseDto
    {
        public int? Id { get; set; }
        public ClientDto ClientDto { get; set; }
        public string IndentifierClient { get; set; }
        public DateTime? Date { get; set; }
        public float? Total { get; set; }

        // public List<> InvoicesDetail { get; set; }
    }
}