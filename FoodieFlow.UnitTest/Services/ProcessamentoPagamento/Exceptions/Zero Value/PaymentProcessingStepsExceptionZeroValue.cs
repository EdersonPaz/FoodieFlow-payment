using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Entities;
using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using FoodieFlow.Pgm.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace FoodieFlow.UnitTest.Services.ProcessamentoPagamento.Exceptions.Zero_Value
{
    [Binding]
    public class PaymentProcessingStepsExceptionZeroValue
    {
        private RequestPagamento pedido;
        private ProcessamentoPagamentoService service;
        private Exception exception;
        private Mock<IAwsService> mockAwsService;
        private Mock<ILogger<ProcessamentoPagamentoService>> mockLogger;

        [Given(@"I have a payment request with zero payment")]
        public void GivenIHaveAPaymentRequestWithZeroPayment()
        {
            // Inicialize o pedido de pagamento com valor zero aqui
            pedido =  new RequestPagamento
            {
                Id = 1,
                Cliente = new Cliente
                {
                    Id = 1,
                    Cpf = "123.456.789-00",
                    Nome = "Cliente Teste",
                    Email = "cliente@teste.com"
                },
                PedidoCompleto = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Pedido Teste",
                Descricao = "Descrição do Pedido Teste",
                Imagens = new List<string> { "imagem1.jpg", "imagem2.jpg" },
                Ingredientes = new List<int> { 1, 2, 3 },
                Preco = 0, // Preço é 0
                IdCategoria = EnumCategoria.comida
            }
        },
                Status = EnumStatus.a_pagar,
                MetodoPagamento = EnumMetodoPagamento.pix
            };
        }

        [When(@"I call the payment request with zero payment")]
        public async Task WhenICallThePaymentRequest()
        {
            // Inicialize o serviço e chame o método aqui
            mockAwsService = new Mock<IAwsService>();
            mockLogger = new Mock<ILogger<ProcessamentoPagamentoService>>();
            service = new ProcessamentoPagamentoService(mockAwsService.Object, mockLogger.Object);
            try
            {
                var pagamento = await service.ProcessarPagamentoAsync(pedido);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [Then(@"an exception should be thrown with the message ""(.*)""")]
        public void ThenAnExceptionShouldBeThrownWithTheMessage(string expectedMessage)
        {
            // Verifique se uma exceção foi lançada e se a mensagem é a esperada
            Assert.NotNull(exception);
            Assert.Contains(expectedMessage, exception.Message);
        }
    }

}
