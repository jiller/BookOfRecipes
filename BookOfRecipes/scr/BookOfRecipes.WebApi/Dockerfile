#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["scr/BookOfRecipes.WebApi/BookOfRecipes.WebApi.csproj", "scr/BookOfRecipes.WebApi/"]
RUN dotnet restore "scr/BookOfRecipes.WebApi/BookOfRecipes.WebApi.csproj"
COPY . .
WORKDIR "/src/scr/BookOfRecipes.WebApi"
RUN dotnet build "BookOfRecipes.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookOfRecipes.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookOfRecipes.WebApi.dll"]