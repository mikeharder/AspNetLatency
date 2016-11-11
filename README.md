# AspNetLatency

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
nuget restore
msbuild /p:Configuration=Release
bin\Release\OwinHttpListener.exe
```

## Client
```
cd Client
dotnet restore
dotnet run -c release
```
