FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER root
WORKDIR /app
RUN apt-get update && apt-get install -y curl
RUN apt-get update && apt-get install -y iputils-ping

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["voidcat-api/voidcat-api.csproj", "voidcat-api/"]
RUN dotnet restore "voidcat-api/voidcat-api.csproj"
COPY . .
WORKDIR "/src/voidcat-api"
RUN dotnet build "voidcat-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "voidcat-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "voidcat-api.dll"]
