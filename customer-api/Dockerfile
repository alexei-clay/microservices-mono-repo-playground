# customer-api Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["customer-api.csproj", "./"]
RUN dotnet restore "customer-api.csproj"
COPY . .
RUN dotnet build "customer-api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "customer-api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "customer-api.dll"]
