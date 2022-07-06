#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BamstiChat/BamstiChat.csproj", "BamstiChat/"]
RUN dotnet restore "BamstiChat/BamstiChat.csproj"
COPY . .
WORKDIR "/src/BamstiChat"
RUN dotnet build "BamstiChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BamstiChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BamstiChat.dll"]