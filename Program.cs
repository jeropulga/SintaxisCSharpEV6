using System;

internal static class Program
{
    private static void Main()
    {
        ShowMainMenu();
    }

    private static void ShowMainMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n=== Menú principal ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");

            switch (ReadOption("Seleccione una opción: ", 1, 6))
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowPersistenceMenu(); break;
                case 6: salir = ConfirmExitAndSave(); break;
            }
        }
    }

    private static int ReadOption(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int option) && option >= minimum && option <= maximum)
                return option;

            Console.WriteLine("Opción no válida. Intente nuevamente.");
        }
    }

    private static void ShowBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Libros ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 5))
            {
                case 0: volver = true; break;
                case 1: RegisterBook(); break;
                case 2: ListBooksMenu(); break;
                case 3: ViewBookDetail(); break;
                case 4: UpdateBookMenu(); break;
                case 5: DeleteBook(); break;
            }
        }
    }

    private static void ListBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Listar libros ===");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 3))
            {
                case 0: volver = true; break;
                case 1: ListBooksAll(); break;
                case 2: ListBooksAvailable(); break;
                case 3: ListBooksBorrowed(); break;
            }
        }
    }

    private static void UpdateBookMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Actualizar libro ===");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 3))
            {
                case 0: volver = true; break;
                case 1: EditBookTitle(); break;
                case 2: EditBookAuthor(); break;
                case 3: EditBookYearCategory(); break;
            }
        }
    }

    private static void RegisterBook() => ShowAction("Registrar libro.");
    private static void ListBooksAll() => ShowAction("Listar todos los libros.");
    private static void ListBooksAvailable() => ShowAction("Listar libros disponibles.");
    private static void ListBooksBorrowed() => ShowAction("Listar libros prestados.");
    private static void ViewBookDetail() => ShowAction("Ver detalle de libro por ID/ISBN.");
    private static void EditBookTitle() => ShowAction("Editar título del libro.");
    private static void EditBookAuthor() => ShowAction("Editar autor del libro.");
    private static void EditBookYearCategory() => ShowAction("Editar año / categoría del libro.");
    private static void DeleteBook() => ShowAction("Eliminar libro. Validar no permitir si está prestado.");

    private static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Usuarios ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle (por ID/documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 5))
            {
                case 0: volver = true; break;
                case 1: RegisterUser(); break;
                case 2: ListUsers(); break;
                case 3: ViewUserDetail(); break;
                case 4: UpdateUserMenu(); break;
                case 5: DeleteUser(); break;
            }
        }
    }

    private static void UpdateUserMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Actualizar usuario ===");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 3))
            {
                case 0: volver = true; break;
                case 1: EditUserName(); break;
                case 2: EditUserContact(); break;
                case 3: ToggleUserActiveStatus(); break;
            }
        }
    }

    private static void RegisterUser() => ShowAction("Registrar usuario.");
    private static void ListUsers() => ShowAction("Listar usuarios.");
    private static void ViewUserDetail() => ShowAction("Ver detalle de usuario por ID/documento.");
    private static void EditUserName() => ShowAction("Editar nombre del usuario.");
    private static void EditUserContact() => ShowAction("Editar contacto del usuario.");
    private static void ToggleUserActiveStatus() => ShowAction("Activar / desactivar usuario.");
    private static void DeleteUser() => ShowAction("Eliminar usuario. Validar no permitir si tiene préstamos activos.");

    private static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Préstamos ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle de préstamo (por ID)");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 5))
            {
                case 0: volver = true; break;
                case 1: CreateLoan(); break;
                case 2: ListLoansMenu(); break;
                case 3: ViewLoanDetail(); break;
                case 4: RegisterReturn(); break;
                case 5: DeleteLoan(); break;
            }
        }
    }

    private static void ListLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n=== Listar préstamos ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");

            switch (ReadOption("Seleccione una opción: ", 0, 3))
            {
                case 0: volver = true; break;
                case 1: ListLoansAll(); break;
                case 2: ListLoansActive(); break;
                case 3: ListLoansClosed(); break;
            }
        }
    }

    private static void CreateLoan()
    {
        ShowAction("Crear préstamo (simulación).");
        Console.WriteLine("Validaciones sugeridas: usuario activo, libro disponible y datos requeridos.");
    }

    private static void ListLoansAll() => ShowAction("Listar todos los préstamos.");
    private static void ListLoansActive() => ShowAction("Listar préstamos activos.");
    private static void ListLoansClosed() => ShowAction("Listar préstamos cerrados.");
    private static void ViewLoanDetail() => ShowAction("Ver detalle del préstamo por ID.");
    private static void RegisterReturn() => ShowAction("Registrar devolución: marcar devuelto y libro disponible.");
    private static void DeleteLoan() => ShowAction("Eliminar préstamo. Aplicar reglas sugeridas para su eliminación.");

    private static void ShowSearchReportsMenu() => ShowAction("Abrir menú de búsquedas y reportes.");
    private static void ShowPersistenceMenu() => ShowAction("Abrir menú de guardar / cargar datos.");

    private static bool ConfirmExitAndSave()
    {
        ShowAction("Salir del programa.");
        return true;
    }

    private static void ShowAction(string message)
    {
        Console.WriteLine($"Acción seleccionada: {message}");
    }
}
