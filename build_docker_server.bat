dotnet restore
dotnet build
cd avianoise.Web
dotnet publish -c Release -o .build/out
docker build -t avianoise_web .
docker run -p 5555:80 --name avia_server avianoise_web
