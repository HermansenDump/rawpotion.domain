  # https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Rawpotion.Domain/*.csproj ./Rawpotion.Domain/
COPY Rawpotion.Domain.GraphQL/*.csproj ./Rawpotion.Domain.GraphQL/
RUN dotnet restore

# copy everything else and build app
COPY Rawpotion.Domain/. ./Rawpotion.Domain/
COPY Rawpotion.Domain.GraphQL/. ./Rawpotion.Domain.GraphQL/
WORKDIR /source/Rawpotion.Domain
RUN dotnet publish -c release -o /app --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-alpine
WORKDIR /app
COPY --from=build /app ./

# See: https://github.com/dotnet/announcements/issues/20
# Uncomment to enable globalization APIs (or delete)
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
#RUN apk add --no-cache icu-libs
#ENV LC_ALL en_US.UTF-8
#ENV LANG en_US.UTF-8

ENTRYPOINT ["./Rawpotion.Domain"]
