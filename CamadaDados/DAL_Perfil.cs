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
                conexao.Comando.Parameters.AddWithValue("@nomePerfil", perfil.nomePerfil);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarNivel(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.Parameters.AddWithValue("@nomePerfil", perfil.nomePerfil);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarNivel(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Nivel> ListarPerfil(Perfil perfil)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterPerfil ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", perfil.idPerfil);

                List<Nivel> lista = new List<Nivel>();
                SqlDataReader reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Nivel(reader));
                }

                return lista;
            }
        }
    }
}
