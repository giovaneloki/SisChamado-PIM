using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaModelo;

namespace CamadaDados
{
    public class DAL_Chamado
    {
        public string strConexao { get; set; }

        public DAL_Chamado(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool CadastrarChamado(Chamado chamado)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterChamado";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 1);
                conexao.Comando.Parameters.AddWithValue("@dataSolicitada", chamado.dataSolicitada == DateTime.MinValue ? null : chamado.dataSolicitada.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@dataInicio", chamado.dataInicio == DateTime.MinValue ? null : chamado.dataInicio.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@dataTermino", chamado.dataTermino == DateTime.MinValue ? null : chamado.dataTermino.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@usuarioSolicitante", chamado.usuarioSolicitante.idUsuario);
                conexao.Comando.Parameters.AddWithValue("@usuarioAtendimento", chamado.usuarioAtendimento.idUsuario == 0 ? null : chamado.usuarioAtendimento.idUsuario.ToString());
                conexao.Comando.Parameters.AddWithValue("@idNivel", chamado.Nivel.idNivel);
                conexao.Comando.Parameters.AddWithValue("@idTipo", chamado.Tipo.idTipo);
                conexao.Comando.Parameters.AddWithValue("@idStatus", chamado.Status.idStatus);
                conexao.Comando.Parameters.AddWithValue("@descricaoSolicitacao", chamado.descricaoSolicitacao == "" ? null : chamado.descricaoSolicitacao);
                conexao.Comando.Parameters.AddWithValue("@descricaoResolucao", chamado.descricaoResolucao == "" ? null : chamado.descricaoResolucao);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool AlterarChamado(Chamado chamado)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterChamado";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 2);
                conexao.Comando.Parameters.AddWithValue("@dataSolicitada", chamado.dataSolicitada == DateTime.MinValue ? null : chamado.dataSolicitada.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@dataInicio", chamado.dataInicio == DateTime.MinValue ? null : chamado.dataInicio.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@dataTermino", chamado.dataTermino == DateTime.MinValue ? null : chamado.dataTermino.ToString("u").Replace("Z", ""));
                conexao.Comando.Parameters.AddWithValue("@usuarioSolicitante", chamado.usuarioSolicitante.idUsuario);
                conexao.Comando.Parameters.AddWithValue("@usuarioAtendimento", chamado.usuarioAtendimento.idUsuario == 0 ? null : chamado.usuarioAtendimento.idUsuario.ToString());
                conexao.Comando.Parameters.AddWithValue("@idNivel", chamado.Nivel.idNivel);
                conexao.Comando.Parameters.AddWithValue("@idTipo", chamado.Tipo.idTipo);
                conexao.Comando.Parameters.AddWithValue("@idStatus", chamado.Status.idStatus);
                conexao.Comando.Parameters.AddWithValue("@descricaoSolicitacao", chamado.descricaoSolicitacao == "" ? null : chamado.descricaoSolicitacao);
                conexao.Comando.Parameters.AddWithValue("@descricaoResolucao", chamado.descricaoResolucao == "" ? null : chamado.descricaoResolucao);
                conexao.Comando.Parameters.AddWithValue("@idChamado", chamado.idChamado);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeletarChamado(Chamado chamado)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterChamado";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 3);
                conexao.Comando.Parameters.AddWithValue("@idChamado", chamado.idChamado);

                if (conexao.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Chamado> ListaChamados(Chamado vChamado)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterChamado";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 4);
                conexao.Comando.Parameters.AddWithValue("@fkStatus", vChamado.Status.idStatus);
                conexao.Comando.Parameters.AddWithValue("@fkUsuarioSolicitante", vChamado.usuarioSolicitante.idUsuario);
                conexao.Comando.Parameters.AddWithValue("@fkUsuarioAtendeu", vChamado.usuarioAtendimento.idUsuario);
                conexao.Comando.Parameters.AddWithValue("@fkStatus", vChamado.Status.idStatus);
                conexao.Comando.Parameters.AddWithValue("@fkNivel", vChamado.Nivel.idNivel);
                conexao.Comando.Parameters.AddWithValue("@fkTipo", vChamado.Tipo.idTipo);

                List<Chamado> lista = new List<Chamado>();
                var reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Chamado(reader));
                }
                return lista;
            }
        }

        public Chamado ChamadoPorID(Chamado vChamado)
        {
            using (ConexaoBD conexao = new ConexaoBD(this.strConexao))
            {
                conexao.Comando.CommandText = "dbo.pr_ManterChamado";
                conexao.Comando.Parameters.AddWithValue("@Funcao", 5);
                conexao.Comando.Parameters.AddWithValue("@idChamado", vChamado.idChamado);

                Chamado obChamado = new Chamado();
                var reader = conexao.ExecuteReader();
                while (reader.Read())
                {
                    obChamado = new Chamado(reader));
                }
                return obChamado;
            }
        }
    }
}
