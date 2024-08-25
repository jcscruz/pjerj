FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["./src/API/API.csproj", "app/src/API/"]
COPY ["./src/Application/Application.csproj", "app/src/Application/"]
COPY ["./src/Infra/Infra.csproj", "app/src/Infra/"]
COPY ["./src/Domain/Domain.csproj", "app/src/Domain/"]
RUN dotnet restore "./app/src/API/API.csproj"
COPY . .
WORKDIR "/app/src/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]