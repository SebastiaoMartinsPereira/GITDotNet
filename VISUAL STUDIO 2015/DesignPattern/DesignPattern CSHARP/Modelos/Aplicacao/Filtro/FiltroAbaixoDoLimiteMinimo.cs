﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Filtro
{
    public class FiltroAbaixoDoLimiteMinimo : Filtro
    {
        public FiltroAbaixoDoLimiteMinimo(Filtro proximoFiltro) : base(proximoFiltro) { }
        public FiltroAbaixoDoLimiteMinimo() : base() { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            IList<Conta> filtradas = new List<Conta>();

            foreach(Conta item in OutroFiltro(contas))
            {
                filtradas.Add(item);
            }

            foreach (Conta item in contas)
            {
                if (item.Saldo < 100d)
                {
                    filtradas.Add(item);
                }
            }

            return filtradas;
        }
    }
}
