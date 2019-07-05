using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResultadoValidacion
    {
        public bool Exito { get; set; }
        public string MensajeError { get; set; }

        public ResultadoValidacion()
        {
            MensajeError = "Error no especificado";
        }
    }
}
