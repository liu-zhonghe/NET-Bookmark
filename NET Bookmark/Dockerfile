# 使用ASP.NET Core的官方基础镜像
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

# 构建项目
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyAspNetApp.csproj", ""]
RUN dotnet restore "./MyAspNetApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyAspNetApp.csproj" -c Release -o /app/build

# 发布项目
FROM build AS publish
RUN dotnet publish "MyAspNetApp.csproj" -c Release -o /app/publish

# 构建最终镜像
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetApp.dll"]