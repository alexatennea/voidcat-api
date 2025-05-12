# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER root
WORKDIR /app

# Optional: useful tools for debugging connectivity
RUN apt-get update && apt-get install -y curl iputils-ping

EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore
COPY ["voidcat-api.csproj", "."]
RUN dotnet restore "voidcat-api.csproj"

# Copy all and build
COPY . .
RUN dotnet build "voidcat-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "voidcat-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

# Fallback if APP_UID not set
ARG APP_UID=1000
USER ${APP_UID}

ENTRYPOINT ["dotnet", "voidcat-api.dll"]
