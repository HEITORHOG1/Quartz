using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_SCHEDULER_STATE")]
    public class QrtzSchedulerState
    {
        [Key, Column("SCHED_NAME", Order = 1), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("INSTANCE_NAME", Order = 2), MaxLength(200)]
        public string InstanceName { get; set; }

        [Column("LAST_CHECKIN_TIME")]
        public long LastCheckinTime { get; set; }

        [Column("CHECKIN_INTERVAL")]
        public long CheckinInterval { get; set; }
    }
}