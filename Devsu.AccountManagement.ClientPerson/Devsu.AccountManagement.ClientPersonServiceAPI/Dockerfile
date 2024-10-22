# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /source

# Copy the .sln and restore dependencies
COPY *.sln .

# Copy all the projects (API and libraries)
COPY Devsu.AccountManagement.ClientPersonServiceAPI/*.csproj ./Devsu.AccountManagement.ClientPersonServiceAPI/
COPY Devsu.AccountManagement.Application/*.csproj ./Devsu.AccountManagement.Application/
COPY Devsu.AccountManagement.Test/*.csproj ./Devsu.AccountManagement.Test/
COPY Devsu.AccountManagement.Infrastructure/*.csproj ./Devsu.AccountManagement.Infrastructure/
COPY Devsu.AccountManagement.Domain/*.csproj ./Devsu.AccountManagement.Domain/
COPY Devsu.AccountManagement.Commom/*.csproj ./Devsu.AccountManagement.Commom/

# Run restore to install dependencies
RUN dotnet restore

# Copy the rest of the source code for all the projects
COPY . .

# Build the project
WORKDIR /source/Devsu.AccountManagement.ClientPersonServiceAPI
RUN dotnet publish -c Release -o /app

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Expose port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "Devsu.AccountManagement.ClientPersonAPI.dll"]
