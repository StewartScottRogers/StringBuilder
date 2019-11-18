$ScriptDir = Split-Path $script:MyInvocation.MyCommand.Path
Write-Host "Current script directory is $ScriptDir"
dotnet nuget push $ScriptDir\TemplateBuilder\bin\Release\TemplateBuilder.1.0.1.nupkg -k oy2etn3zxhpc5ic6pzeaov2griugaotexhqqsjqckkk5ya -s https://api.nuget.org/v3/index.json
