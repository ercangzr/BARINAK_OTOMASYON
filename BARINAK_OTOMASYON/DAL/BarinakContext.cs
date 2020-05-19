using BARINAK_OTOMASYON.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BARINAK_OTOMASYON.DAL
{
    public class BarinakContext:DbContext
    {
        public BarinakContext() : base("cstr")
        {

        }


        public DbSet<Hayvan> Hayvanlar { get; set; }

        public DbSet<Sahip> Sahipler { get; set; }
        public DbSet<Login> Kullanicilar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().ToTable("tblKullanicilar");
            modelBuilder.Entity<Login>().Property(k=> k.Username).HasMaxLength(35).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Login>().Property(k => k.Password).HasMaxLength(50).HasColumnType("varchar").IsRequired();


            modelBuilder.Entity<Hayvan>().ToTable("tblHayvan");
            modelBuilder.Entity<Hayvan>().Property(h => h.HAYVAN_CINSI).HasMaxLength(35).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.HAYVAN_CINSIYETI).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.HAYVAN_YASI).HasMaxLength(50).HasColumnType("varchar").IsRequired();

            modelBuilder.Entity<Sahip>().ToTable("tblSahip");
            modelBuilder.Entity<Sahip>().Property(s => s.SAHIP_AD).HasMaxLength(35).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Sahip>().Property(s => s.SAHIP_SOYAD).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Sahip>().Property(s => s.SAHIP_TEL).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Sahip>().Property(s => s.SAHIP_ADRES).HasMaxLength(50).HasColumnType("varchar").IsRequired();
        }
    }
}
