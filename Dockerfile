# BUILD
########
FROM node:13 AS build

WORKDIR /app

COPY ./gulpfile.js ./gulpfile.js
COPY ./package.json ./package.json
COPY ./src/ ./src/

RUN npm install
RUN npm install --global gulp-cli
RUN gulp

# RUNTIME IMAGE
################
FROM httpd:2.4

COPY --from=build /app/src/public/ /usr/local/apache2/htdocs/