using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_PAUSED_TRIGGER_GRPS")]
    public class QrtzPausedTriggerGrps
    {
        [Key, Column("SCHED_NAME", Order = 1), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("TRIGGER_GROUP", Order = 2), MaxLength(150)]
        public string TriggerGroup { get; set; }
    }
}