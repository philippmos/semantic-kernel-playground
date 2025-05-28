FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
ARG informationalversion=unpublished

COPY . TAIste/src/TAIste.Plugins/

RUN dotnet publish TAIste/src/TAIste.Plugins/ -c Release -p:InformationalVersion=${informationalversion} -o /app 

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=builder app/ .
EXPOSE 11434
ENTRYPOINT ["dotnet", "TAIste.Plugins.dll"]
