# SeCsharpvscodeSauceDemoTests

Este proyecto es un framework de automatización de pruebas en C# utilizando Selenium para probar la aplicación web SauceDemo.com Está diseñado para ejecutarse en Visual Studio Code y proporciona un conjunto de pruebas automatizadas para validar la funcionalidad de la plataforma.

## Tecnologías Utilizadas

- **C#**: Lenguaje principal para el desarrollo de las pruebas.
- **Selenium WebDriver**: Para la automatización de pruebas UI.
- **XUnit**: Framework de pruebas unitarias en C#.
- **WebDriverManager**: Para la gestión automática de drivers de navegador.
- **Appsettings.json**: Para la configuración de las pruebas.

## Instalación

1. **Clona el repositorio:**
   ```sh
   git clone https://github.com/jsalidoeviden/SeCsharpvscodeSauceDemoTests.git
   ```
2. **Abre el proyecto en Visual Studio Code.**
3. **Instala los paquetes necesarios:**
   ```sh
   dotnet restore
   ```
4. **Configura `appsettings.json` si es necesario.**

## Ejecución de Pruebas

Para ejecutar las pruebas, usa el siguiente comando:
```sh
   dotnet test
```

### Ejecución en Paralelo
Para ejecutar las pruebas en paralelo, asegúrate de que XUnit está configurado para ello en `xunit.runner.json`.


## Estructura del Proyecto
```
SeCsharpvscodeSauceDemoTests/
│── Pages/              # Implementación del modelo Page Object
│── Tests/              # Clases de pruebas automatizadas
│── Utilities/          # Clases auxiliares (gestión de WebDrivers, configuración, etc.)
│── appsettings.json    # Configuración del framework
│── README.md           # Documentación del proyecto
│── .gitignore          # Archivos ignorados por Git
```

## Contribución
Si deseas contribuir a este proyecto:
1. Realiza un fork del repositorio.
2. Crea una nueva rama con tu mejora o corrección.
3. Envía un Pull Request para revisión.

## Contacto
Para cualquier consulta o sugerencia, puedes abrir un issue en este repositorio.

---
¡Gracias por contribuir y usar este framework de automatización de pruebas! 🚀
