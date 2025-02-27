# CreateFolders.ps1
$folders = @(
    "SauceDemoAutomation",
    "SauceDemoAutomation/Driver",
    "SauceDemoAutomation/Pages",
    "SauceDemoAutomation/Tests",
    "SauceDemoAutomation/Reports"
)

foreach ($folder in $folders) {
    if (-Not (Test-Path -Path $folder)) {
        New-Item -ItemType Directory -Path $folder -Force
        Write-Host "Carpeta creada: $folder"
    } else {
        Write-Host "La carpeta ya existe: $folder"
    }
}
