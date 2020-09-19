# BUILD
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY ./src/ ./src/

RUN dotnet publish ./src/Wedding.WebApp --configuration Release --output /app/artifacts

# RUNTIME
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

COPY --from=build /app/artifacts ./

ENTRYPOINT ["dotnet", "Wedding.WebApp.dll"]