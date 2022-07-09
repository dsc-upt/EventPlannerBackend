FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventPlannerBackend/EventPlannerBackend.csproj", "EventPlannerBackend/"]
RUN dotnet restore "EventPlannerBackend/EventPlannerBackend.csproj"
COPY . .
WORKDIR "/src/EventPlannerBackend"
RUN dotnet build "EventPlannerBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventPlannerBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventPlannerBackend.dll"]
