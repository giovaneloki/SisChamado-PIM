using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Chamado
    {
        public int idChamado { get; set; }
        public DateTime dataSolicitada { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }

        public Usuario usuarioSolicitante { get; set; }
        public Usuario usuarioAtendimento { get; set; }
        public Nivel Nivel { get; set; }
        public Tipo Tipo { get; set; }
        public Status Status { get; set; }

        public string descricaoSolicitacao { get; set; }
        public string descricaoResolucao { get; set; }

        public Chamado()
        {

            usuarioSolicitante = new Usuario();
            usuarioAtendimento = new Usuario();
            Nivel = new Nivel();
            Tipo = new Tipo();
            Status = new Status();
        }
        public Chamado(SqlDataReader reader)
        {
            idChamado = reader["idChamado"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idChamado"]);
            dataSolicitada = reader["dataSolicitada"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(reader["dataSolicitada"].ToString());
            dataInicio = reader["dataInicio"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(reader["dataInicio"].ToString());
            dataTermino = reader["dataTermino"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(reader["dataTermino"].ToString());

            usuarioAtendimento = new Usuario()
            {
                idUsuario = reader["idUsuarioAtendimento"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idUsuarioAtendimento"]),
                nomeUsuario = reader["UsuarioAtendimento"] == DBNull.Value ? "" : reader["UsuarioAtendimento"].ToString()
            };

            usuarioSolicitante = new Usuario()
            {
                idUsuario = reader["idUsuarioSolicitante"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idUsuarioSolicitante"]),
                nomeUsuario = reader["UsuarioSolicitante"] == DBNull.Value ? "" : reader["UsuarioSolicitante"].ToString()
            };

            Nivel = new Nivel(reader);
            Tipo = new Tipo(reader);
            Status = new Status(reader);

            descricaoResolucao = reader["descricaoResolucao"] == DBNull.Value ? "" : reader["descricaoResolucao"].ToString();
            descricaoSolicitacao = reader["descricaoSolicitacao"] == DBNull.Value ? "" : reader["descricaoSolicitacao"].ToString();
        }
    }
}
