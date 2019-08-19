﻿FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["LayuiNetCoreDemo.csproj", "LayuiNetCoreDemo/"]
RUN dotnet restore "LayuiNetCoreDemo/LayuiNetCoreDemo.csproj"
COPY . .
WORKDIR "/src/LayuiNetCoreDemo"
RUN dotnet build "LayuiNetCoreDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LayuiNetCoreDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LayuiNetCoreDemo.dll"]