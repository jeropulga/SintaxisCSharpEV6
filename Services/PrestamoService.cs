public class PrestamoService
{
    private readonly List<Prestamo> prestamos = new();

    public void AgregarPrestamo(Prestamo prestamo) { ArgumentNullException.ThrowIfNull(prestamo); prestamos.Add(prestamo); }
    public bool EliminarPrestamo(int id) { var prestamo = BuscarPorId(id); return prestamo is not null && prestamos.Remove(prestamo); }
    public List<Prestamo> ObtenerTodos() => prestamos.ToList();
    public Prestamo? BuscarPorId(int id) => prestamos.FirstOrDefault(p => p.Id == id);
    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado) => prestamos.Where(p => EstadoActual(p) == estado).ToList();
    public List<Prestamo> OrdenarPorFechaLimite() => prestamos.OrderBy(p => p.FechaVencimiento).ToList();

    public bool RegistrarDevolucion(int id, DateTime? fecha = null)
    {
        var prestamo = BuscarPorId(id);
        if (prestamo is null || EstadoActual(prestamo) == EstadoPrestamo.Devuelto) return false;
        prestamo.FechaDevolucion = (fecha ?? DateTime.Today).Date;
        prestamo.Estado = EstadoPrestamo.Devuelto;
        prestamo.Libro.Disponible = true;
        return true;
    }

    public int TotalPrestamos() => prestamos.Count;
    public int TotalActivos() => prestamos.Count(p => EstadoActual(p) == EstadoPrestamo.Activo);
    public int TotalVencidos() => prestamos.Count(p => EstadoActual(p) == EstadoPrestamo.Vencido);
    public int TotalDevueltos() => prestamos.Count(p => EstadoActual(p) == EstadoPrestamo.Devuelto);
    public double PromedioDiasPrestamo() => prestamos.Count == 0 ? 0 : prestamos.Average(p => p.DiasTranscurridos());
    public double PromedioDiasPrestamosDevueltos()
    {
        var devueltos = prestamos.Where(p => EstadoActual(p) == EstadoPrestamo.Devuelto).ToList();
        return devueltos.Count == 0 ? 0 : devueltos.Average(p => p.DiasTranscurridos());
    }

    private static EstadoPrestamo EstadoActual(Prestamo prestamo) =>
        prestamo.FechaDevolucion.HasValue || prestamo.Estado == EstadoPrestamo.Devuelto
            ? EstadoPrestamo.Devuelto
            : prestamo.EstaVencido() || prestamo.Estado == EstadoPrestamo.Vencido
                ? EstadoPrestamo.Vencido
                : EstadoPrestamo.Activo;
}
