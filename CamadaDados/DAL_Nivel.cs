using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaModelo;

namespace CamadaDados
{
    public class DAL_Nivel
    {
        public string strConexao { get; set; }

        public DAL_Nivel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool CadastrarNivel(Nivel nivel)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterNivel ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.Parameters.AddWithValue("@nomeNivel", nivel.nomeNivel);
                conexao.Comando.Parameters.AddWithValue("@peso", nivel.peso);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarNivel(Nivel nivel)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterNivel ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.Parameters.AddWithValue("@nomeNivel", nivel.nomeNivel);
                conexao.Comando.Parameters.AddWithValue("@peso", nivel.peso);
                conexao.Comando.Parameters.AddWithValue("@idNivel", nivel.idNivel);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarNivel(Nivel nivel)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterNivel ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.Parameters.AddWithValue("@idNivel", nivel.idNivel);
                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Nivel> ListarNivel(Nivel nivel)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterNivel ";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.Parameters.AddWithValue("@idNivel", nivel.idNivel);

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
