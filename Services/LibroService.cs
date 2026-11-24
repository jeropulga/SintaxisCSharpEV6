public class LibroService
{
    private readonly List<Libro> libros = new();

    public void AgregarLibro(Libro libro) { ArgumentNullException.ThrowIfNull(libro); libros.Add(libro); }
    public bool EliminarLibro(int id) { var libro = BuscarPorId(id); return libro is not null && libros.Remove(libro); }
    public List<Libro> ObtenerTodos() => libros.ToList();
    public Libro? BuscarPorId(int id) => libros.FirstOrDefault(l => l.Id == id);
    public Libro? BuscarPorISBN(string isbn) => libros.FirstOrDefault(l => string.Equals(l.ISBN, isbn, StringComparison.OrdinalIgnoreCase));
    public List<Libro> BuscarPorTitulo(string texto) => libros.Where(l => l.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Libro> BuscarPorAutor(string texto) => libros.Where(l => l.Autor.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Libro> OrdenarPorTitulo() => libros.OrderBy(l => l.Titulo, StringComparer.OrdinalIgnoreCase).ToList();
    public int TotalLibros() => libros.Count;
    public int TotalDisponibles() => libros.Count(l => l.Disponible);
    public int TotalPrestados() => libros.Count(l => !l.Disponible);
}
