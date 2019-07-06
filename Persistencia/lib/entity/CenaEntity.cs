using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class CenaEntity : TipoEventoEntity
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

        private bool _localOnBreak;

        public bool LocalOnBreak
        {
            get { return _localOnBreak; }
            set
            {
                _localOnBreak = value;

                if(OtroLocal == true && value == true)
                {
                    OtroLocal = false;
                }

                NotifyPropertyChanged();
            }
        }

        private bool _otroLocal;

        public bool OtroLocal
        {
            get { return _otroLocal; }
            set
            {

                if (LocalOnBreak == true && value == true)
                {
                    LocalOnBreak = false;
                }

                _otroLocal = value;
                NotifyPropertyChanged();
            }
        }

        private double _valorArriendo;

        public double ValorArriendo
        {
            get { return _valorArriendo; }
            set { _valorArriendo = value; NotifyPropertyChanged(); }
        }

    }
}
