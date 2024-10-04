# Person Management

Solución de software para gestión de personas, sus datos personales, contactos y la educación que han recibido.

## Descripción

PersonManagement es una solución que consta de dos proyectos:

1. **PersonManagement.API**: Un proyecto de API que proporciona endpoints para gestionar personas.
2. **PersonManagement.Web**: Una aplicación web que consume la API y proporciona una interfaz de usuario para gestionar personas.

## Stack Tecnológico

- [.NET](https://dotnet.microsoft.com/en-us/download)
- [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [SQL Server](https://www.microsoft.com/es-co/sql-server)

## Ejecución de la solución con Docker Compose

Para ejecutar la solución completa utilizando Docker Compose, sigue estos pasos:

1. Clona el repositorio:
    ```sh
    git clone https://github.com/alejandronoss1017/PersonManagement.git
    cd PersonManagement
    ```

2. Construye y levanta los contenedores:
    ```sh
    docker-compose up --build
    ```

3. Accede a la aplicación web en tu navegador:
    ```
    http://localhost:5279
    ```

4. Accede a la documentación de la API, con tu navegador:
    ```
    http://localhost:5295/swagger/index.html
    ```

5. Para detener los contenedores:
    ```sh
    docker-compose down
    ```

## Autores

- [@alejandronoss1017](https://github.com/alejandronoss1017)
- [@carlosantiagorojas](https://github.com/carlosantiagorojas)
- [@StiivenOrtiz](https://github.com/StiivenOrtiz)

