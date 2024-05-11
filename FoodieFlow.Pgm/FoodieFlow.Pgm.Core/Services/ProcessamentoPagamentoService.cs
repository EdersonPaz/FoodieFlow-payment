using FoodieFlow.Pgm.Core.Entities;
using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace FoodieFlow.Pgm.Core.Services
{
    public class ProcessamentoPagamentoService : IProcessamentoPagamentoService
    {
        private readonly IAwsService _awsService;
        private readonly ILogger<ProcessamentoPagamentoService> _logger;

        public ProcessamentoPagamentoService(IAwsService awsService, ILogger<ProcessamentoPagamentoService> logger)
        {
            _awsService = awsService;
            _logger = logger;
        }

        public async Task<Pagamento> ProcessarPagamentoAsync(RequestPagamento request)
        {
            // Crie os dados do pagamento
            var pagamento = new Pagamento
            {
                TransactionAmount = request.PedidoCompleto.Sum(p => p.Preco),
                Description = string.Join(", ", request.PedidoCompleto.Select(p => p.Nome)),
                PaymentMethodId = request.MetodoPagamento,
                PayerName = request.Cliente.Nome,
                PayerEmail = request.Cliente.Email
            };

            // Validação
            var erros = ValidarPagamento(pagamento);
            if (erros.Any())
            {
                throw new Exception(string.Join(" | ", erros));
            }

            // Converte o pagamento em JSON
            string pagamentoJson = JsonConvert.SerializeObject(pagamento);

            // Envia o pagamento para a fila SQS
            await _awsService.EnviarMensagemAsync("url-da-sua-fila", pagamentoJson);

            //Salva o pagamento no S3
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(pagamentoJson)))
            {
                await _awsService.EscreverArquivoS3Async(stream, "nome-do-seu-bucket", "pasta", $"pagamento_{pagamento.Id}.json", "application/json");
            }

            _logger.LogInformation($"Pagamento {pagamento.Id} processado com sucesso.");
            return pagamento;
        }

        private List<string> ValidarPagamento(Pagamento pagamento)
        {
            var erros = new List<string>();

            if (pagamento.TransactionAmount == 0)
            {
                erros.Add("O valor do pagamento não pode ser 0.");
            }

            if (!System.Enum.IsDefined(typeof(EnumMetodoPagamento), pagamento.PaymentMethodId))
            {
                erros.Add("O método de pagamento é inválido.");
            }

            return erros;
        }

    }
}

