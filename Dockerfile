FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./*.sln ./
COPY ./src/Api/*.csproj ./src/Api/
COPY ./src/Domain/*.csproj ./src/Domain/
RUN dotnet restore

# copy everything else and build app
COPY ./src/Api/ ./src/Api/
COPY ./src/Domain/ ./src/Domain/
WORKDIR /app/src/Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/src/Api
COPY --from=build-env /app/src/Api/out .
ENTRYPOINT ["dotnet", "Api.dll"]
