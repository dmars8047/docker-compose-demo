FROM mysql:8.0.31

COPY ./dbscripts /docker-entrypoint-initdb.d/