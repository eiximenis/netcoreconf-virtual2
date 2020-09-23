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
