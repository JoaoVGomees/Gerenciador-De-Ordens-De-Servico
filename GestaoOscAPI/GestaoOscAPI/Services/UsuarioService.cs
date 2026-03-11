using GestaoOscAPI.Repositories;
using GestaoOscAPI.Models.Enums;
using GestaoOscAPI.Models.Entities;

namespace GestaoOscAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Usuario? ValidarLogin(string email, string senha)
        {
            Usuario? user = usuarioRepository.BuscarPorEmail(email);

            if (user == null || user.Senha != senha)
            {
                return null;
            }
            return user;
            
        }

        public Usuario? BuscarPorId(int id)
        {
            return usuarioRepository.BuscarPorId(id);
        }

        public Usuario? BuscarPorEmail(string email)
        {
            return usuarioRepository.BuscarPorEmail(email);
        }

        public List<Usuario> BuscarPorSetor(Setor setor)
        {
            return usuarioRepository.BuscarPorSetor(setor);
        }

        public bool Deletar(int id)
        {
            return usuarioRepository.Deletar(id);
        }
    }
}
