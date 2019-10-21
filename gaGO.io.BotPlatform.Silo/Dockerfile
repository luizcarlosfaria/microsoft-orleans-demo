FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["gaGO.io.BotPlatform.Silo/gaGO.io.BotPlatform.Silo.csproj", "gaGO.io.BotPlatform.Silo/"]
COPY ["gaGO.io.BotPlatform.Grains/gaGO.io.BotPlatform.Grains.csproj", "gaGO.io.BotPlatform.Grains/"]
COPY ["gaGO.io.BotPlatform.Contracts/gaGO.io.BotPlatform.Contracts.csproj", "gaGO.io.BotPlatform.Contracts/"]
COPY ["gaGO.io.BotPlatform.Connect/gaGO.io.BotPlatform.Connect.csproj", "gaGO.io.BotPlatform.Connect/"]
COPY ["global.json", "./"]
COPY ["NuGet.Config", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "gaGO.io.BotPlatform.Silo/gaGO.io.BotPlatform.Silo.csproj"
COPY . .
WORKDIR "/src/gaGO.io.BotPlatform.Silo"
RUN dotnet build "gaGO.io.BotPlatform.Silo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gaGO.io.BotPlatform.Silo.csproj" -c Release -o /app/publish

FROM build AS final
#FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gaGO.io.BotPlatform.Silo.dll"]
