# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/API/Lambda.Api/Lambda.Api.csproj", "src/API/Lambda.Api/"]
COPY ["src/Modules/Lessons/Lambda.Modules.Lessons.Infrastructure/Lambda.Modules.Lessons.Infrastructure.csproj", "src/Modules/Lessons/Lambda.Modules.Lessons.Infrastructure/"]
COPY ["src/Modules/Lessons/Lambda.Modules.Lessons.Application/Lambda.Modules.Lessons.Application.csproj", "src/Modules/Lessons/Lambda.Modules.Lessons.Application/"]
COPY ["src/Modules/Lessons/Lambda.Modules.Lessons.Domain/Lambda.Modules.Lessons.Domain.csproj", "src/Modules/Lessons/Lambda.Modules.Lessons.Domain/"]
COPY ["src/Common/Lambda.Common.Domain/Lambda.Common.Domain.csproj", "src/Common/Lambda.Common.Domain/"]
COPY ["src/Modules/Lessons/Lambda.Modules.Lessons.Presentation/Lambda.Modules.Lessons.Presentation.csproj", "src/Modules/Lessons/Lambda.Modules.Lessons.Presentation/"]
RUN dotnet restore "./src/API/Lambda.Api/Lambda.Api.csproj"
COPY . .
WORKDIR "/src/src/API/Lambda.Api"
RUN dotnet build "./Lambda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Lambda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lambda.Api.dll"]