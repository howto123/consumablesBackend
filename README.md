# consumablesBackend

Entity Framework:
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

### be aware of these remarks
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
`docker run --rm -e dbPath="blabla" -p 5000:80 backend`
`docker run --rm -v ${pwd}/database:/app/database -e dbPath="./database/weather.db" -p 5000:80 backend`

Set dockerignore as shown here: https://github.com/dotnet/sdk/issues/9921


`... -it --entrypoint sh backend`

Leave container shell: `exit`

### To do

