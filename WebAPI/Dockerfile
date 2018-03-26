# This is the image this project will be built inside of
FROM microsoft/aspnetcore-build:2.0.6-2.1.101 AS build

# Create /app folder in root
WORKDIR /app

# Copy project code to ./app from directory containing Docker file
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Build with Release flag set and publish dlls to /app/bin
RUN dotnet publish --output /app/bin --configuration Release

# CD WORKDIR to /app/bin
WORKDIR ./bin

# List it's contents
RUN echo "(aspnetcore-build) Contents of /app/bin:" && ls -l

# Now use the target aspnetcore image
FROM microsoft/aspnetcore:2.0.6

# Copy everything from /app/bin in build image to /app in target image
COPY --from=build /app/bin /app

# CD WORKDIR to /app
WORKDIR /app

# List it's contents
RUN echo "(aspnetcore) Contents of /app:" && ls -l

# Set the command to run and it's args when connecting to container
ENTRYPOINT [ "dotnet", "WebAPI.dll" ]
