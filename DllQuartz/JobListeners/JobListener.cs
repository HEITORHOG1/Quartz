using Microsoft.Extensions.Logging;
using Quartz;

namespace DllQuartz.JobListeners
{
    public class JobListener : IJobListener
    {
        private readonly ILogger _logger;

        public JobListener(ILogger logger)
        {
            _logger = logger;
        }

        public string Name => "JobListener";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            _logger.LogWarning($"Execução do job {context.JobDetail.Key.Name} foi vetada.");
            return Task.CompletedTask;
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Execução do job {context.JobDetail.Key.Name} está prestes a acontecer.");
            return Task.CompletedTask;
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            if (jobException != null)
            {
                _logger.LogError(jobException, $"Erro ao executar o job {context.JobDetail.Key.Name}.");
            }
            else
            {
                _logger.LogInformation($"Execução do job {context.JobDetail.Key.Name} foi concluída com sucesso.");
            }
            // Supondo que você tenha acesso ao fuso horário de Brasília aqui.
            var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            var nextFireTimeUtc = context.Trigger.GetNextFireTimeUtc();

            if (nextFireTimeUtc.HasValue)
            {
                var nextExecutionTime = TimeZoneInfo.ConvertTimeFromUtc(nextFireTimeUtc.Value.DateTime, brasiliaTimeZone);
                Console.WriteLine($"Próxima execução do job {context.JobDetail.Key.Name}: {nextExecutionTime:dd/MM/yyyy HH:mm:ss}");
            }

            return Task.CompletedTask;
        }
    }
}