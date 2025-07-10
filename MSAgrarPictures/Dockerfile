FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["MSAgrarPictures/MSAgrarPictures.csproj", "MSAgrarPictures/"]
COPY ["MSLib/MSLib.csproj", "MSLib/"]
RUN dotnet restore "MSAgrarPictures/MSAgrarPictures.csproj"
COPY . .
WORKDIR "/src/MSAgrarPictures"
RUN dotnet build "MSAgrarPictures.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MSAgrarPictures.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSAgrarPictures.dll"]
