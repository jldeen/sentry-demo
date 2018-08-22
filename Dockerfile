FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY sentrydemo.csproj sentrydemo/
RUN dotnet restore sentrydemo/sentrydemo.csproj
WORKDIR /src/sentrydemo
COPY . .
RUN dotnet build sentrydemo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish sentrydemo.csproj -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "sentrydemo.dll"]
