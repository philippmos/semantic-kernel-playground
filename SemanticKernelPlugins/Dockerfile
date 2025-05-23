FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 11434
ENV ASPNETCORE_HTTP_PORTS=11434

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SemanticKernelPlugins.csproj", "."]
RUN dotnet restore "SemanticKernelPlugins.csproj"
COPY . .
RUN dotnet publish "SemanticKernelPlugins.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SemanticKernelPlugins.dll"]