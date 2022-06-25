FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DbConnection.csproj", "./"]
RUN dotnet restore "DbConnection.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "DbConnection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbConnection.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbConnection.dll"]
