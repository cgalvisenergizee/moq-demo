# .NET unit testing with Moq

## Make base project

```bash
# Make source folder
mkdir src && cd src
# make solution
dotnet new sln -n MoqDemo
# Make asp.net project
dotnet new webapi -n WebApi
# Make testing project with Nunit
dotnet new nunit -n Tests
# Add rpjects to solution
dotnet sln add WebApi/WebApi.csproj
dotnet sln add Tests/Tests.csproj
# Link test project to main project
dotnet add Tests/Tests.csproj reference WebApi/WebApi.csproj
# Restore NuGet packages
dotnet restore
# Delete default files
rm WebApi/WeatherForecast.cs WebApi/Controllers/WeatherForecastController.cs
```

## Add files

```bash
```