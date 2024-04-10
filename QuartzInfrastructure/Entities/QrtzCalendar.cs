using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuartzInfrastructure.Entities
{
    [Table("QRTZ_CALENDARS")]
    public class QrtzCalendar
    {
        [Key, Column("SCHED_NAME", Order = 1), MaxLength(120)]
        public string SchedName { get; set; }

        [Key, Column("CALENDAR_NAME", Order = 2), MaxLength(200)]
        public string CalendarName { get; set; }

        [Column("CALENDAR"), Required]
        public byte[] Calendar { get; set; }
    }
}