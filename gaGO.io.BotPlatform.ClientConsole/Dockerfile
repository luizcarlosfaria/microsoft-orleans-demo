FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["gaGO.io.BotPlatform.ClientConsole/gaGO.io.BotPlatform.ClientConsole.csproj", "gaGO.io.BotPlatform.ClientConsole/"]
COPY ["gaGO.io.BotPlatform.Contracts/gaGO.io.BotPlatform.Contracts.csproj", "gaGO.io.BotPlatform.Contracts/"]
COPY ["gaGO.io.BotPlatform.Connect/gaGO.io.BotPlatform.Connect.csproj", "gaGO.io.BotPlatform.Connect/"]
RUN dotnet restore "gaGO.io.BotPlatform.ClientConsole/gaGO.io.BotPlatform.ClientConsole.csproj"
COPY . .
WORKDIR "/src/gaGO.io.BotPlatform.ClientConsole"
RUN dotnet build "gaGO.io.BotPlatform.ClientConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gaGO.io.BotPlatform.ClientConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gaGO.io.BotPlatform.ClientConsole.dll"]
