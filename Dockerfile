FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# ENV ASPNETCORE_ENVIRONMENT Production

COPY src/ .
RUN dotnet restore

# copy everything else and build app
WORKDIR /app/Api
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/Api/out ./
ENTRYPOINT ["dotnet", "Api.dll"]

