# ficha_tramite_webapi

Definir Definir Definir Definir Definir

## Especificaciones Técnicas

### Tecnologías Implementadas y Versiones
* [.NET core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)

### Variables de Entorno
```shell
# En Pipeline
SLACK_AND_WEBHOOK: WEBHOOK de Slack Grupo ci-covid-serverles
AWS_ACCESS_KEY_ID: llave de acceso ID Usuario AWS
AWS_SECRET_ACCESS_KEY: Secreto de Usuario AWS
```

### Ejecución del Proyecto

#### Ejecución Dockerfile
```bash
docker build --tag=ficha_tramite_webapi . --no-cache
docker run -p 80:80 ficha_tramite_webapi
```
#### Ejecución docker-compose
```bash
# Ambiente DEV
docker-compose -f docker-compose.development.yml up -d

# Ambiente QA
docker-compose -f docker-compose.staging.yml up -d

# Ambiente Producción
docker-compose up -d

# Navegar a
http://localhost:8084
```

#### Restaurar backups de base de datos MASTERGOVCO y SUIT3 (Despues validar la conexion a BD)
(Ejecutar unicamente la primera vez que ejecute el contenedor de base de datos)
```bash
chmod +x ./sqlserver/init/init.sh
docker exec -it tramites_y_servicios_db /var/opt/mssql/backup/init.sh
```
####

## Ejecución Pruebas
### Pruebas Unitarias
```bash
dotnet test
```

## Licencia

This file is part of ficha_tramite_webapi.

ficha_tramite_webapi is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

ficha_tramite_webapi is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with ficha_tramite_webapi. If not, see https://www.gnu.org/licenses/.
