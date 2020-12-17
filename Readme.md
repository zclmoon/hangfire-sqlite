This is a simple template project that set up Hangfire with SQLite storage.

# Technique Stack & Components
1. ASP.NET Core 5.x
2. Hangfire
3. Hangfire.RecurringJobExtensions
4. Hangfire.Storage.SQLite
5. NLog.Web.AspNetCore
6. Microsoft.Extensions.Hosting.WindowsServices

# Planned Items
- [x] Support Host Hangfire with Windows Service
- [ ] Add CSV File handler sample with CsvHelper
- [ ] Add a sample that make Http Request in Scheduling Job

# Future
- [ ] Support SQLServer and MySQL storage (configurable in AppSettings)


# Install as Windows Service

## Publish the build
```
dotnet publish -r win-x64 -c Release
```
## Install Windows Service by sc.exe
```
sc create your_service_name BinPath=the_exe_path\Hangfire-SQLite.exe
```
## Remove Windows Service
```
sc delete your_service_name
```

