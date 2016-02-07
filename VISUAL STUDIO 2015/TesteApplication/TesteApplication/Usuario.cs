namespace TesteApplication
{
    public class Usuario
    {
        private string Nome { get; set; }

        public Usuario(string nome)
        {
            this.Nome = nome;
        }


        public override string ToString()
        {
            return string.Format("{0}", this.Nome);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Usuario other = (Usuario)obj;
            if (Nome != other.Nome)
                return false;

            if (Nome == null)
            {
                if (other.Nome != null)
                    return false;
            }
            else if (!this.Nome.Equals(other.Nome))
            {
                return true;
            }

            return true;
                
        }
    }
}