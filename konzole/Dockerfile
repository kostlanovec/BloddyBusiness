FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["konzole/konzole.csproj", "konzole/"]
RUN dotnet restore "konzole/konzole.csproj"
COPY . .
WORKDIR "/src/konzole"
RUN dotnet build "konzole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "konzole.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "konzole.dll"]
