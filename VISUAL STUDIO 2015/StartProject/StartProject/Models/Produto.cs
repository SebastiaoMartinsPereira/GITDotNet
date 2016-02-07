using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class Produto: IDisposable 
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Limite 20 Caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage ="Preencha o campo preço!")]
        public float Preco { get; set; }

        //representa um vinnculo entre produtos e categorias no banco de dados
        //deve ser marcada como virtual
        public virtual  CategoriaDoProduto Categoria { get; set; }

        //Navigation property
        //representa a chave estrangeira do relacionamento
        //deve seguir o padrão de convenção
        //Nome da entidade + ID
        //Caso seja obrigatorio que todo produto tenha uma categoria o tiopo do produto não deve ter a Interrogação
        //caso não seja obrigatorio deve se colocar a interrogação para que o tipo seja marcado como nulable 
        public int? CategoriaID { get; set; }

        public String Descricao { get; set; }
        
        [Range(1,100,ErrorMessage ="Quantidade deve ser entre 10 e 100!")]
        public int Quantidade { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Produto() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
