using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ValorizadorTipoEventoDecorator : ValorizadorDecorator
    {
        public ValorizadorTipoEventoDecorator()
        {

        }
        public int CalcularTotal(TipoEventoEntity tipoEvento, int precioBase, int asistentes, int personalAdicional)
        {
            int valorBase = Valorizador.CalcularTotal(precioBase, asistentes, personalAdicional);

            if(tipoEvento is CocktailEntity)
            {
                if((tipoEvento as CocktailEntity).Ambientacion != null)
                {
                    if ((tipoEvento as CocktailEntity).Ambientacion.Id == 10) //Ambientación básica
                    {
                        valorBase += (int)Math.Round(2 * Valorizador.UF, 0);
                    }
                    else if ((tipoEvento as CocktailEntity).Ambientacion.Id == 20) //Ambientación básica
                    {
                        valorBase += (int)Math.Round(5 * Valorizador.UF, 0);
                    }
                }


                if((tipoEvento as CocktailEntity).MusicaAmbiental == true)
                {
                    valorBase += (int) Math.Round(1 * Valorizador.UF, 0);
                }
            }
            else if(tipoEvento is CenaEntity)
            {
                if((tipoEvento as CenaEntity).Ambientacion != null)
                {
                    if ((tipoEvento as CenaEntity).Ambientacion.Id == 10) //Ambientación básica
                    {
                        valorBase += (int)Math.Round(3 * Valorizador.UF, 0);
                    }
                    else if ((tipoEvento as CenaEntity).Ambientacion.Id == 20) //Ambientación básica
                    {
                        valorBase += (int)Math.Round(5 * Valorizador.UF, 0);
                    }

                }

                if ((tipoEvento as CenaEntity).MusicaAmbiental == true)
                {
                    valorBase += (int)Math.Round(1.5 * Valorizador.UF, 0);
                }

                if((tipoEvento as CenaEntity).LocalOnBreak == true)
                {
                    valorBase += (int)Math.Round(9 * Valorizador.UF, 0);
                }
                else if((tipoEvento as CenaEntity).OtroLocal == true)
                {
                    valorBase += (int)(tipoEvento as CenaEntity).ValorArriendo;       
                }
            }

            return valorBase;
        }
    }
}
