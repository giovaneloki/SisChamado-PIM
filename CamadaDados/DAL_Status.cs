using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaModelo;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DAL_Status
    {
        public string strConexao { get; set; }

        public DAL_Status(string strConexao)
        {
            this.strConexao = strConexao;
        }
            

        public bool CadastrarStatus(Status status)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterStatus ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeStatus", status.nomeStatus);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarStatus(Status status)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterStatus ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeStatus", status.nomeStatus);
                conexao.Comando.Parameters.AddWithValue("@idStatus", status.idStatus);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarStatus(Status status)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterStatus ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idStatus", status.idStatus);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Status> ListarStatus(Status status)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterStatus ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 4);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idStatus", status.idStatus);

                List<Status> lista = new List<Status>();
                SqlDataReader reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Status(reader));
                }

                return lista;
            }
        }
    }
}
