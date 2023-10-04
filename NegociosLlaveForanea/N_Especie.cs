using DatosLlaveForanea;
using EntidadLlaveForanea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociosLlaveForanea
{
    public class N_Especie
    {
            D_Especie datos = new D_Especie();

        public List<E_Especie> ObtenerEspecies()
        {
            List<E_Especie> lista = datos.ObtenerTodos();
            return lista;
        }
    }
}
