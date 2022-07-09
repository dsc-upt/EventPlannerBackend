FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventPlanner/EventPlanner.csproj", "EventPlanner/"]
RUN dotnet restore "EventPlanner/EventPlanner.csproj"
COPY . .
WORKDIR "/src/EventPlanner"
RUN dotnet build "EventPlanner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventPlanner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventPlanner.dll"]
