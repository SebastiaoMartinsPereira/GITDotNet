using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Filtro
{
    public abstract class Filtro
    {
        protected Filtro ProximoFiltro { get; set; }

        public Filtro(Filtro proximoFiltro) { this.ProximoFiltro = proximoFiltro; }
        public Filtro(){this.ProximoFiltro = null;}

        public abstract IList<Conta> Filtra(IList<Conta> contas);

        protected IList<Conta> OutroFiltro(IList<Conta> contas)
        {
            if (ProximoFiltro == null) return new List<Conta>();
            return ProximoFiltro.Filtra(contas);
        } 
    }
}
