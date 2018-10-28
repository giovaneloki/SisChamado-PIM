using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Nivel
    {
        public int idNivel { get; set; }
        public string nomeNivel { get; set; }
        public int peso { get; set; }

        public Nivel()
        {
        }

        public Nivel(SqlDataReader reader)
        {
            idNivel = reader["idNivel"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idNivel"]);
            nomeNivel = reader["nomeNivel"] == DBNull.Value ? "" : reader["nomeNivel"].ToString();
            peso = reader["peso"] == DBNull.Value ? 0 : Convert.ToInt16(reader["peso"]);
        }
    }
}
