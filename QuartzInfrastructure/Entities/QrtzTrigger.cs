using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_TRIGGERS")]
    public class QrtzTrigger
    {
        [Key, Column("SCHED_NAME"), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("TRIGGER_NAME"), MaxLength(150)]
        public string TriggerName { get; set; }

        [Key, Column("TRIGGER_GROUP"), MaxLength(150)]
        public string TriggerGroup { get; set; }

        [Column("JOB_NAME"), MaxLength(150)]
        public string JobName { get; set; }

        [Column("JOB_GROUP"), MaxLength(150)]
        public string JobGroup { get; set; }

        [Column("DESCRIPTION"), MaxLength(250)]
        public string Description { get; set; }

        [Column("NEXT_FIRE_TIME")]
        public long? NextFireTime { get; set; }

        [Column("PREV_FIRE_TIME")]
        public long? PrevFireTime { get; set; }

        [Column("PRIORITY")]
        public int? Priority { get; set; }

        [Column("TRIGGER_STATE"), MaxLength(16)]
        public string TriggerState { get; set; }

        [Column("TRIGGER_TYPE"), MaxLength(8)]
        public string TriggerType { get; set; }

        [Column("START_TIME")]
        public long StartTime { get; set; }

        [Column("END_TIME")]
        public long? EndTime { get; set; }

        [Column("CALENDAR_NAME"), MaxLength(200)]
        public string CalendarName { get; set; }

        [Column("MISFIRE_INSTR")]
        public int? MisfireInstr { get; set; }

        [Column("JOB_DATA")]
        public byte[] JobData { get; set; }

        // Navegação para JobDetail
        [ForeignKey("SchedName, JobName, JobGroup")]
        public QrtzJobDetail JobDetail { get; set; }
    }
}