using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEF.Migrations.DAO
{
    class UsuarioDAO
    {
        private EntidadesContext contexto { get; set; }

        public UsuarioDAO()
        {
            contexto = new EntidadesContext();

        }

        public void insert(Usuario u)
        {
            contexto.Usuarios.Add(u);
            contexto.SaveChanges();
        }

        public void delete(Usuario u)
        {
            contexto.Usuarios.Remove(u);
            contexto.SaveChanges();
        }

        public Usuario buscaPorId(int id)
        {
            return contexto.Usuarios.Find(id);
        }

        public void saveChanges()
        {
            contexto.SaveChanges();  
        }

    }
}
