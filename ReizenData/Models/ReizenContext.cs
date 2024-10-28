﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReizenData.Models;

public partial class ReizenContext : DbContext
{
    public ReizenContext()
    {
    }

    public ReizenContext(DbContextOptions<ReizenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bestemming> Bestemmingen { get; set; }

    public virtual DbSet<Boeking> Boekingen { get; set; }

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<Land> Landen { get; set; }

    public virtual DbSet<Reis> Reizen { get; set; }

    public virtual DbSet<Wereldeel> Werelddelen { get; set; }

    public virtual DbSet<Woonplaats> Woonplaatsen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress2022;Database=reizen;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bestemming>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__bestemmi__357D4CF830A0559C");

            entity.ToTable("bestemmingen");

            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Landid).HasColumnName("landid");
            entity.Property(e => e.Plaats)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("plaats");

            entity.HasOne(d => d.Land).WithMany(p => p.Bestemmingen)
                .HasForeignKey(d => d.Landid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bestemmingen_landen");
        });

        modelBuilder.Entity<Boeking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__boekinge__3213E83FD0723469");

            entity.ToTable("boekingen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AantalKinderen).HasColumnName("aantalKinderen");
            entity.Property(e => e.AantalVolwassenen).HasColumnName("aantalVolwassenen");
            entity.Property(e => e.AnnulatieVerzekering).HasColumnName("annulatieVerzekering");
            entity.Property(e => e.GeboektOp).HasColumnName("geboektOp");
            entity.Property(e => e.Klantid).HasColumnName("klantid");
            entity.Property(e => e.Reisid).HasColumnName("reisid");

            entity.HasOne(d => d.Klant).WithMany(p => p.Boekingen)
                .HasForeignKey(d => d.Klantid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boekingen_klanten");

            entity.HasOne(d => d.Reis).WithMany(p => p.Boekingen)
                .HasForeignKey(d => d.Reisid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boekingen_reizen");
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__klanten__3213E83FD6FCCC26");

            entity.ToTable("klanten");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adres");
            entity.Property(e => e.Familienaam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("familienaam");
            entity.Property(e => e.Voornaam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("voornaam");
            entity.Property(e => e.Woonplaatsid).HasColumnName("woonplaatsid");

            entity.HasOne(d => d.Woonplaats).WithMany(p => p.Klanten)
                .HasForeignKey(d => d.Woonplaatsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("klanten_woonplaatsen");
        });

        modelBuilder.Entity<Land>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__landen__3213E83F6046B88D");

            entity.ToTable("landen");

            entity.HasIndex(e => e.Naam, "UQ__landen__72E1CD78D0AC258D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("naam");
            entity.Property(e => e.Werelddeelid).HasColumnName("werelddeelid");

            entity.HasOne(d => d.Werelddeel).WithMany(p => p.Landen)
                .HasForeignKey(d => d.Werelddeelid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("landen_werelddelen");
        });

        modelBuilder.Entity<Reis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reizen__3213E83FA3AC8331");

            entity.ToTable("reizen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AantalDagen).HasColumnName("aantalDagen");
            entity.Property(e => e.AantalKinderen).HasColumnName("aantalKinderen");
            entity.Property(e => e.AantalVolwassenen).HasColumnName("aantalVolwassenen");
            entity.Property(e => e.Bestemmingscode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bestemmingscode");
            entity.Property(e => e.PrijsPerPersoon)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prijsPerPersoon");
            entity.Property(e => e.Vertrek).HasColumnName("vertrek");

            entity.HasOne(d => d.BestemmingscodeNavigation).WithMany(p => p.Reizen)
                .HasForeignKey(d => d.Bestemmingscode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reizen_bestemmingen");
        });

        modelBuilder.Entity<Wereldeel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__wereldde__3213E83FCF2E583A");

            entity.ToTable("werelddelen");

            entity.HasIndex(e => e.Naam, "UQ__wereldde__72E1CD78243DF357").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("naam");
        });

        modelBuilder.Entity<Woonplaats>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__woonplaa__3213E83F0CF2B3D2");

            entity.ToTable("woonplaatsen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("naam");
            entity.Property(e => e.Postcode).HasColumnName("postcode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
