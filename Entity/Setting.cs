using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppoinmentServices.Entity;

[Keyless]
[Table("settings", Schema = "Appoinment_schema")]
public partial class Setting
{
    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

    [Column("end_time")]
    public TimeOnly EndTime { get; set; }

    [Column("slot_period")]
    public int SlotPeriod { get; set; }

    [Column("availability_per_slot")]
    public int AvailabilityPerSlot { get; set; }
}
