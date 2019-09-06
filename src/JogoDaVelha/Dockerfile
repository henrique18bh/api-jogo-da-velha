FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["JogoDaVelha/JogoDaVelha.csproj", "JogoDaVelha/"]
RUN dotnet restore "JogoDaVelha/JogoDaVelha.csproj"
COPY . .
WORKDIR "/src/JogoDaVelha"
RUN dotnet build "JogoDaVelha.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JogoDaVelha.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JogoDaVelha.dll"]