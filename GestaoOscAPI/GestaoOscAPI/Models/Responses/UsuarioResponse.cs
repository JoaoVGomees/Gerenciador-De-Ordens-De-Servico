using GestaoOscAPI.Models.Enums;

namespace GestaoOscAPI.Models.Responses
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public PerfilUsuario Perfil { get; set; }
        public Setor Setor { get; set; }
    }
}
