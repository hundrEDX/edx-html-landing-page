FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build

WORKDIR /app

COPY . ./

RUN dotnet publish --output out --configuration Release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine

COPY --from=build /app/out .

ENTRYPOINT [ "dotnet", "LandingPage.dll" ]