FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY SuSchedulerUsers/*.sln .
COPY SuSchedulerUsers/SuSchedulerUsers/*.csproj ./SuSchedulerUsers/

# copy everything else and build app
COPY SuSchedulerUsers/SuSchedulerUsers/. ./SuSchedulerUsers/
WORKDIR /app/SuSchedulerUsers
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/SuSchedulerUsers/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet SuSchedulerUsers.dll