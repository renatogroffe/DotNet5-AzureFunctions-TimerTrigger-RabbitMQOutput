using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppRabbitMQOutput
{
    public static class GeracaoEventos
    {
        private const string QUEUE_NAME = "queue-testes";
        
        [Function("GeracaoEventos")]
        [RabbitMQOutput(QueueName = QUEUE_NAME, ConnectionStringSetting = "RabbitMQConnection")]
        public static string Run([TimerTrigger("*/5 * * * * *")] FunctionContext context)
        {
            var logger = context.GetLogger("GeracaoEventos");
            string mensagem = $"Evento gerado em {DateTime.Now:HH:mm:ss}";
            logger.LogInformation(mensagem);

            return mensagem;
        }
    }
}