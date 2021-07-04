using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using app.api.DataContext.BaseEntities;

namespace app.api.DataContext.Models
{
    public partial class Invoice : Entity
    {
        public int Id { get; set; }


        [ForeignKey("IndentifierClient")]
        public virtual Client Client { get; set; }
        public string IndentifierClient { get; set; }


        public DateTime? Date { get; set; }
        public float? Total { get; set; }

        public virtual ICollection<InvoiceDetail> InvoicesDetail { get; set; }
    }
}