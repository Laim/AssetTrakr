# AssetTrakr
**AssetTrakr** is a License, Contract and Asset Tracker for home use built using [EF Core](https://github.com/dotnet/efcore) and [.NET 8](https://github.com/dotnet/core).

# Usage
Download the latest release and run **AssetTrakr.App.Setup** to create the database, then run **AssetTrakr.App**. 

## Updating
Download the latest release and run **AssetTrakr.App.Setup**.  This will run the latest migrations against your database, if you do not run the Migrations **AssetTrakr** will force close until they are run.

# Build from Source
**Please note that building from source may prevent you from using the official releases and I cannot guarantee that migrations from official releases will work**

* Open Visual Studio 2022
* Open Terminal
* Run the following:

`dotnet build AssetTrakr.sln -c Release /property:Version=1.0.0`

Change 1.0.0 to what you want the version to be.  To just build as version one, omit the `/property:Version` section.
