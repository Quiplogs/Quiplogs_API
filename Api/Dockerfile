FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

EXPOSE 80
EXPOSE 5024

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Api.Core/*.csproj ./Api.Core/
COPY Api.Infrastructure/*.csproj ./Api.Infrastructure/
COPY Quiplogs.Assets/*.csproj ./Quiplogs.Assets/
COPY Quiplogs.BlobStorage/*.csproj ./Quiplogs.BlobStorage/
COPY Quiplogs.Dashboard/*.csproj ./Quiplogs.Dashboard/
COPY Quiplogs.Email/*.csproj ./Quiplogs.Email/
COPY Quiplogs.Inventory/*.csproj ./Quiplogs.Inventory/
COPY Quiplogs.Notifications/*.csproj ./Quiplogs.Notifications/
COPY Quiplogs.WorkOrder/*.csproj ./Quiplogs.WorkOrder/

RUN dotnet nuget add source https://nuget.pkg.github.com/Sl1ver/index.json -u nuget -p 45a74283c1ec66bd76af621671ef23145b7a43a0 --store-password-in-clear-text

RUN dotnet restore

# copy everything else and build app
COPY Api/. ./Api/
COPY Api.Core/. ./Api.Core/
COPY Api.Infrastructure/. ./Api.Infrastructure/
COPY Quiplogs.Assets/. ./Quiplogs.Assets/
COPY Quiplogs.BlobStorage/. ./Quiplogs.BlobStorage/
COPY Quiplogs.Dashboard/. ./Quiplogs.Dashboard/
COPY Quiplogs.Email/. ./Quiplogs.Email/
COPY Quiplogs.Inventory/. ./Quiplogs.Inventory/
COPY Quiplogs.Notifications/. ./Quiplogs.Notifications/
COPY Quiplogs.WorkOrder/. ./Quiplogs.WorkOrder/

WORKDIR /app/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/Api/out ./
ENTRYPOINT ["dotnet", "Api.dll"]