using AssetTrakr.Logging;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.Database
{
    public class TestDatabaseSeeder(ModelBuilder modelBuilder)
    {
        public ModelBuilder Seed()
        {

            LogManager.Debug<TestDatabaseSeeder>($"[{nameof(TestDatabaseSeeder)}] is active...");

            modelBuilder.Entity<Manufacturer>().HasData(GetManufacturers());
            modelBuilder.Entity<Platform>().HasData(GetPlatforms());
            modelBuilder.Entity<AssetOperatingSystem>().HasData(GetAssetOperatingSystems());

            return modelBuilder;
        }

        /// <summary>
        /// List of Manufacturers and their URL.  To add new data, just add a new row.
        /// </summary>
        /// <returns>
        /// List of DEMO Manufacturers based on <see cref="List{Manufacturer}"/>
        /// </returns>
        internal static List<Manufacturer> GetManufacturers()
        {
            List<Tuple<string, string>> list =
            [
                new Tuple<string, string>("Microsoft", "https://microsoft.com"),
                new Tuple<string, string>("Adobe, Inc", "https://adobe.com"),
                new Tuple<string, string>("1Password", "https://1password.com"),
                new Tuple<string, string>("Valve", "https://valvesoftware.com"),
                new Tuple<string, string>("Apple", "https://apple.com"),
                new Tuple<string, string>("Citrix", "https://www.citrix.com/"),
                new Tuple<string, string>("Splunk", "https://www.splunk.com/"),
                new Tuple<string, string>("Amazon", "https://amazon.com/"),
                new Tuple<string, string>("Google", "https://google.com/"),
                new Tuple<string, string>("Linux Foundation", "https://linuxfoundation.org/"),
            ];

            List<Manufacturer> manufacturers = [];
            int id = 1;

            foreach(var tuple in list)
            {
                var manufacturer = new Manufacturer
                {
                    ManufacturerId = id,
                    Name = tuple.Item1,
                    Url = tuple.Item2
                };

                manufacturers.Add(manufacturer);
                id++;
            }

            return manufacturers;
        }

        /// <summary>
        /// List of Platforms and their Manufacturer.  To add new data, just add a new row.
        /// NOTE: Ensure that the Manufacturer ID exists in <see cref="GetManufacturers()"/>
        /// </summary>
        /// <returns>
        /// List of DEMO Manufacturers based on <see cref="List{Platform}"/>
        /// </returns>
        internal static List<Platform> GetPlatforms()
        {
            List<Tuple<string, int>> list =
            [
                new Tuple<string, int>("Windows", 1), // int value taken from GetManufacturers
                new Tuple<string, int>("macOS", 5),
                new Tuple<string, int>("Linux", 10),
                new Tuple<string, int>("Chrome OS", 9),
                new Tuple<string, int>("iOS", 5),
                new Tuple<string, int>("Android", 9),
            ];

            List<Platform> platforms = [];
            int id = 1;

            foreach (var tuple in list)
            {
                var platform = new Platform
                {
                    PlatformId = id,
                    Name = tuple.Item1,
                    ManufacturerId = tuple.Item2
                };

                platforms.Add(platform);
                id++;
            }

            return platforms;
        }

        internal static List<AssetOperatingSystem> GetAssetOperatingSystems()
        {
            List<Tuple<string, int, int>> list =
            [
                new Tuple<string, int, int>("Windows 11", 1, 1)
            ];

            List<AssetOperatingSystem> operatingSystems = [];
            int id = 1;

            foreach(var tuple in list)
            {
                var os = new AssetOperatingSystem
                {
                    OperatingSystemId = id,
                    Name = tuple.Item1,
                    ManufacturerId = tuple.Item2
                };

                operatingSystems.Add(os);
                id++;
            }

            return operatingSystems;
        }
    }
}
