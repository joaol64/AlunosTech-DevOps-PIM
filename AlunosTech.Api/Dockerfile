
# Etapa 1 - Compilar a API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY AlunosTech.Api.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2 - Executar a API
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "AlunosTech.Api.dll"]
