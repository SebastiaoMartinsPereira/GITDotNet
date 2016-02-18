using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Conexao
{
    public class ConnectionFactory
    {
        public string UserId { get; private set; }
        public string Password  { get; private set; }
        public string Server { get; private set; }
        public string DataBase { get; private set; }
        private string StrCon { get; set; }

        public ConnectionFactory(string user,string password,string server,string database)
        {
            this.UserId = user;
            this.Password = password;
            this.Server = server;
            this.DataBase = database;
            this.StrCon = MontarStrConn();
        }

        private string MontarStrConn()
        {
            return string.Format("User Id={0};Password={1};Server={2};Database={3}",this.UserId,this.Password,this.Server,this.DataBase);
        }

        public IDbConnection GetConnection()
        {
            IDbConnection conexao = new SqlConnection();

            conexao.ConnectionString = this.StrCon;
            conexao.Open();
            return conexao;
        }


        public void Main(string[] args)
        {
            IDbConnection conexao = new ConnectionFactory("sa", "NPS300892", "localhost", "TESTE").GetConnection();

            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText="Select * from tb0003_Usuarios";

        }
    }
}
