# BlazorApp

## Docker

#### Building Locally
```
docker build -t aspnetapp .

docker run -d -v $PWD:/app -p 5001:5001 \
    -p 5000:5000 --name myapp aspnetapp
```

#### Testing Locally
```dockerfile
docker run --name coconut -i -p 5000:80 -v ${pwd}:/app -w /app microsoft/aspnetcore-build bash -c "dotnet restore && dotnet run"
```


#### Running `latest` image from hub.docker.com
```
docker run -d -p 5001:5001 \
    -p 5000:5000 cneary/blazor
    ```


