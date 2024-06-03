# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copiar todos os arquivos
COPY . ./

# Restaurar dependências e compilar o projeto
RUN dotnet restore ./AgendaDesafios.WebAPI/AgendaDesafios.WebAPI.csproj
RUN dotnet build ./AgendaDesafios.WebAPI/AgendaDesafios.WebAPI.csproj -c Release -o /app/build

# Publicar a aplicação
RUN dotnet publish ./AgendaDesafios.WebAPI/AgendaDesafios.WebAPI.csproj -c Release -o /app/publish

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Copiar os arquivos publicados da etapa de construção
COPY --from=build-env /app/publish .

# Expor a porta
EXPOSE 8080

# Comando de entrada para executar a aplicação
ENTRYPOINT ["dotnet", "AgendaDesafios.WebAPI.dll"]

# sudo docker build -t back-image .
# docker run  --name back-container -p 5000:8080 back-image