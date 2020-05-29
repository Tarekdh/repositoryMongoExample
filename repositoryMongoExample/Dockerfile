# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION="1.0.0"

COPY repositoryMongoExample.csproj /build/

RUN dotnet restore ./build/repositoryMongoExample.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./repositoryMongoExample.csproj -c $BUILDCONFIG -o out

# -c Release -o out

#-c $BUILDCONFIG -o out /p:Version=$VERSION

FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "repositoryMongoExample.dll"] 

