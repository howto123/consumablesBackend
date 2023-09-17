# template from here: https://github.com/dotnet/dotnet-docker/blob/main/samples/dotnetapp/Dockerfile
# .dockerignore needs to be correct
# --self-contained false needs to be removed

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# restore in dedicated layer 
COPY src/consumablesBackend/consumablesBackend.csproj .
RUN dotnet restore --use-current-runtime

COPY src/consumablesBackend .
RUN dotnet publish --use-current-runtime --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app .

CMD ["dotnet", "consumablesBackend.dll"]