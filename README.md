# Docker Compose Demo
 A demo/proof of concept of how to use docker compose with APIs and databases. This project uses ASP.NET WebAPIs and MySQL databases but the concepts apply to most other frameworks, languages, and/or database management systems.

More information regarding docker and docker compose can be found here: https://docs.docker.com/compose/compose-file/
 
 ## Prerequisites

- Docker. Docker Desktop is recommended since it comes with docker compose. For more information: https://docs.docker.com/desktop/
- If you want to run any of the services locally outside of docker then .NET 6 will also be required.

 ## How to run
 - Make sure that docker is running.
 - In the root of the project execute the command 'docker compose build'. This will build the services outlined in docker-compose.yml.
 - Then once the build has completed, you can run all the containers with 'docker compose up'.

 ## How to interact with the different services

 The Music API Service can be accessed at the following URLs:

 - The Get Artists Endpoint: http://localhost:8000/music/artists
 - The Get Artist Albums Endpoint: http://localhost:8000/music/artists/{{artistId}}/albums

 The Sales Data API Service can be accessed at the following URLs:

- The Get Sales Stats Endpoint: http://localhost:8001/sales/stats/{{id}}

## Service interactions

Both the Music API Service and the Sales Data API Service have their own databases.

When calling the Music API Service's 'Get Artist Albums Endpoint' the Sales API Service's 'Get Sales Stats Endpoint' will be called for every album in the requested artist's catalog.

## Database Information

The Music Db can be accessed with the following information:

- Server: Localhost
- Port: 3309
- Database: music
- User: root
- Password: music-db-test-password

The Sales Data Db can be access with the following information:

- Server: Localhost
- Port: 3308
- Database: salesdata
- User: root
- Password: sales-data-db-test-password

Both databases are initialized and seeded with data using the dbscripts folder within their corresponding API Service directory. See any file named MySql.Dockerfile for more information.
