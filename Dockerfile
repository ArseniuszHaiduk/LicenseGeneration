FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY . .

RUN dotnet restore 

RUN dotnet publish -c Release -o ./app/out

FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /source

COPY --from=build ./app/out .

ENTRYPOINT ["dotnet", "LicenseGeneration.dll"]