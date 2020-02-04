dotnet restore 
dotnet build
dotnet ef database update -p avianoise.Web 
start /d "." dotnet run --project ./avianoise.Web/avianoise.Web.csproj --launch-profile  avianoise.Web