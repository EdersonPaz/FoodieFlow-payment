using FoodieFlow.Pgm.Core.Entities;
using FoodieFlow.Pgm.Core.Entities.Request;
using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using FoodieFlow.Pgm.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace FoodieFlow.UnitTest.Services.ProcessamentoPagamento.sucess
{
    [Binding]
    public class ProcessamentoPagamentoSteps
    {
        private RequestPagamento pedido;
        private ProcessamentoPagamentoService service;
        private Pagamento pagamento;
        private Exception exception;
        private Mock<IAwsService> mockAwsService;
        private Mock<ILogger<ProcessamentoPagamentoService>> mockLogger;

        [Given(@"I have a valid payment request")]
        public void GivenIHaveAValidPaymentRequest()
        {
            // Inicialize o pedido de pagamento aqui
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
                PedidoCompleto = new List<Produto>
                {
                    new Produto
                    {
                        Id = 1,
                        Nome = "Pedido Teste",
                        Descricao = "Descrição do Pedido Teste",
                        Imagens = new List<string> { "imagem1.jpg", "imagem2.jpg" },
                        Ingredientes = new List<int> { 1, 2, 3 },
                        Preco = 50,
                        IdCategoria = EnumCategoria.comida
                    }
                },
                Status = EnumStatus.a_pagar,
                MetodoPagamento = EnumMetodoPagamento.pix
            };
        }

        [When(@"I call the payment request")]
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

        [Then(@"the payment should be processed correctly")]
        public void ThenThePaymentShouldBeProcessedCorrectly()
        {
            // Verifique se o pagamento foi processado corretamente
            Assert.NotNull(pagamento);
            // Continue com as outras verificações
        }

        [Then(@"the message should be sent correctly")]
        public void ThenTheMessageShouldBeSentCorrectly()
        {
            // Verifique se a mensagem foi enviada corretamente
            mockAwsService.Verify(s => s.EnviarMensagemAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Then(@"the file should be written correctly to S3")]
        public void ThenTheFileShouldBeWrittenCorrectlyToS3()
        {
            // Verifique se o arquivo foi escrito corretamente no S3
            mockAwsService.Verify(s => s.EscreverArquivoS3Async(It.IsAny<MemoryStream>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }



    }

}
