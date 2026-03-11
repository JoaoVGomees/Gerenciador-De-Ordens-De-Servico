using GestaoOscAPI.Models.Entities;
using GestaoOscAPI.Models.Enums;

namespace GestaoOscAPI.Repositories
{
    public class UsuarioRepository
    {
        private List<Usuario> usuarios;

        public UsuarioRepository() 
        {
            usuarios = new List<Usuario>() {
            new Usuario
            {
                Id = 1,
                Nome = "Admin1",
                Email = "admin1@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Administrador,
                Setor = Setor.Nenhum
            },

            new Usuario
            {
                Id = 2,
                Nome = "Admin2",
                Email = "admin2@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Administrador,
                Setor = Setor.Nenhum
            },

            new Usuario
            {
                Id = 3,
                Nome = "Emitente",
                Email = "emitente2@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Emitente,
                Setor = Setor.Nenhum
            },

            new Usuario
            {
                Id = 4,
                Nome = "Gerente Qualidade",
                Email = "gerente_qualidade@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Gerente,
                Setor = Setor.Qualidade
            },
            new Usuario
            {
                Id = 5,
                Nome = "Gerente Engenharia",
                Email = "gerente_engenharia@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Gerente,
                Setor = Setor.Engenharia
            },
            new Usuario
            {
                Id = 6,
                Nome = "Gerente Produção",
                Email = "gerente_producao@osc.com",
                Senha = "123456",
                Perfil = PerfilUsuario.Gerente,
                Setor = Setor.Producao
            }
                };
        }

        public List<Usuario> ListarTodos()
        {
            return usuarios;
        }

        public Usuario? BuscarPorId(int id)
        {
            return usuarios.FirstOrDefault(usuario => usuario.Id == id);
        }

        public Usuario? BuscarPorEmail(string email)
        {
            return usuarios.FirstOrDefault(usuario => usuario.Email.Equals(email));
        }

        public List<Usuario> BuscarPorSetor(Setor setor)
        {
            return usuarios.Where(usuario => usuario.Setor == setor).ToList();
        }

        public bool Deletar(int id)
        {
            Usuario? usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return false;

            usuarios.Remove(usuario);
            return true;
        }
    }
}
