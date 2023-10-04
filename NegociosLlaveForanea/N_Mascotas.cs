using DatosLlaveForanea;
using EntidadLlaveForanea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociosLlaveForanea
{
    public class N_Mascotas
    {
        D_Mascotas datos = new D_Mascotas();

        public List<E_Mascotas> ObtenerMascotas()
        {
            List<E_Mascotas> lista = datos.ObtenerTodos();
            return lista;
        }

        public void AgregarMascotas(E_Mascotas mascota)
        {
            datos.AgregarMascotas(mascota);
        }

        public void BorrarMascotas(int id)
        {
            datos.BorrarMascota(id);
        }

        public void EditarMascotas(E_Mascotas mascota)
        {
            datos.EditarMascotas(mascota);
        }

        public E_Mascotas ObtenerMascotaPorId(int id)
        {
            E_Mascotas mascota = datos.ObtenerMascotaPorId(id);
            return mascota;
        }

        public List<E_Mascotas> BuscarMascotas(string valor)
        {
            List<E_Mascotas> lista = datos.Buscar(valor);

            if (lista.Count == 0)
            {
                throw new ApplicationException("La busqueda no genero resultados");
            }
            return lista;
        }
        public bool ExisteMascota(string nombre)
        {
            E_Mascotas mascota = datos.BuscarMascotaPorNombre(nombre);

            if(mascota.idMascota > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
