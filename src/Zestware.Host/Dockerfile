FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Zestware.Host/Zestware.Host.csproj", "Zestware.Host/"]
RUN dotnet restore "src/Zestware.Host/Zestware.Host.csproj"
COPY . .
WORKDIR "/src/Zestware.Host"
RUN dotnet build "Zestware.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zestware.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zestware.Host.dll"]
