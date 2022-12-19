#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 9184

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Customer.Api/Customer.Api.csproj", "Customer.Api/"]
COPY ["Customer.Core/Customer.Core.csproj", "Customer.Core/"]
COPY ["Customer.Infrastructure/Customer.Infrastructure.csproj", "Customer.Infrastructure/"]
RUN dotnet nuget add source https://dotcode.bytesafe.dev/nuget/dotcode-nuget/index.json -n dotcode-nuget -u bytesafe -p 01GMBZBB6KKQGF2677M8NDB4CE
RUN dotnet restore "Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]