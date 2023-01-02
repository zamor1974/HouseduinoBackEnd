#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
#WORKDIR /App
#COPY . ./
#RUN dotnet restore
#RUN dotnet publish -c Release -o out
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /App
#COPY --from=build-env /App/out .
#ENTRYPOINT ["dotnet", "HouseduinoBackEnd.dll"]
#EXPOSE 5557

# Step 1 - The Build Environment #

#Base Image for Build - dotnetcore SDK Image

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./HouseduinoBackEnd.csproj", "src/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/HouseduinoBackEnd.csproj"

#Copy all the source code into the Build Container
COPY . .

# Run dotnet publish in the Build Container
# Generates output available in /app/build
# Since the current directory is /app

WORKDIR "/src/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Step 1 Ends - The binaries are generated #

# Step 2 - Continuing from the End of Step 1 #
# Second Stage - Pick an Image with only dotnetcore Runtime
# base is defined at the top of the script - mcr.microsoft.com/dotnet/aspnet:6.0
FROM base AS runtime

# Set the Directory as /app
# All consecutive operations happen under /app
WORKDIR /app

# Copy the dlls generated under /app/out of the previous step
# With alias build onto the current directory
# Which is /app in runtime
COPY --from=publish /app/publish .

# Set the Entrypoint for the Container
# Entrypoint is for executables (such as exe, dll)
# Which cannot be overriden by run command
# or docker-compose
ENTRYPOINT [ "dotnet", "HouseduinoBackEnd.dll" ]