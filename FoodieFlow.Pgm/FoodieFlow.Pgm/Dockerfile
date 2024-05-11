# Use a imagem base do runtime .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

# Use a imagem base do SDK .NET para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

# Atualize os pacotes e instale as dependências necessárias
RUN apk update && apk upgrade && apk add efs-utils git binutils tzdata icu-data-full icu-libs && ln -s /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime

# Copie os arquivos do projeto para a imagem
COPY ["FoodieFlow.Pgm/FoodieFlow.Pgm.csproj", "FoodieFlow.Pgm/"]
COPY ["FoodieFlow.Pgm.Core/FoodieFlow.Pgm.Core.csproj", "FoodieFlow.Pgm.Core/"]
COPY ["FoodieFlow.Pgm.Infra/FoodieFlow.Pgm.Infra.csproj", "FoodieFlow.Pgm.Infra/"]
COPY ["FoodieFlow.Pgm.SharedKernel/FoodieFlow.Pgm.SharedKernel.csproj", "FoodieFlow.Pgm.SharedKernel/"]
COPY ["FoodieFlow.Pgm/nuget.config",""]

# Restaure as dependências
RUN dotnet restore "FoodieFlow.Pgm/FoodieFlow.Pgm.csproj"

# Copie o restante dos arquivos e construa o projeto
COPY . .
WORKDIR "/src/FoodieFlow.Pgm"
RUN dotnet build "FoodieFlow.Pgm.csproj" -c Release -o /app/build

# Publique o projeto
FROM build AS publish
RUN dotnet publish "FoodieFlow.Pgm.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Crie a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Atualize os pacotes e instale as dependências necessárias
RUN apk update && apk upgrade && apk add icu-data-full icu-libs

# Defina o fuso horário
RUN apk update && apk add --no-cache tzdata && cp /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime && echo "America/Sao_Paulo" > /etc/timezone

# Defina o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "FoodieFlow.Pgm.dll"]
