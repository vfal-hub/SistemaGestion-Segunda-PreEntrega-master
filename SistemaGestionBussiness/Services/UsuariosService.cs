using SistemaGestionData.DataAccess;
using SistemaGestionEntities;

namespace SistemaGestionBussiness.Services;

public class UsuariosService
{
    private UsuariosDataAccess _usuariosDataAccess;

    public UsuariosService(UsuariosDataAccess usuariosDataAccess)
    {
        _usuariosDataAccess = usuariosDataAccess;
    }

    public List<Usuario> ListUsers()
    {
        return _usuariosDataAccess.ListUsers();
    }

    public Usuario? GetOneUser(int id)
    {
        return _usuariosDataAccess.GetOneUser(id);
    }

    public Usuario CreateUser(Usuario usuario)
    {
        return _usuariosDataAccess.CreateUser(usuario);
    }

    public void UpdateUser(int id, Usuario usuario)
    {
        _usuariosDataAccess.UpdateUser(id, usuario);
    }

    public void DeleteUser(int id)
    {
        _usuariosDataAccess.DeleteUser(id);
    }

    public List<Usuario> GetUserBy(string filtro)
    {
        return _usuariosDataAccess.GetUserBy(filtro);
    }

}

