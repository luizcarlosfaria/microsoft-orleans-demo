FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["gaGO.io.MicrosoftOrleansDemo.Silo/gaGO.io.MicrosoftOrleansDemo.Silo.csproj", "gaGO.io.MicrosoftOrleansDemo.Silo/"]
COPY ["gaGO.io.MicrosoftOrleansDemo.Grains/gaGO.io.MicrosoftOrleansDemo.Grains.csproj", "gaGO.io.MicrosoftOrleansDemo.Grains/"]
COPY ["gaGO.io.MicrosoftOrleansDemo.Contracts/gaGO.io.MicrosoftOrleansDemo.Contracts.csproj", "gaGO.io.MicrosoftOrleansDemo.Contracts/"]
COPY ["gaGO.io.MicrosoftOrleansDemo.Connect/gaGO.io.MicrosoftOrleansDemo.Connect.csproj", "gaGO.io.MicrosoftOrleansDemo.Connect/"]
COPY ["global.json", "./"]
COPY ["NuGet.Config", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "gaGO.io.MicrosoftOrleansDemo.Silo/gaGO.io.MicrosoftOrleansDemo.Silo.csproj"
COPY . .
WORKDIR "/src/gaGO.io.MicrosoftOrleansDemo.Silo"
RUN dotnet build "gaGO.io.MicrosoftOrleansDemo.Silo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gaGO.io.MicrosoftOrleansDemo.Silo.csproj" -c Release -o /app/publish

FROM build AS final
#FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gaGO.io.MicrosoftOrleansDemo.Silo.dll"]
