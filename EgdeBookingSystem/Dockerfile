#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EgdeBookingSystem.csproj", "./"]
RUN dotnet restore "EgdeBookingSystem.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "EgdeBookingSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EgdeBookingSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EgdeBookingSystem.dll"]

FROM microsoft/aspnetcore-build:lts
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh