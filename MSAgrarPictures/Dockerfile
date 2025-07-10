# ==============================
# Base Runtime Image
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ==============================
# Build Image
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install Node.js 18
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

# Set working directory
WORKDIR /src

# Copy csproj and restore as distinct layers for better caching
COPY ["MSAgrarPictures/MSAgrarPictures.csproj", "MSAgrarPictures/"]
COPY ["MSLib/MSLib.csproj", "MSLib/"]
RUN dotnet restore "MSAgrarPictures/MSAgrarPictures.csproj"

# Copy remaining files
COPY . .

# Install frontend dependencies (npm ci = reproducible and clean)
WORKDIR /src/MSAgrarPictures
COPY ["MSAgrarPictures/package*.json", "./"]
RUN npm ci

# Build .NET project
RUN dotnet build "MSAgrarPictures.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ==============================
# Publish Image
# ==============================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MSAgrarPictures.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ==============================
# Final Runtime Image
# ==============================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MSAgrarPictures.dll"]
