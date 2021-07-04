using System.Collections.Generic;

using app.api.DataContext.BaseEntities;

namespace app.api.DataContext.Models
{
    public partial class Client : Entity
    {
        public int IdClient { get; set; }
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public bool State { get; set; }

        public virtual ICollection<InvoiceDetail> InvoicesDetail { get; set; }
    }
}