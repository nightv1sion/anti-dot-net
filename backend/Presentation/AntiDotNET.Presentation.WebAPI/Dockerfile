FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/AntiDotNET.Presentation.WebAPI/AntiDotNET.Presentation.WebAPI.csproj", "Presentation/AntiDotNET.Presentation.WebAPI/"]
RUN dotnet restore "Presentation/AntiDotNET.Presentation.WebAPI/AntiDotNET.Presentation.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/AntiDotNET.Presentation.WebAPI"
RUN dotnet build "AntiDotNET.Presentation.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AntiDotNET.Presentation.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AntiDotNET.Presentation.WebAPI.dll"]
