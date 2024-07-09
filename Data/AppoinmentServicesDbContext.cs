using System;
using System.Collections.Generic;
using AppoinmentServices.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppoinmentServices.Data;

public partial class AppoinmentServicesDbContext : DbContext
{
    public AppoinmentServicesDbContext()
    {
    }

    public AppoinmentServicesDbContext(DbContextOptions<AppoinmentServicesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SlotMaster> SlotMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=AppoinmentServicesDb;Username=postgres;Password=subha@1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>(entity =>
        {
            entity.Property(e => e.AvailabilityPerSlot).HasDefaultValue(5);
            entity.Property(e => e.SlotPeriod).HasDefaultValue(30);
        });

        modelBuilder.Entity<SlotMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("slot_master_pkey");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
