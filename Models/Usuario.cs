using System;

public class Usuario
{
    public int Id { get; set; }
    public string Documento { get; set; }
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public bool Activo { get; set; }

    public Usuario()
    {
        Documento = string.Empty;
        Nombre = string.Empty;
        Contacto = string.Empty;
        Activo = true;
    }

    public Usuario(int id, string documento, string nombre, string contacto, bool activo = true)
    {
        Id = id;
        Documento = documento;
        Nombre = nombre;
        Contacto = contacto;
        Activo = activo;
    }

    public string ResumenCorto() => $"{Id} - {Nombre} ({Documento})";

    public string DetalleCompleto() =>
        $"ID: {Id}{Environment.NewLine}" +
        $"Documento: {Documento}{Environment.NewLine}" +
        $"Nombre: {Nombre}{Environment.NewLine}" +
        $"Contacto: {Contacto}{Environment.NewLine}" +
        $"Activo: {Activo}";

    public override string ToString() => ResumenCorto();
}
