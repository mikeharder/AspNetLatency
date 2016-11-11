# AspNetLatency

## Results
.NET | Environment | GET (ms) | POST (ms)
--- | --- | --- | ---
Framework | Localhost | 3.33 | 3.57
Core | Localhost | 5.00 | 5.40
Framework | Azure | 6.19 | 6.11
Core | Azure | 13.50 | 10.69

## Server

### Core
```
cd Core
dotnet restore
dotnet run -c release
```

## OwinHttpListener
```
cd OwinHttpListener
nuget restore ..\packages
msbuild /p:Configuration=Release
bin\Release\OwinHttpListener.exe
```

## Client
```
cd Client
dotnet restore
dotnet run -c release
```
