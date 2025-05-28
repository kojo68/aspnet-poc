# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Restaure les dépendances
COPY Api/Api.csproj Api/
RUN dotnet restore Api/Api.csproj

# Copie le code et publie en Release
COPY Api/ Api/
RUN dotnet publish Api/Api.csproj -c Release -o /app/publish

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]
