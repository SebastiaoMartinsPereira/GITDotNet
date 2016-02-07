using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class Venda
    {
        public int ID { get; set; }

        //Deve ser virtual para poder representar o vinculo entre as entidades
        public virtual Usuario Cliente { get; set; }

        public virtual IList<Produto> Produtos{ get; set; }

        public Venda()
        {
            this.Produtos = new List<Produto>();
        }


    }
}
