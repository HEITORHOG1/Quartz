using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_CRON_TRIGGERS")]
    public class QrtzCronTrigger
    {
        [Key]
        [Column("SCHED_NAME"), MaxLength(120)]
        public string SchedName { get; set; }

        [Key]
        [Column("TRIGGER_NAME"), MaxLength(150)]
        public string TriggerName { get; set; }

        [Key]
        [Column("TRIGGER_GROUP"), MaxLength(150)]
        public string TriggerGroup { get; set; }

        [Column("CRON_EXPRESSION"), MaxLength(120)]
        public string CronExpression { get; set; }

        [Column("TIME_ZONE_ID"), MaxLength(80)]
        public string TimeZoneId { get; set; }

        // Navegação para QrtzTrigger
        [ForeignKey("SchedName, TriggerName, TriggerGroup")]
        public QrtzTrigger Trigger { get; set; }
    }
}