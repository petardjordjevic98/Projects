using Microsoft.EntityFrameworkCore;
using ProbCut.Models;

public class SalonContext : DbContext
    {
        public SalonContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Frizer> Frizeri { get; set; }
        public virtual DbSet<Komentar> Komentari { get; set; }
        public virtual DbSet<Musterija> Musterije { get; set; }
        public virtual DbSet<Termin> Termini { get; set; }
        public virtual DbSet<Vlasnik> Vlasnici { get; set; }
        public virtual DbSet<Poruka> Poruke { get; set; }
    }


