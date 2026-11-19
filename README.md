# rhubarb-geek-nz/DeAmsify
DeAmsify for PowerShell

## Introduction
Disable method invocation logging.

Inspired by [PowerShell sans AMSI](https://github.com/PowerShell/PowerShell/discussions/24750#discussioncomment-18392713)

## Build
Build module and sign, use your own code signing certificate thumbprint.

```
dotnet publish --configuration Release --property CertificateThumbprint=601A8B683F791E51F647D34AD102C38DA4DDB65F
```

## Installation
Install module with

```
Install-Module -Name 'rhubarb-geek-nz.DeAmsify'
```

Add the following to your `$PROFILE`

```
Import-Module -Name 'rhubarb-geek-nz.DeAmsify'
```

## Testing
Compare the `benchmark.ps1` from [powershell-amsi](https://github.com/rhubarb-geek-nz/powershell-amsi) with and without the module imported.
