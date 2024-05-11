using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Entities;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using FoodieFlow.Pgm.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace FoodieFlow.UnitTest.Services.ProcessamentoPagamento.Exceptions
{
    [Binding]

    public class PaymentProcessingStepsExceptionNoItem
    {
        private RequestPagamento pedido;
        private ProcessamentoPagamentoService service;
        private Pagamento pagamento;
        private Exception exception;
        private Mock<IAwsService> mockAwsService;
        private Mock<ILogger<ProcessamentoPagamentoService>> mockLogger;

        [Given(@"I have a payment request with no items")]
        public void GivenIHaveAPaymentRequestWithNoItems()
        {
            // Inicialize o pedido de pagamento sem itens aqui
            pedido = new RequestPagamento
            {
                Id = 1,
                Cliente = new Cliente
                {
                    Id = 1,
                    Cpf = "123.456.789-00",
                    Nome = "Cliente Teste",
                    Email = "cliente@teste.com"
                },
                PedidoCompleto = null, // PedidoCompleto é nulo
                Status = 0,
                MetodoPagamento = 0
            };
        }

        [When(@"I call the payment request error")]
        public async Task WhenICallThePaymentRequest()
        {
            // Inicialize o serviço e chame o método aqui
            mockAwsService = new Mock<IAwsService>();
            mockLogger = new Mock<ILogger<ProcessamentoPagamentoService>>();
            service = new ProcessamentoPagamentoService(mockAwsService.Object, mockLogger.Object);
            try
            {
                pagamento = await service.ProcessarPagamentoAsync(pedido);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [Then(@"an exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            // Verifique se uma exceção foi lançada
            Assert.NotNull(exception);
        }
    }
}


