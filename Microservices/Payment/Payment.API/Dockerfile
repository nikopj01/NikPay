#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Payment/Payment.API/Payment.API.csproj", "Microservices/Payment/Payment.API/"]
COPY ["Integration/EventBus/EventBus.csproj", "Integration/EventBus/"]
RUN dotnet restore "Microservices/Payment/Payment.API/Payment.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Payment/Payment.API"
RUN dotnet build "Payment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.API.dll"]