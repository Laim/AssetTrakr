using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetTrakr.Database
{
    public class DatabaseContext : DbContext
    {
        // All Models must be referenced here
        public DbSet<License> Licenses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<LicensePeriod> LicensePeriods { get; set; }
        public DbSet<LicenseAttachment> LicenseAttachments { get; set; }
        public DbSet<ContractPeriod> ContractPeriods { get; set; }
        public DbSet<ContractAttachment> ContractAttachments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetAttachment> AssetAttachments { get; set; }
        public DbSet<AssetHardDrive> AssetHardDrives { get; set; }
        public DbSet<AssetHardware> AssetHardware { get; set; }
        public DbSet<AssetNetworkAdapter> AssetNetworkAdapters { get; set; }
        public DbSet<AssetOperatingSystem> AssetOperatingSystems { get; set; }
        public DbSet<AssetPeriod> AssetPeriods { get; set; }
        public DbSet<ActionLog> ActionLogEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move database location
            // TODO: Encrypt database w/ Password
            optionsBuilder.UseSqlite($@"Data Source=AssetTrakr.db"); //{Environment.SpecialFolder.CommonApplicationData}\AssetTrakr\
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Converts the enum int value to the string value, so instead of saving into the database as
            // type = 1, it'll save as type = File
            // Source: https://jonathancrozier.com/blog/store-and-retrieve-enums-as-strings-with-entity-framework-core
            modelBuilder.Entity<Attachment>()
                .Property(a => a.Type)
                .HasConversion(new EnumToStringConverter<AttachmentType>());

            modelBuilder.Entity<Manufacturer>()
                .HasIndex(m => m.Name).IsUnique();

            modelBuilder.Entity<Asset>()
                .HasIndex("OperatingSystemId")
                .IsUnique(false);

            modelBuilder.Entity<Platform>(e =>
            {
                e.HasIndex(p => p.Name)
                    .IsUnique();

                e.HasOne(p => p.Manufacturer)
                    .WithMany()
                    .HasForeignKey(p => p.ManufacturerId);
            });

            modelBuilder.Entity<License>(e =>
            {
                e.HasOne(l => l.Contract)
                    .WithMany()
                    .HasForeignKey(l => l.ContractId);

                e.HasOne(l => l.Manufacturer)
                    .WithMany()
                    .HasForeignKey(l => l.ManufacturerId);

                e.HasOne(l => l.Platform)
                    .WithMany()
                    .HasForeignKey(l => l.PlatformId);
            });

            modelBuilder.Entity<LicensePeriod>(e =>
            {
                e.HasKey(pj => new { pj.LicenseId, pj.PeriodId });

                e.HasOne(pj => pj.License)
                    .WithMany(l => l.LicensePeriods)
                    .HasForeignKey(l => l.LicenseId);

                e.HasOne(lp => lp.Period)
                    .WithMany(p => p.LicensePeriods)
                    .HasForeignKey(l => l.PeriodId);
            });

            modelBuilder.Entity<LicenseAttachment>(e =>
            {
                e.HasKey(la => new { la.LicenseId, la.AttachmentId });

                e.HasOne(la => la.License)
                    .WithMany(l => l.LicenseAttachments)
                    .HasForeignKey(la => la.LicenseId);

                e.HasOne(la => la.Attachment)
                    .WithMany(a => a.LicenseAttachments)
                    .HasForeignKey(la => la.AttachmentId);
            });

            modelBuilder.Entity<ContractPeriod>(e =>
            {
                e.HasKey(pj => new { pj.ContractId, pj.PeriodId });

                e.HasOne(pj => pj.Contract)
                    .WithMany(l => l.ContractPeriods)
                    .HasForeignKey(l => l.ContractId);

                e.HasOne(lp => lp.Period)
                    .WithMany(p => p.ContractPeriods)
                    .HasForeignKey(l => l.PeriodId);

                e.HasOne(lp => lp.Period)
                    .WithMany(p => p.ContractPeriods)
                    .HasForeignKey(l => l.PeriodId);
            });

            modelBuilder.Entity<ContractAttachment>(e =>
            {
                e.HasKey(la => new { la.ContractId, la.AttachmentId });

                e.HasOne(la => la.Contract)
                    .WithMany(l => l.ContractAttachments)
                    .HasForeignKey(la => la.ContractId);

                e.HasOne(la => la.Attachment)
                    .WithMany(a => a.ContractAttachments)
                    .HasForeignKey(la => la.AttachmentId);
            });

            modelBuilder.Entity<AssetPeriod>(e =>
            {
                e.HasKey(pj => new { pj.AssetId, pj.PeriodId });

                e.HasOne(pj => pj.Asset)
                    .WithMany(l => l.AssetPeriods)
                    .HasForeignKey(l => l.AssetId);

                e.HasOne(lp => lp.Period)
                    .WithMany(p => p.AssetPeriods)
                    .HasForeignKey(l => l.PeriodId);

                e.HasOne(lp => lp.Period)
                    .WithMany(p => p.AssetPeriods)
                    .HasForeignKey(l => l.PeriodId);
            });

            modelBuilder.Entity<AssetAttachment>(e =>
            {
                e.HasKey(la => new { la.AssetId, la.AttachmentId });

                e.HasOne(la => la.Asset)
                    .WithMany(l => l.AssetAttachments)
                    .HasForeignKey(aa => aa.AssetId);

                e.HasOne(la => la.Attachment)
                    .WithMany(a => a.AssetAttachments)
                    .HasForeignKey(la => la.AttachmentId);
            });

            modelBuilder.Entity<AssetNetworkAdapter>(e =>
            {
                e.HasOne(na => na.AssetHardware)
                    .WithMany(ah => ah.NetworkAdapters)
                    .HasForeignKey(na => na.AssetHardwareId);
            });

            modelBuilder.Entity<AssetHardDrive>(e =>
            {
                e.HasOne(hd => hd.AssetHardware)
                    .WithMany(ah => ah.HardDrives)
                    .HasForeignKey(hd  => hd.AssetHardwareId);
            });

#if DEBUG
            DatabaseSeeder ds = new(modelBuilder);
            ds.Seed();
#endif

        }

        // Below Source: https://threewill.com/how-to-auto-generate-created-updated-field-in-ef-core/

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is Models.Base trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedDate = utcNow;
                            trackable.UpdatedBy = $"{Environment.UserName}";

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedDate").IsModified = false;
                            entry.Property("CreatedBy").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedDate = utcNow;
                            trackable.UpdatedDate = utcNow;
                            trackable.CreatedBy = $"{Environment.UserName}";
                            trackable.UpdatedBy = $"{Environment.UserName}";
                            break;
                    }
                }
            }
        }
    }
}
