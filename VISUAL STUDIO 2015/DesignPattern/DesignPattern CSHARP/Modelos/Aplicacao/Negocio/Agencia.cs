using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class Agencia
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
       
        public Agencia(int codigo,string nome,string endereco,string telefone,string email)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;

        }
        public override string ToString()
        {
            return String.Format("{0}",Codigo);
        }
    }
}
