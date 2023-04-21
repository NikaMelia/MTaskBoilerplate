FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MTask.Boilerplate.Api/MTask.Boilerplate.Api.csproj", "MTask.Boilerplate.Api/"]
RUN dotnet restore "MTask.Boilerplate.Api/MTask.Boilerplate.Api.csproj"
COPY . .
WORKDIR "/src/MTask.Boilerplate.Api"
RUN dotnet build "MTask.Boilerplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTask.Boilerplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTask.Boilerplate.Api.dll"]
