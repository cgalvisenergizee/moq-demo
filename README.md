# Mocks en pruebas unitarias 

# Crear proyecto base

```bash
# Crear una carpeta para el proyecto
mkdir src && cd src
# Crear solución
dotnet new sln -n MoqDemo
# Crear proyecto de consola con .net
dotnet new console -n Program
# Crear proyecto de pruebas con Nunit
dotnet new nunit -n Tests
# Agregar proyectos a la solución
dotnet sln add Program/Program.csproj
dotnet sln add Tests/Tests.csproj
# Vincular proyecto de pruebas al proyecto base
dotnet add Tests/Tests.csproj reference Program/Program.csproj
# Restaurar paquetes de NuGet
dotnet restore
```