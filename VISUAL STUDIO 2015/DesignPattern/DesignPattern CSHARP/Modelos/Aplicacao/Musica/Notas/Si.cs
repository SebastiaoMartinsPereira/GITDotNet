﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Musica.Notas
{
    public class Si : INota
    {
        public int Frequencia
        {
            get
            {
                return 440;
            }
        }
    }
}
