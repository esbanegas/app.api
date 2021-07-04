using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.api.DataContext.BaseEntities
{
    public class Entity
    {
        protected Entity()
        {

        }

        protected Entity(DateTime transactionDate)
        {
           TransactionDate = transactionDate;
        }

        [NotMapped]
        public DateTime TransactionDate { get; set; }
    }
}