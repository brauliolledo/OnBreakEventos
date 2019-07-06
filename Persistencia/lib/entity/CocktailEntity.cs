using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class CocktailEntity : TipoEventoEntity
    {
        private TipoAmbientacionEntity ambientacionEntity;

        public TipoAmbientacionEntity Ambientacion
        {
            get { return ambientacionEntity; }
            set { ambientacionEntity = value; NotifyPropertyChanged(); }
        }

        private bool _musicaAmbiental;

        public bool MusicaAmbiental
        {
            get { return _musicaAmbiental; }
            set { _musicaAmbiental = value; NotifyPropertyChanged(); }
        }

        private bool _musicaCliente;

        public bool MusicaCliente
        {
            get { return _musicaCliente; }
            set { _musicaCliente = value; NotifyPropertyChanged(); }
        }

    }
}
