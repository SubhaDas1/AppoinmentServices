using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppoinmentServices.Entity;

[Table("slot_master", Schema = "Appoinment_schema")]
public partial class SlotMaster
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

    [Column("end_time")]
    public TimeOnly EndTime { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
