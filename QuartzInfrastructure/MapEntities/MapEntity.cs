using Microsoft.EntityFrameworkCore;
using QuartzInfrastructure.Entities;

namespace QuartzInfrastructure.MapEntities
{
    public static class MapEntity
    {
        public static void MapQrtzJobDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QrtzJobDetail>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.JobName, e.JobGroup });
                //entity.ToTable("QRTZ_JOB_DETAILS");
            });

            modelBuilder.Entity<QrtzTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });
                // entity.ToTable("QRTZ_TRIGGERS");

                // Definições de propriedade
                entity.Property(e => e.SchedName).IsRequired().HasMaxLength(120);
                entity.Property(e => e.TriggerName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.TriggerGroup).IsRequired().HasMaxLength(150);
                // Continue o mapeamento para as outras propriedades

                // Relacionamento com QrtzJobDetail
                entity.HasOne(t => t.JobDetail)
                      .WithMany(j => j.Triggers)
                      .HasForeignKey(t => new { t.SchedName, t.JobName, t.JobGroup })
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QrtzCronTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });
                //entity.ToTable("QRTZ_CRON_TRIGGERS");

                entity.Property(e => e.SchedName).IsRequired().HasMaxLength(120);
                entity.Property(e => e.TriggerName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.TriggerGroup).IsRequired().HasMaxLength(150);
                entity.Property(e => e.CronExpression).IsRequired().HasMaxLength(120);
                entity.Property(e => e.TimeZoneId).HasMaxLength(80);

                // Relacionamento com QrtzTrigger
                entity.HasOne(e => e.Trigger)
                      .WithOne() // Assumindo que você definiu uma propriedade de navegação apropriada em QrtzTrigger
                      .HasForeignKey<QrtzCronTrigger>(e => new { e.SchedName, e.TriggerName, e.TriggerGroup })
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QrtzSimpleTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });
                //entity.ToTable("QRTZ_SIMPLE_TRIGGERS");

                entity.Property(e => e.SchedName).IsRequired().HasMaxLength(120);
                entity.Property(e => e.TriggerName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.TriggerGroup).IsRequired().HasMaxLength(150);
                entity.Property(e => e.RepeatCount).IsRequired();
                entity.Property(e => e.RepeatInterval).IsRequired();
                entity.Property(e => e.TimesTriggered).IsRequired();

                // Relacionamento com QrtzTrigger
                entity.HasOne(e => e.Trigger)
                      .WithOne() // Este é um placeholder; substitua com a propriedade de navegação correta.
                      .HasForeignKey<QrtzSimpleTrigger>(e => new { e.SchedName, e.TriggerName, e.TriggerGroup })
                      .OnDelete(DeleteBehavior.Cascade);
            });
            // Inclua os mapeamentos para outras entidades aqui
        }
    }
}