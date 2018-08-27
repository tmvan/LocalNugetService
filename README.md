# Local NuGet Service

Run NuGet Server as a Windows service.

## Prerequisites

* Windows OS
* .NET Framework 4.6.1

## How to run

* Build solution in `Release` mode.
* (Optional) Copy all files and folders inside `bin\Release` to somewhere.
* Go to `Release` folder (or place where you've copied these fileds) and open `cmd` or `powershell` here.
* Run file `install.cmd`. Now, the server is running at `http://localhost:9028/`. Open brower and go to `http://localhost:9028/nuget` to verify.

## Configuration

To configure the app, open configuration file and edit these settings:
```xml
<appSettings>
    <!-- The port your website will be run on -->
    <add key="port" value="9028" /> 

    <!-- Default NuGet.Server settings. See this article: https://docs.microsoft.com/en-us/nuget/hosting-packages/nuget-server  -->
    <add key="packagesPath" value="C:\.LocalNuGet" />
    <add key="requireApiKey" value="false" />
    <add key="apiKey" value="" />
    <!-- ./Default NuGet.Server settings. -->
</appSettings>
```