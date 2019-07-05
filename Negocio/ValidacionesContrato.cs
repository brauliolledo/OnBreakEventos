using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ValidacionesContrato
    {
        public static ResultadoValidacion Fechas(DateTime fechaInicio, DateTime fechaTermino)
        {
            if(fechaInicio < DateTime.Today)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de inicio de contrato no puede ser menor a hoy"
                };
            }

            if(fechaInicio > fechaTermino)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de inicio no puede ser mayor a la fecha de término"
                };
            }


            if ((fechaInicio - DateTime.Now) > TimeSpan.FromDays(300))
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de inicio no puede ser mayor a 10 meses desde la fecha actual"
                };
            }

            return new ResultadoValidacion()
            {
                Exito = true
            };
        }
    }
}
