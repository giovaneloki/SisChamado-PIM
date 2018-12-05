using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace CamadaDados
{
    public class ConexaoBD : IDisposable
    {
        #region IsDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                if (disposing)
                {
                    this.Dispose();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
            if (this.Conexao.State == ConnectionState.Open)
            {
                this.Conexao.Close();
                this.Comando.Connection.Close();

                this.Comando.Dispose();
                this.Conexao.Dispose();
                this.DataAdapter.Dispose();
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
        #region Propriedades
        public SqlConnection Conexao;
        public SqlCommand Comando;
        public SqlDataAdapter DataAdapter;
        #endregion

        #region Construtor
        public ConexaoBD(string strConexao)
        {
            //this.Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
            this.Conexao = new SqlConnection(strConexao);
            this.Conexao.Open();
            this.Comando = new SqlCommand();
            Comando.CommandTimeout = TimeSpan.FromMinutes(600).Seconds;
            this.DataAdapter = new SqlDataAdapter(this.Comando);
        }
        #endregion

        #region Metodos
        public SqlDataReader ExecuteReader()
        {
            this.Comando.Connection = this.Conexao;
            var dataReader = this.Comando.ExecuteReader();
            return dataReader;
        }

        public int ExecuteNonQuery()
        {
            try
            {
                this.Comando.Connection = this.Conexao;
                var dataReader = this.Comando.ExecuteNonQuery();
                return dataReader;
            }
            catch (Exception ex)
            {
                this.Dispose();
                return 0;
            }

        }

        public DataTable ExecuteDataTable()
        {
            DataTable dtRetorno = new DataTable();
            try
            {
                this.Comando.Connection = this.Conexao;
                SqlDataAdapter data = new SqlDataAdapter(this.Comando);
                data.Fill(dtRetorno);
                return dtRetorno;
            }
            catch (Exception)
            {
                this.Dispose();
                return dtRetorno;
            }
        }
        #endregion
    }
}