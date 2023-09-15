using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace TIENDA
{
    class Productos
    {
        OleDbConnection conector;
        OleDbCommand comando;
        string sql;

        public Productos()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=TIENDA.mdb");
            comando = new OleDbCommand();
            sql = "";
        }

        public void grabar(int producto, string nombre, int stock)
        {
            sql= $"INSERT INTO Productos VALUES({producto}, '{nombre}', {stock})";

            conector.Open();
            comando.Connection = conector;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            comando.ExecuteNonQuery();

            conector.Close();
        }
        public void listar(DataGridView grilla)
        {
            sql = "SELECT * FROM Productos";

            conector.Open();
            comando.Connection = conector;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            OleDbDataReader dr = comando.ExecuteReader();
            grilla.Rows.Clear();
            while (dr.Read())
            {
                grilla.Rows.Add(dr["Producto"], dr["Nombre"], dr["Stock"]);
            }

            conector.Close();
        }
        public void eliminar(int producto)
        {
            sql = $"DELETE FROM Productos WHERE producto= {producto}";

            conector.Open();
            comando.Connection = conector;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            comando.ExecuteNonQuery();

            conector.Close();
        }
    }
}
