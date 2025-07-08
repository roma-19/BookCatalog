FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookCatalog.API/BookCatalog.API.csproj", "BookCatalog.API/"]
COPY ["BookCatalog.Infrastructure/BookCatalog.Infrastructure.csproj", "BookCatalog.Infrastructure/"]
COPY ["BookCatalog.Domain/BookCatalog.Domain.csproj", "BookCatalog.Domain/"]
COPY ["BookCatalog.Application/BookCatalog.Application.csproj", "BookCatalog.Application/"]
RUN dotnet restore "BookCatalog.API/BookCatalog.API.csproj"
COPY . .
WORKDIR "/src/BookCatalog.API"
RUN dotnet build "./BookCatalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookCatalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookCatalog.API.dll"]
