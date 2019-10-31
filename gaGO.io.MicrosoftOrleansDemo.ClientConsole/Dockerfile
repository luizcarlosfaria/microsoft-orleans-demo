FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["gaGO.io.MicrosoftOrleansDemo.ClientConsole/gaGO.io.MicrosoftOrleansDemo.ClientConsole.csproj", "gaGO.io.MicrosoftOrleansDemo.ClientConsole/"]
COPY ["gaGO.io.MicrosoftOrleansDemo.Contracts/gaGO.io.MicrosoftOrleansDemo.Contracts.csproj", "gaGO.io.MicrosoftOrleansDemo.Contracts/"]
COPY ["gaGO.io.MicrosoftOrleansDemo.Connect/gaGO.io.MicrosoftOrleansDemo.Connect.csproj", "gaGO.io.MicrosoftOrleansDemo.Connect/"]
COPY ["global.json", "./"]
COPY ["NuGet.Config", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "gaGO.io.MicrosoftOrleansDemo.ClientConsole/gaGO.io.MicrosoftOrleansDemo.ClientConsole.csproj"
COPY . .
WORKDIR "/src/gaGO.io.MicrosoftOrleansDemo.ClientConsole"
RUN dotnet build "gaGO.io.MicrosoftOrleansDemo.ClientConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gaGO.io.MicrosoftOrleansDemo.ClientConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gaGO.io.MicrosoftOrleansDemo.ClientConsole.dll"]
