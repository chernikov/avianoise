dotnet restore
dotnet build
cd avianoise.Web
dotnet publish -c Release -o .build/out
docker build -t chernikov/avianoise.web .
docker push chernikov/avianoise.web
