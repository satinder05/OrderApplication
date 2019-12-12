FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["API123/API123.csproj", "API123/"]
RUN dotnet restore "API123/API123.csproj"
COPY . .
WORKDIR "/src/API123"
RUN dotnet build "API123.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API123.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API123.dll"]