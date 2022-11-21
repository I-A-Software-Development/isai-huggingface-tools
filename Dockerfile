FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HuggingFace-API/NuGet.Config", "HuggingFace-API/"]
COPY ["HuggingFace-Connectors/NuGet.Config", "HuggingFace-Connectors/"]
COPY ["Entities/NuGet.Config", "Entities/"]
COPY ["Logger/NuGet.Config", "Logger/"]
COPY ["HuggingFace-API/HuggingFace-API.csproj", "HuggingFace-API/"]
COPY ["HuggingFace-Connectors/HuggingFace-Connectors.csproj", "HuggingFace-Connectors/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Logger/Logger.csproj", "Logger/"]
RUN mkdir /root/.nuget/packages
RUN dotnet restore "HuggingFace-API/HuggingFace-API.csproj" --configfile "HuggingFace-API/NuGet.Config"
COPY . .
WORKDIR "/src/HuggingFace-API"
RUN dotnet build "HuggingFace-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HuggingFace-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "HuggingFace-API.dll"]
