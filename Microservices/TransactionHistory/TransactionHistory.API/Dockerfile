#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/TransactionHistory/TransactionHistory.API/TransactionHistory.API.csproj", "Microservices/TransactionHistory/TransactionHistory.API/"]
RUN dotnet restore "Microservices/TransactionHistory/TransactionHistory.API/TransactionHistory.API.csproj"
COPY . .
WORKDIR "/src/Microservices/TransactionHistory/TransactionHistory.API"
RUN dotnet build "TransactionHistory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionHistory.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionHistory.API.dll"]