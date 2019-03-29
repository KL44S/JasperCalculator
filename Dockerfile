FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Business/Business.csproj ./Business/
COPY ./UI/UI.csproj ./UI/

# Copy solution
COPY ./Calculator.sln .

# Run restore through the solution
RUN dotnet restore Calculator.sln 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env app/UI/out .
ENTRYPOINT ["dotnet", "UI.dll"]