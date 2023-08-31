#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SmartDelala.WebApi/SmartDelala.WebApi.csproj", "SmartDelala.WebApi/"]
COPY ["SmartDelala.Application/SmartDelala.Application.csproj", "SmartDelala.Application/"]
COPY ["SmartDelala.Domain/SmartDelala.Domain.csproj", "SmartDelala.Domain/"]
COPY ["SmartDelala.Persistence/SmartDelala.Persistence.csproj", "SmartDelala.Persistence/"]
RUN dotnet restore "SmartDelala.WebApi/SmartDelala.WebApi.csproj"
COPY . .
WORKDIR "/src/SmartDelala.WebApi"
RUN dotnet build "SmartDelala.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartDelala.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartDelala.WebApi.dll"]