FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Reports.API/Reports.API.csproj", "Reports.API/"]
RUN dotnet restore "Reports.API/Reports.API.csproj"
COPY . .
WORKDIR "/src/Reports.API"
RUN dotnet build "Reports.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reports.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reports.API.dll"]
