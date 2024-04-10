using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_BLOB_TRIGGERS")]
    public class QrtzBlobTrigger
    {
        [Key, Column("SCHED_NAME", Order = 1), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("TRIGGER_NAME", Order = 2), MaxLength(150)]
        public string TriggerName { get; set; }

        [Key, Column("TRIGGER_GROUP", Order = 3), MaxLength(150)]
        public string TriggerGroup { get; set; }

        [Column("BLOB_DATA")]
        public byte[] BlobData { get; set; }

        // Navegação para Trigger
        public virtual QrtzTrigger Trigger { get; set; }
    }
}