using EntidadLlaveForanea;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatosLlaveForanea
{
    public class D_Mascotas
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
       
        public List<E_Mascotas> ObtenerTodos()
        {
           
            try
            {
                List<E_Mascotas> lista = new List<E_Mascotas>();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spObtenerMascotas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Mascotas mascota = new E_Mascotas();
                    E_Especie especie = new E_Especie();
                    mascota.idMascota = Convert.ToInt32(reader["idMascota"]);
                    mascota.nombre = reader["nombre"].ToString();
                    mascota.edad = Convert.ToInt32(reader["edad"]);
                    mascota.precio = Convert.ToInt32(reader["precio"]);
                    mascota.especieId = Convert.ToInt32(reader["especieId"]);

                    especie.idEspecie = Convert.ToInt32(reader["idEspecie"]);
                    especie.nombreEspecie = reader["nombreEspecie"].ToString();

                    mascota.EntidadEspecie = especie;
                    lista.Add(mascota);

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

        public void AgregarMascotas(E_Mascotas mascota )
        {
            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spAgregarMascotas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", mascota.edad);
                cmd.Parameters.AddWithValue("@precio", mascota.precio);
                cmd.Parameters.AddWithValue("@especieId", mascota.especieId);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void BorrarMascota(int id)
        {
            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spBorrarMascotas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMascota", id);
               

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void EditarMascotas(E_Mascotas mascota)
        {
            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spActualizarMascota", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMascota", mascota.idMascota);
                cmd.Parameters.AddWithValue("@nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", mascota.edad);
                cmd.Parameters.AddWithValue("@precio", mascota.precio);
                cmd.Parameters.AddWithValue("@especieId", mascota.especieId);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public E_Mascotas ObtenerMascotaPorId(int id)
        {
         
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spObtenerMascotaPorId", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMascota", id);

                SqlDataReader reader = cmd.ExecuteReader();
                E_Mascotas mascota = new E_Mascotas();

                while (reader.Read())
                {
                    mascota.idMascota = Convert.ToInt32(reader["idMascota"]);
                    mascota.nombre = reader["nombre"].ToString();
                    mascota.edad = Convert.ToInt32(reader["edad"]);
                    mascota.precio = Convert.ToInt32(reader["precio"]);
                    mascota.especieId = Convert.ToInt32(reader["especieId"]);
                }
                conexion.Close();
                return mascota;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public List<E_Mascotas> Buscar(string valor)
        {

            try
            {
                List<E_Mascotas> lista = new List<E_Mascotas>();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscarMascotas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@valor", valor);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Mascotas mascota = new E_Mascotas();
                    E_Especie especie = new E_Especie();
                    mascota.idMascota = Convert.ToInt32(reader["idMascota"]);
                    mascota.nombre = reader["nombre"].ToString();
                    mascota.edad = Convert.ToInt32(reader["edad"]);
                    mascota.precio = Convert.ToInt32(reader["precio"]);
                    mascota.especieId = Convert.ToInt32(reader["especieId"]);

                    especie.idEspecie = Convert.ToInt32(reader["idEspecie"]);
                    especie.nombreEspecie = reader["nombreEspecie"].ToString();

                    mascota.EntidadEspecie = especie;
                    lista.Add(mascota);

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

        public E_Mascotas BuscarMascotaPorNombre(string nombre)
        {
            E_Mascotas mascota = new E_Mascotas();
            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spBuscarMascota", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    mascota.idMascota = Convert.ToInt32(reader["idMascota"]);
                    mascota.nombre = reader["nombre"].ToString();
                }

                conexion.Close();
                return mascota;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

    }
}
