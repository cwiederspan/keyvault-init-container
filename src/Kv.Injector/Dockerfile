FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Kv.Injector/Kv.Injector.csproj", "Kv.Injector/"]
RUN dotnet restore "Kv.Injector/Kv.Injector.csproj"
COPY . .
WORKDIR "/src/Kv.Injector"
RUN dotnet build "Kv.Injector.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Kv.Injector.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Kv.Injector.dll"]