FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS with-node
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_20.x | bash
RUN apt-get -y install nodejs
RUN npm install -g @angular/cli

FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MoviesDbDotNetAngular.Server/MoviesDbDotNetAngular.Server.csproj", "MoviesDbDotNetAngular.Server/"]
COPY ["moviesdbdotnetangular.client/moviesdbdotnetangular.client.esproj", "moviesdbdotnetangular.client/"]
RUN dotnet restore "./MoviesDbDotNetAngular.Server/MoviesDbDotNetAngular.Server.csproj"
COPY . .
WORKDIR "/src/MoviesDbDotNetAngular.Server"
RUN dotnet build "./MoviesDbDotNetAngular.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MoviesDbDotNetAngular.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoviesDbDotNetAngular.Server.dll"]
