FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_HTTPS_PORT=443
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="password"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/authorizationservice.p12
ENV ASPNETCORE_URLS="https://+;http://+"


FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AuthorizationService/AuthorizationService.csproj", "AuthorizationService/"]
RUN dotnet restore "AuthorizationService/AuthorizationService.csproj"
COPY . .
WORKDIR "/src/AuthorizationService"
RUN dotnet build "AuthorizationService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AuthorizationService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "AuthorizationService.dll"]