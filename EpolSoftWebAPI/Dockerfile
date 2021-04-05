#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["EpolSoftWebAPI/EpolSoft.WebAPI.csproj", "EpolSoftWebAPI/"]
COPY ["EpolSoft.BusinessLayer/EpolSoft.BusinessLayer.csproj", "EpolSoft.BusinessLayer/"]
COPY ["EpolSoft.DataAccessLayer/EpolSoft.DataAccessLayer.csproj", "EpolSoft.DataAccessLayer/"]
COPY ["EpolSoft.Common/EpolSoft.Common.csproj", "EpolSoft.Common/"]
RUN dotnet restore "EpolSoftWebAPI/EpolSoft.WebAPI.csproj"
COPY . .
WORKDIR "/src/EpolSoftWebAPI"
RUN dotnet build "EpolSoft.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EpolSoft.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EpolSoft.WebAPI.dll"]