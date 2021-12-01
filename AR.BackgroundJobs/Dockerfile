FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AR.BackgroundJobs/AR.BackgroundJobs.csproj", "AR.BackgroundJobs/"]
RUN dotnet restore "AR.BackgroundJobs/AR.BackgroundJobs.csproj"
COPY . .
WORKDIR "/src/AR.BackgroundJobs"
RUN dotnet build "AR.BackgroundJobs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AR.BackgroundJobs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AR.BackgroundJobs.dll"]