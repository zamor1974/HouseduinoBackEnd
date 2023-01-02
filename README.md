dotnet build
dotnet run
dotnet watch run

docker list
docker build -t houseduino_be:0.0.1 -f Dockerfile .
docker save houseduinobackend:0.1.6 > houseduino_be.tar
docker run -p 5000:80 -t houseduinobackend:0.1.6