using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.SharedKernel.Bases;

namespace FoodieFlow.Pgm.Core.Entities.Request
{
    public class RequestPagamento : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public List<Produto> PedidoCompleto { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.a_pagar;
        public EnumMetodoPagamento MetodoPagamento { get; set; }
    }
}
