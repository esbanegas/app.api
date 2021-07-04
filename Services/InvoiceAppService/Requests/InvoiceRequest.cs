using System;

namespace app.api.Services.InvoiceAppService.Requests
{
    public class InvoiceRequest
    {
        public int Id { get; set; }
        public string IndentifierClient { get; set; }
        public DateTime? Date { get; set; }
        public float? Total { get; set; }
    }
}