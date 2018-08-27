# Local NuGet Service

![GitHub last commit](https://img.shields.io/github/last-commit/tmvan/LocalNugetService.svg?style=flat-square)
![GitHub top language](https://img.shields.io/github/languages/top/tmvan/LocalNugetService.svg?style=flat-square)
[![GitHub](https://img.shields.io/github/license/tmvan/LocalNugetService.svg?style=flat-square)](https://github.com/tmvan/LocalNugetService/blob/master/LICENSE)

Run NuGet Server as a Windows service.

## Releases

|  | `version` | `release date` |
|-|-|-|
| **`release`** | [![GitHub release](https://img.shields.io/github/release/tmvan/LocalNugetService.svg?style=flat-square)](https://github.com/tmvan/LocalNugetService/releases) | ![GitHub Release Date](https://img.shields.io/github/release-date/tmvan/LocalNugetService.svg?style=flat-square) |
| **`(pre-)release`** | [![GitHub (pre-)release](https://img.shields.io/github/release/tmvan/LocalNugetService/all.svg?style=flat-square)](https://github.com/tmvan/LocalNugetService/releases) | ![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/tmvan/LocalNugetService.svg?style=flat-square) |

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
