using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieFlow.Pgm.Core.Interfaces.Service
{
    public interface IProcessamentoPagamentoService
    {
        Task<Pagamento> ProcessarPagamentoAsync(RequestPagamento request);
    }
}
