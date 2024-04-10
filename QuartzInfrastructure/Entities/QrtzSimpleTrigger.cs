using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_SIMPLE_TRIGGERS")]
    public class QrtzSimpleTrigger
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

        [Column("REPEAT_COUNT")]
        public int RepeatCount { get; set; }

        [Column("REPEAT_INTERVAL")]
        public long RepeatInterval { get; set; }

        [Column("TIMES_TRIGGERED")]
        public int TimesTriggered { get; set; }

        // Navegação para QrtzTrigger
        [ForeignKey("SchedName, TriggerName, TriggerGroup")]
        public QrtzTrigger Trigger { get; set; }
    }
}