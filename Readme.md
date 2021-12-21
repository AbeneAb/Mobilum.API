## Project Requirement
- [Visual Studio Community Edition](https://visualstudio.microsoft.com/vs/community/) or 
- - [Visual Studio Code](https://code.visualstudio.com/)

*If you are not using docker*
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Using Docker
- Install [docker desktop](https://www.docker.com/products/docker-desktop) for windows or mac
```terminal
docker-compose up -d
```
## Project Structure
This work contains 3 projects, The Mobilum.API, Mobilum.Benchmark & Mobilum.UnitTests, as their name implies.

## Using Visual Studio
>*Do note that in other to run the project locally, you need to either install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) on your local machine or spin up the [container](docker-compose.yml) on docker. Do change the connectionstring accordingly on the [appsetting.json](/mobilum.API/appsettings.json)* 

open [Mobilum.API](Mobilum.API.sln)

### Running Benchmark tests
Goto Mobilum.Benchmark project, open terminal window then run
```terminal
dotnet build -c Release
dotnet  path\to\Mobilum.Benchmark.dll
```



### Challenges
The scope of this work was on finding the right implimentation of search algorithm. I have gone with Search tree.
