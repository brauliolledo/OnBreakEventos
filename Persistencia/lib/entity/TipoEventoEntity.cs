using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Persistencia.lib.entity
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class TipoEventoEntity : INotifyPropertyChanged
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value;  NotifyPropertyChanged();  }
        }


        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; NotifyPropertyChanged();  }
        }


        public TipoEventoEntity(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public TipoEventoEntity()
        {
            this.Id = 0;
            this.Descripcion = "";
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj == DependencyProperty.UnsetValue) return false;

            return (obj as TipoEventoEntity).Id == this.Id;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
