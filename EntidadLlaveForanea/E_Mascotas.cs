using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadLlaveForanea
{
    public class E_Mascotas
    {
        public int idMascota { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public double precio { get; set; }
        public int especieId { get; set; }
        public E_Especie EntidadEspecie { get; set; }
    }
}
