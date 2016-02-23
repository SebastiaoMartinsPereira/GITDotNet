using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Contratos
{
    public class Contrato
    {
        
        public DateTime Data { get; private set; }
        public Cliente Cliente { get; private set; }
        public Enum.Enums.TipoContrato Tipo { get; private set; }


        public Contrato(DateTime data, Cliente cliente, Enum.Enums.TipoContrato tipo)
        {
            this.Data = data;
            this.Cliente = cliente;
           this.Tipo = tipo;
        }

        public void Avanca()
        {
            if (this.Tipo.Equals(Enum.Enums.TipoContrato.NOVO)) this.Tipo = Enum.Enums.TipoContrato.EMANDAMENTO;
            else if (this.Tipo == Enum.Enums.TipoContrato.EMANDAMENTO) this.Tipo = Enum.Enums.TipoContrato.ACERTADO;
            else if (this.Tipo == Enum.Enums.TipoContrato.EMANDAMENTO) this.Tipo = Enum.Enums.TipoContrato.CONCLUIDO;
        }

        public Estado SalvaEstado()
        {
            return new Estado(new Contrato(this.Data, this.Cliente, this.Tipo));
        }

        public void Restaura(Estado estado)
        {
            this.Data = estado.Contrato.Data;
            this.Cliente = estado.Contrato.Cliente;
            this.Tipo = estado.Contrato.Tipo;
        }
    }
}
