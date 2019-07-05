using Persistencia.lib.entity;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ValidacionesContrato
    {


        public static ResultadoValidacion CamposObligatorios(ContratoEntity contrato)
        {
            if(contrato.Cliente is NullClienteEntity)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "Se debe especificar un cliente"
                };
            }


            if(contrato.InicioEvento == null ||
               contrato.TerminoEvento == null ||
               contrato.Creacion == null ||
               contrato.Tipo == null ||
               contrato.ModalidadServicio == null
               )
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "Se deben especificar todos los campos necesarios."
                };
            }

            // Validaciones especificas para Tipos de Evento particulares

            if(contrato.Tipo is CenaEntity)
            {
                if((contrato.Tipo as CenaEntity).Ambientacion is NullTipoAmbientacionEntity)
                {
                    return new ResultadoValidacion()
                    {
                        Exito = false,
                        MensajeError = "El tipo de evento seleccionado requiere especificar ambientación"
                    };
                }

            }


            return new ResultadoValidacion()
            {
                Exito = true
            };
        }

        public static ResultadoValidacion Fechas(DateTime fechaInicio, DateTime fechaTermino, DateTime fechaCreacion)
        {
            if(fechaCreacion > DateTime.Today)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de creación no puede ser mayor a hoy"
                };
            }

            if(fechaInicio < DateTime.Today)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de inicio de contrato no puede ser menor a hoy"
                };
            }

            if(fechaTermino < DateTime.Today)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "La fecha de termino no puede ser menor a hoy."
                };
            }

            if (fechaInicio > fechaTermino)
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

            if((fechaTermino - fechaInicio) > TimeSpan.FromHours(24))
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "El evento no puede durar más de 24 horas"
                };
            }

            if(fechaTermino == fechaInicio)
            {
                return new ResultadoValidacion()
                {
                    Exito = false,
                    MensajeError = "Fechas/horas de inicio inválidas"
                };
            }

            return new ResultadoValidacion()
            {
                Exito = true
            };
        }
    }
}
