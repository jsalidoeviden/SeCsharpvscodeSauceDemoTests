# CreateFiles.ps1
$files = @(
    "SauceDemoAutomation/appsettings.json",
    "SauceDemoAutomation/Driver/WebDriverFactory.cs",
    "SauceDemoAutomation/Pages/BasePage.cs",
    "SauceDemoAutomation/Pages/LoginPage.cs",
    "SauceDemoAutomation/Pages/InventoryPage.cs",
    "SauceDemoAutomation/Pages/CartPage.cs",
    "SauceDemoAutomation/Tests/LoginTests.cs",
    "SauceDemoAutomation/Tests/InventoryTests.cs",
    "SauceDemoAutomation/Tests/CartTests.cs"
)

foreach ($file in $files) {
    if (-Not (Test-Path -Path $file)) {
        New-Item -ItemType File -Path $file -Force
        Write-Host "Archivo creado: $file"
    } else {
        Write-Host "El archivo ya existe: $file"
    }
}
