docker build -t music-api .

docker run --rm -it -d -p 8000:80 music-api