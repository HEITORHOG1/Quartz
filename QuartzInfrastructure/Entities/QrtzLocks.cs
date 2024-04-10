using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_LOCKS")]
    public class QrtzLocks
    {
        [Key, Column("SCHED_NAME", Order = 1), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("LOCK_NAME", Order = 2), MaxLength(40)]
        public string LockName { get; set; }
    }
}