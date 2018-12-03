using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Tipo
    {
        public int? idTipo { get; set; }
        public string nomeTipo { get; set; }

        public Tipo()
        {

        }

        public Tipo(SqlDataReader reader)
        {
            idTipo = reader["idTipo"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idTipo"]);
            nomeTipo = reader["nomeTipo"] == DBNull.Value ? "" : reader["nomeTipo"].ToString();
        }
    }
}
