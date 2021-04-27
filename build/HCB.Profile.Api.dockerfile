FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# RUN apt-get update \
#  && apt-get install -y --no-install-recommends unzip \
#  && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY src .
RUN dotnet restore "HCB.Profile.Api/HCB.Profile.Api.csproj"
COPY . .
RUN dotnet build "HCB.Profile.Api/HCB.Profile.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HCB.Profile.Api/HCB.Profile.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HCB.Profile.Api.dll"]