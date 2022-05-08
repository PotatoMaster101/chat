FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
EXPOSE 80 443
WORKDIR /src
COPY ["src/Chat.Data/Chat.Data.csproj", "Chat.Data/"]
COPY ["src/Chat.Web/Chat.Web.csproj", "Chat.Web/"]
RUN dotnet restore "Chat.Data/Chat.Data.csproj"
RUN dotnet restore "Chat.Web/Chat.Web.csproj"
COPY ["src/Chat.Data", "Chat.Data/"]
COPY ["src/Chat.Web", "Chat.Web/"]
WORKDIR "/src/Chat.Web"
RUN dotnet build "Chat.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.15 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.Web.dll"]
