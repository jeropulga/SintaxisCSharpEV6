using System;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        Libro = new Libro();
        Usuario = new Usuario();
        FechaPrestamo = DateTime.Today;
        FechaVencimiento = DateTime.Today;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(
        int id,
        Libro libro,
        Usuario usuario,
        DateTime fechaPrestamo,
        DateTime fechaVencimiento,
        DateTime? fechaDevolucion = null)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaVencimiento;
        FechaDevolucion = fechaDevolucion;
        Estado = EstadoPrestamo.Activo;
    }

    public bool EstaVencido() =>
        Estado == EstadoPrestamo.Activo &&
        FechaDevolucion is null &&
        DateTime.Today > FechaVencimiento.Date;

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = (FechaDevolucion ?? DateTime.Today).Date;
        return (fechaFinal - FechaPrestamo.Date).Days;
    }

    public string ResumenCorto() =>
        $"Préstamo {Id}: {Libro.Titulo} para {Usuario.Nombre} - {Estado}";

    public string DetalleCompleto() =>
        $"ID: {Id}{Environment.NewLine}" +
        $"Libro: {Libro.ResumenCorto()}{Environment.NewLine}" +
        $"Usuario: {Usuario.ResumenCorto()}{Environment.NewLine}" +
        $"Fecha de préstamo: {FechaPrestamo:dd/MM/yyyy}{Environment.NewLine}" +
        $"Fecha de vencimiento: {FechaVencimiento:dd/MM/yyyy}{Environment.NewLine}" +
        $"Fecha de devolución: {(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente")}{Environment.NewLine}" +
        $"Estado: {Estado}{Environment.NewLine}" +
        $"Está vencido: {EstaVencido()}{Environment.NewLine}" +
        $"Días transcurridos: {DiasTranscurridos()}";

    public override string ToString() => ResumenCorto();
}
