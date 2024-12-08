FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pizzeria.API/Pizzeria.API.csproj", "Pizzeria.API/"]
COPY ["Pizzeria.Core/Pizzeria.Core.csproj", "Pizzeria.Core/"]
COPY ["Pizzeria.Application/Pizzeria.Application.csproj", "Pizzeria.Application/"]
COPY ["Pizzeria.Infrastructure/Pizzeria.Infrastructure.csproj", "Pizzeria.Infrastructure/"]
RUN dotnet restore "Pizzeria.API/Pizzeria.API.csproj"
COPY . .
WORKDIR "/src/Pizzeria.API"
RUN dotnet build "./Pizzeria.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pizzeria.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizzeria.API.dll"]