using GestaoOscAPI.Models.Entities;

namespace GestaoOscAPI.Repositories
{
    public class OscRepository
    {
        private List<Osc> oscs;

        public OscRepository()
        {
            oscs = new List<Osc>();
        }

        public List<Osc> ListarTodas()
        {
            return oscs;
        }

        public Osc? BuscarPorId(int id)
        {
            return oscs.FirstOrDefault(osc => osc.Id == id);
        }

        public bool Adicionar(Osc osc)
        {
            oscs.Add(osc);
            return true;
        }

        public bool Atualizar(Osc osc)
        {
            var index = oscs.FindIndex(o => o.Id == osc.Id);

            if (index == -1)
            {
                return false;
            }

            oscs[index] = osc;
            return true;
        }

        public bool Deletar(int id)
        {
            Osc? osc = oscs.FirstOrDefault(osc => osc.Id == id);

            if (osc == null)
                return false;

            oscs.Remove(osc);
            return true;
        }


    }
}
