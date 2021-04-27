# This docker file needs to be run on the correct directory
# Use the docker compose file to build it instead.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY src .
RUN dotnet restore "HCB.Internal.Web.RCL.Gallery/HCB.Internal.Web.RCL.Gallery.csproj"
RUN dotnet build "HCB.Internal.Web.RCL.Gallery/HCB.Internal.Web.RCL.Gallery.csproj" -c Release -o /app/build
RUN dotnet publish "HCB.Internal.Web.RCL.Gallery/HCB.Internal.Web.RCL.Gallery.csproj" -c Release -o /app/publish

# FROM build AS publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot/ .
# This replaces the index into a production version
RUN cp index.html.prod index.html
COPY build/nginx.conf /etc/nginx/nginx.conf