using Persistencia.lib.dao;
using Persistencia.lib.entity;
using SubsidiosMinvu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace OnBreakEventos
{
    public class ListadoContratosViewModel : INotifyPropertyChanged
    {
        private string _filtro;

        public string Filtro
        {
            get
            {
                return _filtro;
            }

            set
            {
                _filtro = value;
                ActualizarFiltroColeccion();
                NotifyPropertyChanged();
            }
        }

        private int _tipoFiltro = 0; // Sin filtro por defecto

        public int TipoFiltro
        {
            get
            {
                return _tipoFiltro;
            }

            set
            {
                _tipoFiltro = value;
                ActualizarFiltroColeccion();
                NotifyPropertyChanged();
            }
        }

        public void ActualizarFiltroColeccion()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(ContratosCollection);


            if (String.IsNullOrEmpty(this.Filtro))
            {
                collectionView.Filter = null;
                return;
            }


            if (this.TipoFiltro != 0)
            { // Si es que no está seleccionada la opción 'sin filtro'

                if (this.TipoFiltro == 1) // Número de contrato
                {
                    collectionView.Filter = new Predicate<object>(item =>
                    ((ContratoEntity)item).NumeroContrato.ToString().Contains(this.Filtro.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if (this.TipoFiltro == 2) // Rut del cliente
                {
                    collectionView.Filter = new Predicate<object>(item => ((ContratoEntity)item).Cliente.Rut.ToUpper().Contains(this.Filtro.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if (this.TipoFiltro == 3) // Tipo de evento
                {
                    collectionView.Filter = new Predicate<object>(item => ((ContratoEntity)item).Tipo.Descripcion.ToUpper().Contains(this.Filtro.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if (this.TipoFiltro == 4)
                {
                    collectionView.Filter = new Predicate<object>(item => ((ContratoEntity)item).ModalidadServicio.Nombre.ToUpper().Contains(this.Filtro.ToUpper().Replace("\r\n", string.Empty)));
                }
            }
        }

        private ContratoDAO _contratoDAO = new ContratoDAO();

        private ObservableCollection<ContratoEntity> _contratosCollection = new ObservableCollection<ContratoEntity>();
        public ObservableCollection<ContratoEntity> ContratosCollection
        {
            get
            {
                return _contratosCollection;
            }

            set
            {
                _contratosCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ListadoContratosViewModel()
        {
            RefrescarContratos();
        }

        public void RefrescarContratos()
        {

            ContratosCollection = new ObservableCollection<ContratoEntity>();

            IEnumerable<ContratoEntity> enumerableContratos = _contratoDAO.BuscarTodo();

            foreach (ContratoEntity contrato in enumerableContratos)
            {
                ContratosCollection.Add(contrato);
            }
        }

        #region Comandos

        private RelayCommand _refrescarContratosCommand;

        public ICommand RefrescarContratosCommand
        {
            get
            {
                if (_refrescarContratosCommand == null)
                {
                    _refrescarContratosCommand = new RelayCommand(RefrescarContratosCommandHandler, CanRefrescarContratos);
                }

                return _refrescarContratosCommand;
            }
        }

        private bool CanRefrescarContratos(object parameters)
        {
            return true;
        }

        /// <summary>
        /// Handler del comando para refrescar los contratos
        /// </summary>
        public void RefrescarContratosCommandHandler(object parameters)
        {
            this.RefrescarContratos();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
