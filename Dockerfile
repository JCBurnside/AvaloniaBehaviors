FROM mcr.microsoft.com/dotnet/core-nightly/sdk:3.0 AS base
WORKDIR .
FROM base AS build
COPY AvaloniaBehaviors.sln .

# Copy the main source project files
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

# Copy the test project files
COPY tests/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}/; done

COPY build/*/*.csproj ./
RUN mkdir -p build/build
RUN for file in $(ls *.csproj); do mv $file build/build/; done

COPY samples/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p samples/${file%.*}/ && mv $file samples/${file%.*}/; done

RUN dotnet restore 
COPY . .
RUN dotnet build .
RUN for file in $(ls /src/**/*.csproj); do dotnet pack $file --no-build --output /nuget/${file%.*} --version-suffix "ci-async"; done

WORKDIR .
COPY --from=base /nuget/**/*.* /nuget
ENTRYPOINT ["dotnet", "pack", ".", "--no-build", "--output", "/artifacts", "--version-suffix", "'ci-async'"]
