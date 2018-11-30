using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaModelo;

namespace CamadaDados
{
    public class DAL_Perfil
    {
        public string strConexao { get; set; }

        public DAL_Perfil(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool CadastrarPerfil(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomePerfil", perfil.nomePerfil);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarPerfil(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomePerfil", perfil.nomePerfil);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarPerfil(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Perfil> ListarPerfil(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 4);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);

                List<Perfil> lista = new List<Perfil>();
                SqlDataReader reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Perfil(reader));
                }

                return lista;
            }
        }
    }
}
