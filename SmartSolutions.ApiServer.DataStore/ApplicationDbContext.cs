using Microsoft.EntityFrameworkCore;
using SmartSolutions.ApiServer.DataStore.Entites;

namespace SmartSolutions.ApiServer.DataStore
{
    /// <summary>
    /// Database Representational Model for Application
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region [Constructor]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion

        #region [Properties]
        public DbSet<BussinessType> BussinessTypes { get; set; }
        public DbSet<CompanyInfo> CompaniesInfo { get; set; }
        public DbSet<ProprietorInfo> BusinessInfo { get; set; }
        #endregion

        #region [Methods]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyInfo>().ToTable("CompanyInfo");
            modelBuilder.Entity<BussinessType>().ToTable("BussinessType");
            modelBuilder.Entity<ProprietorInfo>().ToTable("ProprietorInfo");
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.EmergenceyNumber).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.LandLineNumber1).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.HomeAddress).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.Description).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.EmergenceyNumber).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.CreatedBy).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.UpdatedAt).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.UpdatedBy).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.Name).IsRequired(false);
            modelBuilder.Entity<ProprietorInfo>().Property(x => x.Version).IsRequired(false);
        }
        #endregion
    }
}
