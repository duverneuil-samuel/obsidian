# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie le fichier csproj et restaure les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copie le reste des fichiers et publie
COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose le port 80
EXPOSE 80

# Commande de démarrage
ENTRYPOINT ["dotnet", "Obsidian.dll"]
