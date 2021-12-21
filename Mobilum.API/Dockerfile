#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mobilum.API/Mobilum.API.csproj", "Mobilum.API/"]
RUN dotnet restore "Mobilum.API/Mobilum.API.csproj"
COPY . .
WORKDIR "/src/Mobilum.API"
RUN dotnet build "Mobilum.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mobilum.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mobilum.API.dll"]