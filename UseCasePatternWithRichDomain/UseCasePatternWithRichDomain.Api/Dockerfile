FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UseCasePatternWithRichDomain.Api/UseCasePatternWithRichDomain.Api.csproj", "UseCasePatternWithRichDomain.Api/"]
RUN dotnet restore "UseCasePatternWithRichDomain.Api/UseCasePatternWithRichDomain.Api.csproj"
COPY . .
WORKDIR "/src/UseCasePatternWithRichDomain.Api"
RUN dotnet build "UseCasePatternWithRichDomain.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UseCasePatternWithRichDomain.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UseCasePatternWithRichDomain.Api.dll"]
