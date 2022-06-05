FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR src/Mela.MailService.Api/

COPY src/Mela.MailService.Api/*.csproj .
RUN dotnet restore Mela.MailService.Api.csproj

COPY src/Mela.MailService.Api .
RUN dotnet publish -c Release -o out \
                 --runtime alpine-x64 \
                 --self-contained true \
                 /p:PublishTrimmed=true \
                 /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS publish

WORKDIR /app
COPY --from=build /src/Mela.MailService.Api/out .

EXPOSE 80
ENTRYPOINT ["./Mela.MailService.Api"]