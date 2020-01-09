dotnet restore 
dotnet build
dotnet ef database update -p avianoise.Web 
dotnet run --project ./avianoise.Web/avianoise.Web.csproj --launch-profile  avianoise.Web