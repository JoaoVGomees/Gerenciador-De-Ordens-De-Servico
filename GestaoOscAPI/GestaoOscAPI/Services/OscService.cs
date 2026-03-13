using GestaoOscAPI.Repositories;
using GestaoOscAPI.Models.Enums;
using GestaoOscAPI.Models.Entities;

namespace GestaoOscAPI.Services
{
    public class OscService
    {
        private readonly OscRepository oscRepository;

        public OscService(OscRepository oscRepository)
        {
            this.oscRepository = oscRepository;
        }

        public Osc CriarOsc(string descricao, string equipamento, 
            Usuario gerenteQualidade,
            Usuario gerenteEngenharia,
            Usuario gerenteProducao,
            Usuario usuarioLogado
            )
        {
            Osc osc = new Osc 
            {
                Descricao = descricao,
                Equipamento = equipamento,
                DataEmissao = DateTime.Now,
                EmitenteId = usuarioLogado.Id,
                EmitenteNome = usuarioLogado.Nome,
                EmitenteSetor = usuarioLogado.Setor.ToString(),
                GerenteQualidade = gerenteQualidade,
                GerenteEngenharia = gerenteEngenharia,
                GerenteProducao = gerenteProducao,

            };

            oscRepository.Adicionar(osc);
            return osc;
        } 

        public List<Osc> ListarTodas()
        {
            return oscRepository.ListarTodas();
        }

        public Osc? BuscarPorId(int id)
        {
            return oscRepository.BuscarPorId(id);
        }

        public bool Atualizar(Osc osc)
        {
            return oscRepository.Atualizar(osc);
        }

        public bool Cancelar(int id)
        {
            Osc? osc = oscRepository.BuscarPorId(id);

            if (osc == null)
                return false;

            osc.Status = StatusOsc.Cancelada;
            return oscRepository.Atualizar(osc);
        }

        public bool Deletar (int id)
        {
            return oscRepository.Deletar(id);
        }
    }
}
