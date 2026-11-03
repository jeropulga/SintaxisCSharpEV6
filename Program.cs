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

    private static void ShowBooksMenu() => ShowAction("Abrir menú de libros.");
    private static void ShowUsersMenu() => ShowAction("Abrir menú de usuarios.");
    private static void ShowLoansMenu() => ShowAction("Abrir menú de préstamos.");
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
