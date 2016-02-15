
using DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class Orcamento
    {
        public double Valor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public IEstadoOrcamento EstadoAtual { get; private set; }
        public Orcamento(double valor)
        {
            this.Valor = valor;
            this.Itens = new List<Item>();
            this.EstadoAtual = new Novo();
        }

        public void AdicionaItem(Item item)
        {
            this.Itens.Add(item);
        }

        public void Descontar(double valor)
        {
            if(valor < this.Valor && valor > 0)
                Valor -= valor ;
        }

        public void Acrescentar(double valor)
        {
            if (valor > 0)
                Valor += valor;
        }

        public void AlterarEstado(IEstadoOrcamento novoEstado)
        {
            this.EstadoAtual = novoEstado;
        }

        public void Aprova()
        {
            this.EstadoAtual.Aprova(this);
        }

        public void Reprova()
        {
            this.EstadoAtual.Reprova(this);
        }

        public void Finaliza()
        {
            this.EstadoAtual.Finaliza(this);
        }

        public void AplicaDescontoExtra()
        {
            this.EstadoAtual.AplicaDescontaoExtra(this);
        }

    }
}
