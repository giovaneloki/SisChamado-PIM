using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaModelo;

namespace CamadaDados
{
    public class DAL_Usuario
    {
        public string strConexao { get; set; }

        public DAL_Usuario(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeUsuario", usuario.nomeUsuario);
                conexao.Comando.Parameters.AddWithValue("@loginUsuario", usuario.loginUsuario);
                conexao.Comando.Parameters.AddWithValue("@senhaUsuario", usuario.senhaUsuario);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", usuario.Perfil.idPerfil);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarUsuario(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeUsuario", usuario.nomeUsuario);
                conexao.Comando.Parameters.AddWithValue("@loginUsuario", usuario.loginUsuario);
                conexao.Comando.Parameters.AddWithValue("@senhaUsuario", usuario.senhaUsuario);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", usuario.Perfil.idPerfil);
                conexao.Comando.Parameters.AddWithValue("@FlAtivo", usuario.FlAtivo);
                conexao.Comando.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DesativarUsuario(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Usuario> ListarUsuario(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                List<Usuario> lista = new List<Usuario>();

                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 4);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@nomeUsuario", usuario.nomeUsuario);
                conexao.Comando.Parameters.AddWithValue("@loginUsuario", usuario.loginUsuario);
                conexao.Comando.Parameters.AddWithValue("@idPerfil", usuario.Perfil.idPerfil);
                conexao.Comando.Parameters.AddWithValue("@FlAtivo", usuario.FlAtivo);

                var reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Usuario(reader));
                }
                return lista;
            }
        }

        public Usuario LogarUsuario(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 5);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@senhaUsuario", usuario.senhaUsuario);
                conexao.Comando.Parameters.AddWithValue("@loginUsuario", usuario.loginUsuario);

                Usuario logado = new Usuario();
                var reader = conexao.ExecuteReader();
                while (reader.Read()){
                    logado = new Usuario(reader);
                }

                return logado;
            }
        }

        public Usuario BuscarPorLoginOuID(Usuario usuario)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterUsuario";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 6);
                conexao.Comando.CommandType = System.Data.CommandType.StoredProcedure;
                conexao.Comando.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
                conexao.Comando.Parameters.AddWithValue("@loginUsuario", usuario.loginUsuario);

                Usuario busca = new Usuario();
                var reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    busca = new Usuario(reader);
                }

                return busca;
            }
        }
    }
}
