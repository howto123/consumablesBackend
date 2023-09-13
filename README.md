# consumablesBackend

Entity Framework:
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

create weather.db and set the absolute path in appsettings.json
tests will erase db

### dev
`dotnet run --project src/consumablesBackend/consumablesBackend.csproj`
`dotnet watch --project src/consumablesBackend/consumablesBackend.csproj`
`dotnet test`

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