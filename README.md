# Sistema de Biblioteca EV08

Proyecto C# existente ampliado para la actividad EV08. Conserva los menús previos y agrega servicios con `List<T>` para libros, usuarios y préstamos.

## Abrir y ejecutar en Visual Studio Code

1. Extrae el ZIP.
2. En Visual Studio Code, selecciona **Archivo > Abrir carpeta** y elige `SistemaBibliotecaEV08`.
3. Abre la terminal integrada y ejecuta `dotnet run`.
4. En el menú, selecciona **6. Demostración EV08 (servicios)**.

Requiere el SDK de .NET 10. La opción 7 cierra el programa.

## Qué demuestra

- Array de tamaño fijo frente a `List<T>` dinámica.
- Búsquedas de libro, usuario y préstamo.
- Ordenamientos por título, nombre y fecha límite.
- KPIs de disponibilidad, actividad, estados de préstamos y promedio de días.
- Registro de devolución y actualización de disponibilidad.

La salida de una ejecución está en `evidencias/ev08-ejecucion.txt`.

## Video requerido por la guía

La guía de la EV08 también pide entregar un video de YouTube que demuestre todas las funcionalidades. El código y la evidencia de consola están preparados; debes grabar la demostración y subir el video por separado.

## Git Flow

El repositorio conserva las ramas de trabajo y sus merges locales a `develop`. Consulta `EV08.md` para ver las ramas creadas para esta actividad.
