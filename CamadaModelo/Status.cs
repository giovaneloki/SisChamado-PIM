using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaModelo
{
    public class Status
    {
        public int idStatus { get; set; }
        public string nomeStatus { get; set; }
        public bool finalizador { get; set; }

        public Status()
        {
        }

        public Status(SqlDataReader reader)
        {
            idStatus = reader["idStatus"] == DBNull.Value ? 0 : Convert.ToInt16(reader["idStatus"]);
            nomeStatus = reader["nomeStatus"] == DBNull.Value ? "" : reader["nomeStatus"].ToString();
            finalizador = reader["finalizador"] == DBNull.Value ? false : Convert.ToBoolean(reader["finalizador"]);
        }
    }
}
