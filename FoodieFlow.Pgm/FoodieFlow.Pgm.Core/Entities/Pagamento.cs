using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.SharedKernel.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieFlow.Pgm.Core.Entities
{
    public class Pagamento : BaseEntity
    {
        public float TransactionAmount { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public EnumMetodoPagamento PaymentMethodId { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public EnumStatus Status { get; set; }
    }
}
