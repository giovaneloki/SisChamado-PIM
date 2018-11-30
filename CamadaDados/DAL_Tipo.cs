using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaModelo;

namespace CamadaDados
{
    public class DAL_Tipo
    {
        public string strConexao { get; set; }

        public DAL_Tipo(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool CadastrarTipo(Tipo tipo)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterTipo ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeTipo", tipo.nomeTipo);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarTipo(Tipo tipo)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterTipo";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeTipo", tipo.nomeTipo);
                conexao.Comando.Parameters.AddWithValue("@idTipo", tipo.idTipo);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarTipo(Tipo tipo)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterTipo";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idTipo", tipo.idTipo);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Tipo> ListarTipo(Tipo tipo)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterTipo";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 4);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idTipo", tipo.idTipo);

                List<Tipo> lista = new List<Tipo>();
                SqlDataReader reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Tipo(reader));
                }

                return lista;
            }
        }
    }
}
