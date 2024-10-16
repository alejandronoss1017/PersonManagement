# Person Management

Solución de software para gestión de personas, sus datos personales, contactos y la educación que han recibido.

## Descripción

PersonManagement es una solución que consta de un proyecto MVC:

- **PersonManagement.WebApp**: Una aplicación web que permite gestionar personas, sus datos personales, contactos y la educación que han recibido.

## Stack Tecnológico

- [.NET](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/es-co/sql-server)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

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
    http://localhost:5178
    ```

4. Accede al los servicios de la API en tu navegador:
    ```
    http://localhost:5178/swagger
    ```

5. Para detener los contenedores:
    ```sh
    docker-compose down
    ```

## Autores

- [@alejandronoss1017](https://github.com/alejandronoss1017)
- [@carlosantiagorojas](https://github.com/carlosantiagorojas)
- [@StiivenOrtiz](https://github.com/StiivenOrtiz)

