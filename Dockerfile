FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore

# RUN dotnet build TodoApi.csproj -c Release -o /out
# Build and publish a release
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
# COPY --from=build /out ./
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TodoApi.dll"]