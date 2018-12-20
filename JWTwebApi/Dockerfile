FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["JWTwebApi/JWTwebApi.csproj", "JWTwebApi/"]
RUN dotnet restore "JWTwebApi/JWTwebApi.csproj"
COPY . .
WORKDIR "/src/JWTwebApi"
RUN dotnet build "JWTwebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JWTwebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JWTwebApi.dll"]