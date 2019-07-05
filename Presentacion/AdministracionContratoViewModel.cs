using Negocio;
using Persistencia.lib.dao;
using Persistencia.lib.entity;
using Presentacion.app.lib;
using SubsidiosMinvu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnBreakEventos
{
    public class AdministracionContratoViewModel : INotifyPropertyChanged
    {
        public ContratoDAO ContratoDAO { get; set; }

        public TipoEventoDAO TipoEventoDAO { get; set; }
        public ModalidadServicioDAO ModalidadServicioDAO { get; set; }
        public ClienteDAO ClienteDAO { get; set; }
        public TipoAmbientacionDAO TipoAmbientacionDAO { get; set; }


        private ContratoEntity _contrato;

        public Valorizador Valorizador = new Valorizador();

        private string _rutBusquedaCliente;

        public string RutBusquedaCliente
        {
            get
            {
                return _rutBusquedaCliente;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    this.Contrato.Cliente = new NullClienteEntity();
                    _rutBusquedaCliente = null;
                    return;
                }

                if (value.Length > 9)
                {
                    MessageBox.Show("RUT Inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Contrato.Cliente = new NullClienteEntity();
                    _rutBusquedaCliente = null;
                    return;
                }

                // Revisamos la validez del rut. Debe ser un número
                try
                {
                    int.Parse(value);
                }
                catch
                {
                    MessageBox.Show("RUT inválido. Ingréselo sin puntos ni guiones.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Contrato.Cliente = new NullClienteEntity();
                    _rutBusquedaCliente = null;
                    return;
                }

                ClienteEntity clienteCoincidente = this.ClienteDAO.BuscarPorRut(value);


                if (clienteCoincidente != null)
                {
                    this.Contrato.Cliente = clienteCoincidente;
                }
                else
                {
                    MessageBox.Show("No se encontó el cliente con el RUT especificado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Contrato.Cliente = new NullClienteEntity();
                    _rutBusquedaCliente = null;
                    return;
                }

                _rutBusquedaCliente = value;

                NotifyPropertyChanged();
            }
        }

        public ContratoEntity Contrato
        {
            get
            {
                return _contrato;
            }
            set
            {
                _contrato = value;


                if (value.Tipo != null)
                {
                    try
                    {
                        this.ModalidadesServicio = ModalidadServicioDAO.BuscarPorIdTipoEvento(value.Tipo.Id);
                    }
                    catch
                    {
                        MessageBox.Show("Ocurrió un error al cargar la información de los tipos de evento. Por favor, contacte al administrador");
                        this.ModalidadesServicio = null;
                    }

                    if (value.ModalidadServicio != null)
                    {


                        value.PrecioTotal = Valorizador.CalcularTotal((int)value.ModalidadServicio.ValorBase, value.Asistentes, value.PersonalAdicional);

                    }
                }

                if (value != null)
                    value.PropertyChanged += Contrato_PropertyChanged;



                NotifyPropertyChanged();
            }
        }

        private List<TipoEventoEntity> _tiposEvento;

        public List<TipoEventoEntity> TiposEvento
        {
            get
            {
                return _tiposEvento;
            }

            set
            {
                _tiposEvento = value;
                NotifyPropertyChanged();
            }

        }

        private List<ModalidadServicioEntity> _modalidadesServicio;

        public List<ModalidadServicioEntity> ModalidadesServicio
        {
            get
            {
                return _modalidadesServicio;
            }

            set
            {
                _modalidadesServicio = value;
                NotifyPropertyChanged();
            }
        }

        private List<TipoAmbientacionEntity> _tiposAmbientacion;

        public List<TipoAmbientacionEntity> TiposAmbientacion
        {
            get
            {
                return _tiposAmbientacion;
            }

            set
            {
                _tiposAmbientacion = value;
                NotifyPropertyChanged();
            }
        }

        public AdministracionContratoViewModel()
        {
            ContratoDAO = new ContratoDAO();
            TipoEventoDAO = new TipoEventoDAO();
            ModalidadServicioDAO = new ModalidadServicioDAO();
            ClienteDAO = new ClienteDAO();
            TipoAmbientacionDAO = new TipoAmbientacionDAO();

            Contrato = new NullContratoEntity();

            Contrato.PropertyChanged += Contrato_PropertyChanged;



            TiposEvento = TipoEventoDAO.BuscarTodo();

            

            List<TipoAmbientacionEntity> tiposAmbientacion = TipoAmbientacionDAO.ObtenerTodo();

            // Para los tipos de ambientación opcional

            tiposAmbientacion.Insert(0, new NullTipoAmbientacionEntity());

            TiposAmbientacion = tiposAmbientacion;
        }


        private void Contrato_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tipo")
            {

                if (Contrato.Tipo == null)
                {
                    return;
                }


                try
                {
                    this.ModalidadesServicio = ModalidadServicioDAO.BuscarPorIdTipoEvento(Contrato.Tipo.Id);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error al cargar la información de los tipos de evento. Por favor, contacte al administrador");
                    this.ModalidadesServicio = null;
                }

              


            }
            else if(e.PropertyName == "ModalidadServicio")
            {
                if(Contrato.ModalidadServicio != null)
                {


                    Contrato.PrecioTotal = Valorizador.CalcularTotal((int)Contrato.ModalidadServicio.ValorBase, Contrato.Asistentes, Contrato.PersonalAdicional);

                }
            }
        }

        private RelayCommand _crearContratoCommand;

        public ICommand CrearContratoCommand
        {
            get
            {
                if (_crearContratoCommand == null)
                {
                    _crearContratoCommand = new RelayCommand(CrearContratoCommandHandler, CanCrearContrato);
                }

                return _crearContratoCommand;
            }
        }

        private bool CanCrearContrato(object parameters)
        {
            return true;
        }


        public void CrearContratoCommandHandler(object parameters)
        {
            this.Contrato = new NullContratoEntity();
        }

        // BuscarContratoCommand

        private RelayCommand _buscarContratoCommand;

        public ICommand BuscarContratoCommand
        {
            get
            {
                if (_buscarContratoCommand == null)
                {
                    _buscarContratoCommand = new RelayCommand(BuscarContratoCommandHandler, CanBuscarContrato);
                }

                return _buscarContratoCommand;
            }
        }

        private bool CanBuscarContrato(object parameters)
        {
            return true;
        }


        public void BuscarContratoCommandHandler(object parameters)
        {
            this.Contrato = new NullContratoEntity();

            ContratoEntity contratoCoincidente = null;

            string numeroContrato = parameters.ToString();


            if (String.IsNullOrEmpty(numeroContrato))
            {
                return;
            }

            try
            {
                contratoCoincidente = ContratoDAO.BuscarPorNumero(numeroContrato);
            }
            catch(Exception ex)
            {
                Console.Write(ex);

                MessageBox.Show("Número de contrato inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (contratoCoincidente == null)
            {
                MessageBox.Show("No se encontró ningún contrato asociado al número indicado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Desplegamos la información del contrato


            try
            {
                this.Contrato = contratoCoincidente;
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar la información del contrato");
            }
        }

        // GuardarContratoCommandHandler

        private RelayCommand _guardarContratoCommand;

        public ICommand GuardarContratoCommand
        {
            get
            {
                if (_guardarContratoCommand == null)
                {
                    _guardarContratoCommand = new RelayCommand(GuardarContratoCommandHandler, CanGuardarContrato);
                }

                return _guardarContratoCommand;
            }
        }

        private bool CanGuardarContrato(object parameters)
        {
            ResultadoValidacion resultadoValidacionCampos =
                ValidacionesContrato.CamposObligatorios(this.Contrato);

            if(resultadoValidacionCampos.Exito == false)
            {
                MessageBox.Show(resultadoValidacionCampos.MensajeError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            ResultadoValidacion resultadoValidacionFechas =
                ValidacionesContrato.Fechas(this.Contrato.InicioEvento, this.Contrato.TerminoEvento, this.Contrato.Creacion);

            if(resultadoValidacionFechas.Exito == false)
            {
                MessageBox.Show(resultadoValidacionFechas.MensajeError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        public void GuardarContratoCommandHandler(object parameters)
        {
            // Creamos o modificamos un contrato


            bool existeContrato = false;


            if (!String.IsNullOrEmpty(Contrato.NumeroContrato))
            {
                if (ContratoDAO.BuscarPorNumero(Contrato.NumeroContrato) != null)
                {
                    existeContrato = true;
                }
            }


            if (existeContrato == false)
            {
                this.Contrato.NumeroContrato = DateTime.Now.ToString("yyyyMMddHHmm");
                ContratoDAO.Crear(this.Contrato);
            }
            else
            {
                ContratoDAO.Modificar(this.Contrato);
            }

            MessageBox.Show("Guardado correctamente");
        }

        // TerminarContratoHnadler

        private RelayCommand _terminarContratoCommand;

        public ICommand TerminarContratoCommand
        {
            get
            {
                if (_terminarContratoCommand == null)
                {
                    _terminarContratoCommand = new RelayCommand(TerminarContratoCommandHandler, CanTerminarContrato);
                }

                return _terminarContratoCommand;
            }
        }

        private bool CanTerminarContrato(object parameters)
        {
            return true;
        }


        public void TerminarContratoCommandHandler(object parameters)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Esta acción no puede ser revertida. ¿Desea terminar el contrato?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                this.Contrato.Termino = DateTime.Now;

                MessageBox.Show("Asignada fecha de término de contrato. Debe guardar los cambios para completar la operación.", "Acción");

            }


        }

        // AbrirAuxiliarCommand

        private RelayCommand _abrirAuxiliarCommand;

        public ICommand AbrirAuxiliarCommand
        {
            get
            {
                if (_abrirAuxiliarCommand == null)
                {
                    _abrirAuxiliarCommand = new RelayCommand(AbrirAuxiliarCommandHandler, CanAbrirAuxiliar);
                }

                return _abrirAuxiliarCommand;
            }
        }

        private bool CanAbrirAuxiliar(object parameters)
        {
            return true;
        }


        public void AbrirAuxiliarCommandHandler(object parameters)
        {
            ListadoContratosView listadoAuxiliar = new ListadoContratosView(); // Lo llamamos como auxiliar de búsqueda

            // Aprovechamos el patrón decorator para implementar funcionalidad extra sin romper MVVM

            ListadoAuxiliarDecorator listadoAuxiliarDecorator = new ListadoAuxiliarDecorator();

            listadoAuxiliarDecorator.SetComponent(listadoAuxiliar); // Le asignamos el componente


            listadoAuxiliar.Show();

            listadoAuxiliarDecorator.SeleccionContrato += (listado, args) =>
            {
                if(args.Contrato == null)
                {
                    this.Contrato = new NullContratoEntity();
                }

                this.Contrato = args.Contrato;

                if (args.Contrato.Cliente == null)
                {
                    this.Contrato.Cliente = new NullClienteEntity();
                    this.RutBusquedaCliente = null;
                }
                else
                {
                    this.Contrato.Cliente = args.Contrato.Cliente;
                    this.RutBusquedaCliente = args.Contrato.Cliente.Rut;
                }

                listadoAuxiliar.Close();
            };
        }

        // AbrirAuxiliarClienteCommand


        private RelayCommand _abrirAuxiliarClienteCommand;

        public ICommand AbrirAuxiliarClienteCommand
        {
            get
            {
                if (_abrirAuxiliarClienteCommand == null)
                {
                    _abrirAuxiliarClienteCommand = new RelayCommand(AbrirAuxiliarClienteCommandHandler, CanAbrirAuxiliarCliente);
                }

                return _abrirAuxiliarClienteCommand;
            }
        }

        private bool CanAbrirAuxiliarCliente(object parameters)
        {
            return true;
        }


        public void AbrirAuxiliarClienteCommandHandler(object parameters)
        {
            ListadoClientes listadoClientes = new ListadoClientes(ClienteDAO, true);

            listadoClientes.Show();

            listadoClientes.SeleccionCliente += (listado, args) =>
            {
                if(args.Cliente == null)
                {
                    this.Contrato.Cliente =  new NullClienteEntity();
                    this.RutBusquedaCliente = null;
                }
                else
                {
                    this.Contrato.Cliente = args.Cliente;
                    this.RutBusquedaCliente = args.Cliente.Rut;
                }

                listadoClientes.Close(); // Eliminamos la ventana auxiliar
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
