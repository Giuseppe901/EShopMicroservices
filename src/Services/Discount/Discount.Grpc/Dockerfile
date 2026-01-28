# =====================================================
# Base runtime image
# =====================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# =====================================================
# Build stage
# =====================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Services/Discount/Discount.Grpc/Discount.Grpc.csproj", "Services/Discount/Discount.Grpc/"]
RUN dotnet restore "./Services/Discount/Discount.Grpc/Discount.Grpc.csproj"

COPY . .
WORKDIR "/src/Services/Discount/Discount.Grpc"
RUN dotnet build "./Discount.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# =====================================================
# Publish stage
# =====================================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Discount.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =====================================================
# Final runtime stage
# =====================================================
FROM base AS final
WORKDIR /app

# Crea user "app" e prepara /data con permessi corretti
RUN useradd -m app \
    && mkdir -p /data \
    && chown -R app:app /data

USER app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]
