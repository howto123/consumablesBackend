# template from here: https://github.com/dotnet/dotnet-docker/blob/main/samples/dotnetapp/Dockerfile


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# restore and publish need to be on the same line apparently
COPY src/consumablesBackend .
RUN dotnet restore && dotnet publish -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "consumablesBackend.dll"]