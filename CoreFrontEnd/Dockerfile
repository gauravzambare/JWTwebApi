FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["CoreFrontEnd/CoreFrontEnd.csproj", "CoreFrontEnd/"]
RUN dotnet restore "CoreFrontEnd/CoreFrontEnd.csproj"
COPY . .
WORKDIR "/src/CoreFrontEnd"
RUN dotnet build "CoreFrontEnd.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreFrontEnd.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreFrontEnd.dll"]