using AssetTrakr.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetTrakr.Database
{
    public class DatabaseContext : DbContext
    {
        // All Models must be referenced here
        public DbSet<Models.License> Licenses { get; set; }
        public DbSet<Models.Contract> Contracts { get; set; }
        public DbSet<Models.Attachment> Attachments { get; set; }
        public DbSet<Models.Manufacturer> Manufacturers { get; set; }
        public DbSet<Models.Period> Periods { get; set; }
        public DbSet<Models.Platform> Platforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move database location
            // TODO: Encrypt database w/ Password
            optionsBuilder.UseSqlite($@"Data Source=AssetTrakr.db"); //{Environment.SpecialFolder.CommonApplicationData}\AssetTrakr\
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Converts the enum int value to the string value, so instead of saving into the database as
            // type = 1, it'll save as type = File
            // Source: https://jonathancrozier.com/blog/store-and-retrieve-enums-as-strings-with-entity-framework-core
            modelBuilder.Entity<Models.Attachment>()
                .Property(a => a.Type)
                .HasConversion(new EnumToStringConverter<AttachmentType>());

            // make fields unique, cant do this via the model for some reason?
            // TODO: Review https://stackoverflow.com/a/67075842/12954031
            modelBuilder.Entity<Models.Manufacturer>()
                .HasIndex(m => m.Name).IsUnique();

            modelBuilder.Entity<Models.Platform>()
                .HasIndex(p => p.Name).IsUnique();

            // Configure relationships using Fluent API
            #region License
            modelBuilder.Entity<Models.License>()
                .HasOne(l => l.Contract)
                .WithMany()
                .HasForeignKey(l => l.ContractId);

            modelBuilder.Entity<Models.License>()
                .HasOne(l => l.Manufacturer)
                .WithMany()
                .HasForeignKey(l => l.ManufacturerId);

            modelBuilder.Entity<Models.License>()
                .HasOne(l => l.Platform)
                .WithMany()
                .HasForeignKey(l => l.PlatformId);
            #endregion

            #region Platform
            modelBuilder.Entity<Models.Platform>()
                .HasOne(l => l.Manufacturer)
                .WithMany()
                .HasForeignKey(l => l.ManufacturerId);
            #endregion
#if DEBUG
            AddSampleData(modelBuilder);
#endif
        }

        // Source: https://threewill.com/how-to-auto-generate-created-updated-field-in-ef-core/

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


        #region Sample Data [Debug Only]
        private void AddSampleData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Manufacturer>().HasData(
                new Models.Manufacturer
                {
                    ManufacturerId = 1,
                    Name = "Microsoft Corporation",
                    Url = "https://microsoft.com",
                    SupportEmail = "",
                    SupportPhone = "",
                    SupportUrl = "https://support.microsoft.com/en-us/home/"
                }
            );

            modelBuilder.Entity<Models.Platform>().HasData(
                new Models.Platform
                {
                    PlatformId = 1,
                    Name = "Windows", 
                    ManufacturerId = 1,
                }
            );

            modelBuilder.Entity<Models.Contract>().HasData(
                new Models.Contract
                {
                    ContractId = 1,
                    Name = "SBMPSA 2023",
                    OrderRef = "",
                    SubscriptionIds = [],
                }
            );

            modelBuilder.Entity<Models.License>().HasData(
                new Models.License
                {
                    Id = 1,
                    Name = "Example",
                    Count = 1,
                    Description = "Example License",
                    IsSubscription = false,
                    PurchaseDate = DateOnly.FromDateTime(DateTime.Today),
                    ManufacturerId = 1,
                    PlatformId = 1,
                    ContractId = 1,
                    Price = 0
                }
            );
        }

        #endregion
    }
}
