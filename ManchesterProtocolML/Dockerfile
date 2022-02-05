FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ManchesterProtocolML/ManchesterProtocolML.csproj", "ManchesterProtocolML/"]
RUN dotnet restore "ManchesterProtocolML/ManchesterProtocolML.csproj"
COPY . .
WORKDIR "/src/ManchesterProtocolML"
RUN dotnet build "ManchesterProtocolML.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManchesterProtocolML.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ManchesterProtocolML.dll