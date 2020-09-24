## Csharp 1

Contiene la versión inicial

## Csharp 2

* Eliminada clase `FiguresCollection`
* Propiedades `public get` / `protected set` en `FiguraBase`
* Uso de `Nullable<double>` en Area

### Funcionales

* Ahora el texto no cuenta para el cálculo de área.

## Csharp 3

* Uso de LINQ para el comando de áreas
* Uso de LINQ para dibujar los cuadrados
* Uso de `var` y objetos anónimos
* Propiedades auto-implementadas
* Uso de métodos de extensión

### Funcionales

Nuevo comando `SetNextColor` (`p`) que itera sobre el color actual de la figura.

## Csharp 4

* Uso de parámetros opcionales en `Engine.DrawStatus`
* Uso de parámetros nombrados en algunas llamadas
* Uso de `dynamic` en `AdditionalCommands.Save`

### Funcionales

* Nuevo comando extendido (`:w`) para guardar el dibujo
* Nuevo comando extendido (`:q`) para salir

> Los comandos extendidos se pueden combinar. Sí... eso hace `:wq` xD

## Csharp 5

* Uso de async/await

## Csharp 6

* Uso de _null propagator_ (`?.`)
* Uso de _readonly properties_ en `CSize` y `CPoint`.
* Uso de interpolación de cadenas
* Uso de _static import_ en `Engine`.

## Csharp 7.0

**Refactoring de los comandos, basados en delegados.**

* Uso de _out variables_ en `Engine` (llamadas a `int.TryParse`)
* Uso de _pattern matching_ (`BasicCommands.AreaCountCommand`)
* Uso de funciones locales (`BasicCommands.InsertCommand`)
* Uso de _throw expressions_ (`CSize`, `CPoint`)
* Uso de tuplas (`AreasExtensions.CalculateStatistics`)

### Funcionales

Nuevo comando de contar area (`C`). Devuelve # figuras con área menor, igual o superior a la indicada.

## Csharp 7.1

* Uso de `async Main`
* Uso de _default literal expressions_ (`DictionaryExtensions.GetOrDefault`)

## Csharp 7.2

* Uso de _non trailing named arguments_ (`CreateSquare, CreateText`)
* Uso de parámetros `in` (`Square.ctor`,  `Text.ctor`)

