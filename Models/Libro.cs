using System;

public class Libro
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Anio { get; set; }
    public string Categoria { get; set; }
    public bool Disponible { get; set; }

    public Libro()
    {
        ISBN = string.Empty;
        Titulo = string.Empty;
        Autor = string.Empty;
        Categoria = string.Empty;
        Disponible = true;
    }

    public Libro(int id, string isbn, string titulo, string autor, int anio, string categoria, bool disponible = true)
    {
        Id = id;
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        Anio = anio;
        Categoria = categoria;
        Disponible = disponible;
    }

    public string ResumenCorto() => $"{Id} - {Titulo} ({Autor})";

    public string DetalleCompleto() =>
        $"ID: {Id}{Environment.NewLine}" +
        $"ISBN: {ISBN}{Environment.NewLine}" +
        $"Título: {Titulo}{Environment.NewLine}" +
        $"Autor: {Autor}{Environment.NewLine}" +
        $"Año: {Anio}{Environment.NewLine}" +
        $"Categoría: {Categoria}{Environment.NewLine}" +
        $"Disponible: {Disponible}";

    public override string ToString() => ResumenCorto();
}
