using System;
using System.Collections.Generic;
using DatabaseCompiledModels.MyCompiledModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DatabaseCompiledModels.Models;

public partial class CompiledModelsIssueContext : DbContext
{
    public CompiledModelsIssueContext()
    {
    }

    public CompiledModelsIssueContext(DbContextOptions<CompiledModelsIssueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestV> TestVs { get; set; }

    public virtual DbSet<TestValue> TestValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //UnComment This line to use Compiled Models
        //optionsBuilder.UseModel(CompiledModelsIssueContextModel.Instance);

        optionsBuilder.UseSqlServer("Server=;Database=CompiledModelsIssue;User Id=;Password=;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestV>(entity =>
        {
            entity.ToTable("TestV");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TestValues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.TestValue).WithMany(p => p.TestVs)
                .HasForeignKey(d => d.TestValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestV_TestValues");
        });

        modelBuilder.Entity<TestValue>(entity =>
        {
            entity.Property(e => e.TestValue1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TestValue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
