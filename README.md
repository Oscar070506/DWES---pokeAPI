# Proyecto PokéApi
Este proyecto trata de un programa utilizado por consola y basado en C# donde utilizamos una api de pokemon para filtrar y crear un buscador de pokemons de la primera genración a la vez que bayas de la misma. El usuario puede filtrar por una serie de caraterísticas para encontrar lo que busca.

## Requisitos e instalación
Es necesario tener instalado C# y a ser posible una IDE donde ejecutarlo de forma cómoda. La estructura de carpetas no se puede cambiar para que el proyecto funcione.

### Estructura del proyecto

    └── PokeAPI/                 # Proyecto principal en C#

        ├── bin/                 # Archivos compilados (generados automáticamente)

        ├── obj/                 # Archivos temporales de compilación

        ├── PokeAPI.csproj       # Archivo de configuración del proyecto C#

        ├── Program.cs           # Punto de entrada principal de la aplicación

        ├── Todo.cs              # Modelo o clase auxiliar (por ejemplo, para pruebas o estructura base)

        ├── Moves.cs             # Clase que gestiona los movimientos de los Pokémon

        ├── PokeAPI.sln          # Archivo de solución (Visual Studio)
    
        └── README.md            # Documentación del proyecto

## Funcionalidades principales

- Buscar Pokémons de la primera generación por Nombre, Nº de Pokédex y Tipo.
- Buscar Bayas por Nombre, Sabor y Color.

## Teconologías utilizadas

- Lenguaje:C#
- Framework: .NET 6
- API: https://pokeapi.co/docs/v2
- IDE: Visual Studio Code

## Ejemplo de uso
#Ejecutar el proyecto:

dotnet run

#Elegir opción del menú principal:

=========== MENÚ PRINCIPAL ===========
1. Pokédex de Universal
2. Jardín de Bayas
3. Salir


#Seleccionar búsqueda (por ejemplo, Pokémon por tipo “fire”):

============== PokeMENÚ ==============
¿Cómo quieres buscar?
1. Por Nombre
2. Por Pokédex ID
3. Por Tipo
4. Salir

#El programa devolverá información completa de todos los Pokémon de tipo primario elegido.




