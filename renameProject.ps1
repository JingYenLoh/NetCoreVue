param(
[string]$projectName
)

$files = Get-ChildItem . *.* -rec -Attributes !D
foreach ($file in $files)
{
    (Get-Content $file.PSPath) |  Foreach-Object { $_ -replace "NetCoreVue", $projectName } |  Set-Content $file.PSPath
}

Rename-Item .\NetCoreVue.csproj $projectName".csproj"
Rename-Item .\NetCoreVue.sln $projectName".sln"
