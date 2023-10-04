using EntidadLlaveForanea;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLlaveForanea
{
    public class D_Especie
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<E_Especie> ObtenerTodos()
        {
            List<E_Especie> lista = new List<E_Especie>();
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spObtenerEspecies", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Especie especie = new E_Especie();

                    especie.idEspecie = Convert.ToInt32(reader["idEspecie"]);
                    especie.nombreEspecie = reader["nombreEspecie"].ToString();

                    lista.Add(especie);

                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

    }
}
