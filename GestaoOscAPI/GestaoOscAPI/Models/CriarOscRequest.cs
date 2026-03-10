namespace GestaoOscAPI.Models
{
    public class CriarOscRequest 
    {
        public string descricao { get; set; } = string.Empty;
        public string Equipamento { get; set; } = string.Empty;
        public int GerenteQualidadeId { get; set; }
        public int GerenteEngenhariaId { get; set; }
        public int GerenteProducaoId { get; set; }
        public int UsuarioLogadoId { get; set; }

    }
}

