# MyMvcApp - Aplicación de Contactos

Esta es una aplicación ASP.NET Core MVC para gestionar una base de datos de contactos.

## Requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio, Visual Studio Code o cualquier editor compatible

## Instalación y ejecución

1. Clona este repositorio o descarga el código fuente.
2. Abre una terminal en la carpeta raíz del proyecto.
3. Restaura las dependencias ejecutando:

```powershell
dotnet restore
```

4. Ejecuta la aplicación con:

```powershell
dotnet run
```

5. Abre tu navegador y accede a `https://localhost:5001` o `http://localhost:5000`.

## Configuración

Puedes modificar la configuración de la base de datos y otros parámetros en los archivos:
- `appsettings.json`
- `appsettings.Development.json`

## Estructura del proyecto

- `Controllers/` - Controladores MVC
- `Models/` - Modelos de datos
- `Views/` - Vistas Razor
- `wwwroot/` - Archivos estáticos (CSS, JS, librerías)

## Notas

- Asegúrate de tener los puertos 5000 y 5001 libres.
- Si usas Visual Studio, también puedes presionar F5 para ejecutar la aplicación.

---

## Despliegue en Azure y CI/CD con GitHub Actions

A continuación se describe cómo desplegar la aplicación en Azure App Service y automatizar el proceso con GitHub Actions.

### 1. Prerrequisitos

- Tener una suscripción activa de Azure.
- Tener una cuenta de GitHub y el repositorio subido.
- Haber creado (o tener) un [Resource Group](https://learn.microsoft.com/es-es/azure/azure-resource-manager/management/manage-resource-groups-portal) en Azure.

### 2. Crear recursos en Azure con ARM Template

1. Ve al [Portal de Azure](https://portal.azure.com/).
2. Busca "Plantillas de implementación" o "Plantillas ARM".
3. Crea una nueva implementación personalizada y selecciona el archivo `azuredeploy.json` incluido en este repositorio.
4. Completa los parámetros requeridos:
   - **Resource Group**: Elige el grupo de recursos.
   - **Nombre del App Service Plan** y **App Service**: Define nombres únicos.
5. Haz clic en "Revisar y crear" y luego en "Crear".

Esto creará el App Service Plan y el App Service donde se desplegará la aplicación.

### 3. Obtener credenciales de publicación (Azure Deployment Credentials)

1. En el portal de Azure, ve a tu App Service.
2. En el menú izquierdo, selecciona **Implementación > Centro de implementación > Credenciales de publicación**.
3. Copia el **Nombre de usuario** y **Contraseña**.

### 4. Configurar secretos en GitHub

1. Ve a tu repositorio en GitHub.
2. Haz clic en **Settings > Secrets and variables > Actions**.
3. Agrega los siguientes secretos:
   - `AZURE_WEBAPP_NAME`: Nombre de tu App Service (por ejemplo, `mymvcapp-contactos`)
   - `AZURE_WEBAPP_PUBLISH_PROFILE`: Copia el contenido del perfil de publicación XML desde Azure (**App Service > Obtener perfil de publicación**)

### 5. Crear el workflow de GitHub Actions

1. En tu repositorio, crea la carpeta `.github/workflows` si no existe.
2. Crea un archivo llamado `azure-webapp-deploy.yml` con el siguiente contenido:

```yaml
name: Deploy ASP.NET Core app to Azure Web App

on:
  push:
    branches:
      - main

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout code
        uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --configuration Release --no-restore

      - name: Publish
        run: dotnet publish -c Release -o ./publish

      - name: Deploy to Azure Web App
        uses: azure/webapps-deploy@v3
        with:
          app-name: ${{ secrets.AZURE_WEBAPP_NAME }}
          publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
          package: ./publish
```

### 6. Probar el despliegue automático

1. Haz un commit y push a la rama `main`.
2. Ve a la pestaña **Actions** en GitHub y verifica que el workflow se ejecute correctamente.
3. Una vez finalizado, tu aplicación estará disponible en la URL de tu App Service de Azure.

---

Con estos pasos, tu aplicación se desplegará automáticamente en Azure cada vez que hagas push a la rama principal.
