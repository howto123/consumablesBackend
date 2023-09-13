# consumablesBackend

Entity Framework:
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli


set env
`$env:dbPath="C:\\Users\\Thinkpad53u\\Files\\Dev\\99 ProjectIdeas\\consumablesBackend\\database\\weather.db"`
create weather.db and set the absolute path in appsettings.json (and db context and in the test)


tests will erase db

### dev
`dotnet run --project src/consumablesBackend/consumablesBackend.csproj`
`dotnet watch --project src/consumablesBackend/consumablesBackend.csproj`
`clear | dotnet test`

### test with postman

route:
.../add, POST

body-> content type text/json

use the following format:
{
    "weatherForecastId": 0,
    "date": "2023-09-13",
    "temperatureC": 0,
    "temperatureF": 0,
    "summary": "customSummary"
}


### docker locally
`docker build -t backend .`
`docker run -p 5000:5000 backend`


### To do

docker locally not running:
-
You must install or update .NET to run this application.

App: /app/consumablesBackend.dll
Architecture: x64
Framework: 'Microsoft.AspNetCore.App', version '7.0.0' (x64)
.NET location: /usr/share/dotnet/

No frameworks were found.

Learn about framework resolution:
https://aka.ms/dotnet/app-launch-failed
-