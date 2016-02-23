using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Contratos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public Cliente(string nome,string endereco)
        {
            this.Nome = nome;
            this.Endereco = Endereco;
        }
    }
}
