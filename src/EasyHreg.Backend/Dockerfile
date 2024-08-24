FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS build
WORKDIR /source

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:6c4df091e4e531bb93bdbfe7e7f0998e7ced344f54426b7e874116a3dc3233ff

ARG CHROME_VERSION="122.0.6261.90"
RUN apt-get update && apt-get -f install && apt-get -y install wget gnupg2 apt-utils
RUN wget --no-verbose -O /tmp/chrome.deb https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb \
&& apt-get update \
&& apt-get install -y /tmp/chrome.deb --no-install-recommends --allow-downgrades fonts-ipafont-gothic fonts-wqy-zenhei fonts-thai-tlwg fonts-kacst fonts-freefont-ttf \
&& rm /tmp/chrome.deb

ENV CHROME_DRIVER_PATH=/usr/bin/google-chrome-stable

WORKDIR /app
COPY --from=build /app .
COPY --from=build /source/Persons.xlsx .

EXPOSE 8080

ENTRYPOINT ["dotnet", "EasyHreg.Backend.dll"]