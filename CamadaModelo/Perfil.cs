using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Perfil
    {
        public int? idPerfil { get; set; }
        public string nomePerfil { get; set; }

        public Perfil()
        {

        }

        public Perfil(SqlDataReader reader)
        {
            idPerfil = reader["idPerfil"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idPerfil"]);
            nomePerfil = reader["nomePerfil"] == DBNull.Value ? "" : reader["nomePerfil"].ToString();
        }
    }
}
