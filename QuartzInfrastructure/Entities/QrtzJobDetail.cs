using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_JOB_DETAILS")]
    public class QrtzJobDetail
    {
        public QrtzJobDetail()
        {
            Triggers = new HashSet<QrtzTrigger>();
        }

        [Key]
        [Column("SCHED_NAME"), MaxLength(120)]
        public string SchedName { get; set; }

        [Key]
        [Column("JOB_NAME"), MaxLength(150)]
        public string JobName { get; set; }

        [Key]
        [Column("JOB_GROUP"), MaxLength(150)]
        public string JobGroup { get; set; }

        [Column("DESCRIPTION"), MaxLength(250)]
        public string Description { get; set; }

        [Column("JOB_CLASS_NAME"), MaxLength(250)]
        public string JobClassName { get; set; }

        [Column("IS_DURABLE")]
        public bool IsDurable { get; set; }

        [Column("IS_NONCONCURRENT")]
        public bool IsNonConcurrent { get; set; }

        [Column("IS_UPDATE_DATA")]
        public bool IsUpdateData { get; set; }

        [Column("REQUESTS_RECOVERY")]
        public bool RequestsRecovery { get; set; }

        [Column("JOB_DATA")]
        public byte[] JobData { get; set; }

        // Navegação para Triggers
        public virtual ICollection<QrtzTrigger> Triggers { get; set; }
    }
}