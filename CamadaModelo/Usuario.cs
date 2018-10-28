using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public Perfil Perfil { get; set; }
        public string loginUsuario { get; set; }
        public string senhaUsuario { get; set; }
        public bool FlAtivo { get; set; }
            
        public Usuario()
        {

        }

        public Usuario(SqlDataReader reader)
        {
            idUsuario = reader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idUsuario"]);
            nomeUsuario = reader["nomeUsuario"] == DBNull.Value ? "" : reader["nomeUsuario"].ToString();
            Perfil = new Perfil(reader);
            loginUsuario = reader["loginUsuario"] == DBNull.Value ? "" : reader["loginUsuario"].ToString();
            senhaUsuario = reader["senhaUsuario"] == DBNull.Value ? "" : reader["senhaUsuario"].ToString();
            FlAtivo = reader["FlAtivo"] == DBNull.Value ? false : Convert.ToBoolean(reader["FlAtivo"]);
        }
    }
}
