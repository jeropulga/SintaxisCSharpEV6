public class UsuarioService
{
    private readonly List<Usuario> usuarios = new();

    public void AgregarUsuario(Usuario usuario) { ArgumentNullException.ThrowIfNull(usuario); usuarios.Add(usuario); }
    public bool EliminarUsuario(int id) { var usuario = BuscarPorId(id); return usuario is not null && usuarios.Remove(usuario); }
    public List<Usuario> ObtenerTodos() => usuarios.ToList();
    public Usuario? BuscarPorId(int id) => usuarios.FirstOrDefault(u => u.Id == id);
    public Usuario? BuscarPorDocumento(string documento) => usuarios.FirstOrDefault(u => string.Equals(u.Documento, documento, StringComparison.OrdinalIgnoreCase));
    public List<Usuario> BuscarPorNombre(string texto) => usuarios.Where(u => u.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Usuario> OrdenarPorNombre() => usuarios.OrderBy(u => u.Nombre, StringComparer.OrdinalIgnoreCase).ToList();
    public int TotalUsuarios() => usuarios.Count;
    public int TotalActivos() => usuarios.Count(u => u.Activo);
    public int TotalInactivos() => usuarios.Count(u => !u.Activo);
}
