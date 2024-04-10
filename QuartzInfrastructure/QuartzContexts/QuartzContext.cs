using Microsoft.EntityFrameworkCore;
using QuartzInfrastructure.MapEntities;

namespace QuartzInfrastructure.QuartzContexts
{
    public class QuartzContext : DbContext
    {
        public QuartzContext(DbContextOptions<QuartzContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapQrtzJobDetails();
            //modelBuilder.MapQrtzTriggers();
            //modelBuilder.MapQrtzCronTriggers();
            //modelBuilder.MapQrtzSimpleTriggers();
            //modelBuilder.MapQrtzSimpropTriggers();
            //modelBuilder.MapQrtzFiredTriggers();
            //modelBuilder.MapQrtzPausedTriggerGrps();
            //modelBuilder.MapQrtzSchedulerState();
            //modelBuilder.MapQrtzLocks();
        }
    }
}