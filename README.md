# docker-compose-demo
 A demo of how to use docker compose with APIs and databases.

 ## How to run
 1.) Make sure that docker is running.
 2.) In the root of the project execute the command 'docker compose build'
 3.) Then once the build has completed, you can run all the containers with 'docker compose up'

 ## How to interact with the different service

 The Music API Service can be accessed at the following URLs

 - The Get Artists Endpiont: http://localhost:8000/music/artists
 - The Get Artist Albums Endpoint: http://localhost:8000/music/artists/{{artistId}}/albums

 The Sales Data Api Service can be accessed at the following URLs

- The Get Sales Stats Endpoint: http://localhost:8001/sales/stats/{{id}}

## Service interactions

Both the Music Api Service and the Sales Data Api Service have their own databases.

When calling the Music Api Service's 'Get Artist Albums Endpoint' the Sales Api Service's 'Get Sales Stats Endpoint' will be called for every album in the requested artist's catalog.

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

Both databases are initially configure with using the dbscripts folder within their corresponding Api Service directory. See any file named MySql.Dockerfile for more information.