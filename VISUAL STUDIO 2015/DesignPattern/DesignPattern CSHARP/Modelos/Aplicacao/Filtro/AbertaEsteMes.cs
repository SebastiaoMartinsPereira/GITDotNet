﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Filtro
{
    public class AbertaEsteMes : Filtro
    {

        public AbertaEsteMes(Filtro proximoFiltro) : base(proximoFiltro) { }
        public AbertaEsteMes() : base() { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            IList<Conta> filtradas = new List<Conta>();

            foreach (Conta item in OutroFiltro(contas))
            {
                filtradas.Add(item);
            }

            foreach (var item in contas)
            {
                if (FoiAbertaEsteMes(item))
                {
                    filtradas.Add(item);
                }
            }

            return filtradas;

        }

        private bool FoiAbertaEsteMes(Conta conta)
        {
            if (conta.DataAbertura.Year == DateTime.Today.Year && conta.DataAbertura.Month == DateTime.Today.Month) return true;
            return false;
        }


    }
}
