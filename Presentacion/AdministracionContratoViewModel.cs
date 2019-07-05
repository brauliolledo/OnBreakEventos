using Negocio;
using Persistencia.lib.caretaker;
using Persistencia.lib.dao;
using Persistencia.lib.entity;
using Presentacion.app.lib;
using SubsidiosMinvu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Persitencia.lib.memento;

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

        public ValorizadorDecorator ValorizadorDecorator;

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
                    NotifyPropertyChanged();
                    return;
                }

                if (value.Length > 9)
                {
                    MessageBox.Show("RUT Inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Contrato.Cliente = new NullClienteEntity();
                    _rutBusquedaCliente = null;
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                        ValorizarEvento();
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

            this.ValorizadorDecorator = new ValorizadorTipoEventoDecorator();

            this.ValorizadorDecorator.SetComponent(new Valorizador());
        }


        public void ValorizarEvento()
        {
            // Usamos el decorator para poder pasarle un tipo de Eventor por parametros

            if(this.Contrato.Tipo == null || this.Contrato.ModalidadServicio == null)
            {
                this.Contrato.PrecioTotal = 0;
                return;
            }

            this.Contrato.PrecioTotal = (ValorizadorDecorator as ValorizadorTipoEventoDecorator).CalcularTotal(
                                                                  this.Contrato.Tipo,
                                                                  (int)this.Contrato.ModalidadServicio.ValorBase,
                                                                  this.Contrato.Asistentes,
                                                                  this.Contrato.PersonalAdicional);

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


                Contrato.Tipo.PropertyChanged += Tipo_PropertyChanged;
                

            }

            string[] propiedadesValorizador = new string[]
            {
                "TipoEvento",
                "ModalidadServicio",
                "PersonalAdicional",
                "Asistentes"
            };

            if(propiedadesValorizador.Contains(e.PropertyName))
            {
                ValorizarEvento();
            }
        }

        private void Tipo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string[] propiedadesValorizador = new string[]
            {
                "Ambientacion",
                "MusicaAmbiental",
                "LocalOnBreak",
                "OtroLocal",
                "ValorArriendo"
            };

            if (propiedadesValorizador.Contains(e.PropertyName))
            {
                ValorizarEvento();
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

        #region InicializarCacheCommand

        private RelayCommand _inicializarCacheCommand;

        public ICommand InicializarCacheCommand
        {
            get
            {
                if (_inicializarCacheCommand == null)
                {
                    _inicializarCacheCommand = new RelayCommand(InicializarCacheCommandHandler, CanInicializarCache);
                }

                return _inicializarCacheCommand;
            }
        }

        private bool CanInicializarCache(object parameters)
        {
            return true;
        }


        public void InicializarCacheCommandHandler(object parameters)
        {
            InicializarCache();
        }


        #endregion

        #region Cache

        public AdministracionContratoCaretaker Caretaker = new AdministracionContratoCaretaker();
        private Timer CrearMementoTimer;

        private AdministracionContratoMemento _mementoActual;
        public AdministracionContratoMemento MementoActual
        {
            get
            {
                return _mementoActual;
            }

            set
            {
                _mementoActual = value;
                NotifyPropertyChanged();
            }
        }

        public const int IntervaloMemento = 5 * 60 * 1000;

        public void InicializarCache()
        {
            CrearMementoTimer = new Timer(IntervaloMemento);

            CrearMementoTimer.Elapsed += CrearMementoTimer_Elapsed;

            CrearMementoTimer.Start();

            Caretaker.RestaurarMementos();

            if(Caretaker.Mementos.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Hay una sesión anterior, con {Caretaker.Mementos.Count} cachés de trabajo. ¿Desea restaurarla?", 
                    "Caché de trabajo", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    MementoActual = Caretaker.Mementos.ElementAt(Caretaker.Mementos.Count - 1);
                    RestaurarMemento(Caretaker.Mementos.ElementAt(Caretaker.Mementos.Count - 1));
                }
                else
                {
                    Caretaker.DesecharMementos();
                }
  
            }
            else
            {
                MementoActual = new NullAdministracionContratoMemento();

            }
        }

        private void CrearMementoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Guardando estado en caché.");
            AlmacenarEstadoEnCache();
        }

        public void AlmacenarEstadoEnCache()
        {
            AdministracionContratoMemento nuevoMemento = CrearMemento();

            Caretaker.Mementos.Add(nuevoMemento);
            MementoActual = nuevoMemento;
        }

        public AdministracionContratoMemento CrearMemento()
        {
            ContratoEntity contrato;

            TipoEventoEntity tipoEvento = null;

            if (this.Contrato.Tipo != null)
            {
                if (this.Contrato.Tipo is CoffeeBreakEntity)
                {
                    tipoEvento = new CoffeeBreakEntity()
                    {
                        Id = this.Contrato.Tipo.Id,
                        Descripcion = this.Contrato.Tipo.Descripcion,
                        Vegetariana = (this.Contrato.Tipo as CoffeeBreakEntity).Vegetariana
                    };
                }
                else if (this.Contrato.Tipo is CocktailEntity)
                {
                    tipoEvento = new CocktailEntity()
                    {
                        Id = this.Contrato.Tipo.Id,
                        Descripcion = this.Contrato.Tipo.Descripcion,
                        Ambientacion = ((this.Contrato.Tipo as CocktailEntity).Ambientacion == null) ? new NullTipoAmbientacionEntity() : (this.Contrato.Tipo as CocktailEntity).Ambientacion,
                        MusicaAmbiental = (this.Contrato.Tipo as CocktailEntity).MusicaAmbiental,
                        MusicaCliente = (this.Contrato.Tipo as CocktailEntity).MusicaCliente
                    };
                }
                else if (this.Contrato.Tipo is CenaEntity)
                {
                    tipoEvento = new CenaEntity()
                    {
                        Id = this.Contrato.Tipo.Id,
                        Descripcion = this.Contrato.Tipo.Descripcion,
                        Ambientacion = ((this.Contrato.Tipo as CenaEntity).Ambientacion == null) ? new NullTipoAmbientacionEntity() : (this.Contrato.Tipo as CocktailEntity).Ambientacion,
                        MusicaAmbiental = (this.Contrato.Tipo as CenaEntity).MusicaAmbiental,
                        LocalOnBreak = (this.Contrato.Tipo as CenaEntity).LocalOnBreak,
                        OtroLocal = (this.Contrato.Tipo as CenaEntity).OtroLocal,
                        ValorArriendo = (this.Contrato.Tipo as CenaEntity).ValorArriendo
                    };
                }
                else
                {
                    tipoEvento = new TipoEventoEntity()
                    {
                        Id = this.Contrato.Tipo.Id,
                        Descripcion = this.Contrato.Tipo.Descripcion,
                    };
                }
            }

            if (this.Contrato is NullContratoEntity)
            {
                contrato = new NullContratoEntity()
                {
                    Asistentes = this.Contrato.Asistentes,
                    Cliente = this.Contrato.Cliente,
                    Tipo = tipoEvento,
                    Creacion = this.Contrato.Creacion,
                    InicioEvento = this.Contrato.InicioEvento,
                    ModalidadServicio = this.Contrato.ModalidadServicio,
                    NumeroContrato = this.Contrato.NumeroContrato,
                    Observaciones = this.Contrato.Observaciones,
                    PersonalAdicional = this.Contrato.PersonalAdicional,
                    PrecioTotal = this.Contrato.PrecioTotal,
                    Realizado = this.Contrato.Realizado,
                    Termino = this.Contrato.Termino,
                    TerminoEvento = this.Contrato.TerminoEvento
                    
                };
            }
            else
            {
                contrato = new ContratoEntity()
                {
                    Asistentes = this.Contrato.Asistentes,
                    Cliente = this.Contrato.Cliente,
                    Tipo = tipoEvento,
                    Creacion = this.Contrato.Creacion,
                    InicioEvento = this.Contrato.InicioEvento,
                    ModalidadServicio = this.Contrato.ModalidadServicio,
                    NumeroContrato = this.Contrato.NumeroContrato,
                    Observaciones = this.Contrato.Observaciones,
                    PersonalAdicional = this.Contrato.PersonalAdicional,
                    PrecioTotal = this.Contrato.PrecioTotal,
                    Realizado = this.Contrato.Realizado,
                    Termino = this.Contrato.Termino,
                    TerminoEvento = this.Contrato.TerminoEvento

                };
            
            }

            return new AdministracionContratoMemento()
            {
                FechaHora = DateTime.Now,
                Contrato = contrato
            };
        }

        public void RestaurarMemento(AdministracionContratoMemento memento)
        {
            if (memento.Contrato == null)
            {
                this.Contrato = new NullContratoEntity();
            }

            MementoActual = memento;

            TipoEventoEntity tipoEvento = null;

            if(memento.Contrato.Tipo != null)
            {
                if (memento.Contrato.Tipo is CoffeeBreakEntity)
                {
                    tipoEvento = new CoffeeBreakEntity()
                    {
                        Id = memento.Contrato.Tipo.Id,
                        Descripcion = memento.Contrato.Tipo.Descripcion,
                        Vegetariana = (memento.Contrato.Tipo as CoffeeBreakEntity).Vegetariana
                    };
                }
                else if (memento.Contrato.Tipo is CocktailEntity)
                {
                    tipoEvento = new CocktailEntity()
                    {
                        Id = memento.Contrato.Tipo.Id,
                        Descripcion = memento.Contrato.Tipo.Descripcion,
                        Ambientacion = ((memento.Contrato.Tipo as CocktailEntity).Ambientacion == null) ? new NullTipoAmbientacionEntity() : (memento.Contrato.Tipo as CocktailEntity).Ambientacion,
                        MusicaAmbiental = (memento.Contrato.Tipo as CocktailEntity).MusicaAmbiental,
                        MusicaCliente = (memento.Contrato.Tipo as CocktailEntity).MusicaCliente
                    };
                }
                else if (memento.Contrato.Tipo is CenaEntity)
                {
                    tipoEvento = new CenaEntity()
                    {
                        Id = memento.Contrato.Tipo.Id,
                        Descripcion = memento.Contrato.Tipo.Descripcion,
                        Ambientacion = ((memento.Contrato.Tipo as CocktailEntity).Ambientacion == null) ? new NullTipoAmbientacionEntity() : (memento.Contrato.Tipo as CocktailEntity).Ambientacion,
                        MusicaAmbiental = (memento.Contrato.Tipo as CocktailEntity).MusicaAmbiental,
                        LocalOnBreak = (memento.Contrato.Tipo as CenaEntity).LocalOnBreak,
                        OtroLocal = (memento.Contrato.Tipo as CenaEntity).OtroLocal,
                        ValorArriendo = (memento.Contrato.Tipo as CenaEntity).ValorArriendo
                    };
                }
                else
                {
                    tipoEvento = new TipoEventoEntity()
                    {
                        Id = memento.Contrato.Tipo.Id,
                        Descripcion = memento.Contrato.Tipo.Descripcion,
                    };
                }
            }



            if (this.Contrato is NullContratoEntity)
            {
                this.Contrato = new NullContratoEntity()
                {
                    Asistentes = memento.Contrato.Asistentes,
                    Cliente = memento.Contrato.Cliente ?? new NullClienteEntity(),
                    Tipo = tipoEvento,
                    Creacion = memento.Contrato.Creacion,
                    InicioEvento = memento.Contrato.InicioEvento,
                    ModalidadServicio = memento.Contrato.ModalidadServicio,
                    NumeroContrato = memento.Contrato.NumeroContrato,
                    Observaciones = memento.Contrato.Observaciones,
                    PersonalAdicional = memento.Contrato.PersonalAdicional,
                    PrecioTotal = memento.Contrato.PrecioTotal,
                    Realizado = memento.Contrato.Realizado,
                    Termino = memento.Contrato.Termino,
                    TerminoEvento = memento.Contrato.TerminoEvento

                };
            }
            else
            {
                this.Contrato = new ContratoEntity()
                {
                    Asistentes = memento.Contrato.Asistentes,
                    Cliente = memento.Contrato.Cliente ?? new NullClienteEntity(),
                    Tipo = tipoEvento,
                    Creacion = memento.Contrato.Creacion,
                    InicioEvento = memento.Contrato.InicioEvento,
                    ModalidadServicio = memento.Contrato.ModalidadServicio,
                    NumeroContrato = memento.Contrato.NumeroContrato,
                    Observaciones = memento.Contrato.Observaciones,
                    PersonalAdicional = memento.Contrato.PersonalAdicional,
                    PrecioTotal = memento.Contrato.PrecioTotal,
                    Realizado = memento.Contrato.Realizado,
                    Termino = memento.Contrato.Termino,
                    TerminoEvento = memento.Contrato.TerminoEvento

                };

            }

            if (memento.Contrato.Cliente is NullClienteEntity)
            {
                this.RutBusquedaCliente = null;
            }
            else
            {
                this.Contrato.Cliente = memento.Contrato.Cliente;
                this.RutBusquedaCliente = memento.Contrato.Cliente.Rut;
            }
        }

        #region Comandos Memento

        #region RespaldarMementoCommand
        private RelayCommand _respaldarMementoCommand;

        public ICommand RespaldarMementoCommand
        {
            get
            {
                if (_respaldarMementoCommand == null)
                {
                    _respaldarMementoCommand = new RelayCommand(RespaldarMementoCommandHandler, CanRespaldarMemento);
                }

                return _respaldarMementoCommand;
            }
        }

        private bool CanRespaldarMemento(object parameters)
        {
            return true;
        }


        public void RespaldarMementoCommandHandler(object parameters)
        {
            AlmacenarEstadoEnCache();
            Caretaker.PersistirMementos();
        }

        #endregion

        #region MementoAnteriorCommand


        private RelayCommand _mementoAnteriorCommand;

        public ICommand MementoAnteriorCommand
        {
            get
            {
                if (_mementoAnteriorCommand == null)
                {
                    _mementoAnteriorCommand = new RelayCommand(MementoAnteriorCommandHandler, CanMementoAnterior);
                }

                return _mementoAnteriorCommand;
            }
        }

        private bool CanMementoAnterior(object parameters)
        {
            return true;
        }


        public void MementoAnteriorCommandHandler(object parameters)
        {
            if(Caretaker.Mementos.Count == 0)
            {
                return;
            }

            int indice = (Caretaker.Mementos.Count == 1 || Caretaker.Mementos.IndexOf(MementoActual) == 0) ? 
                                0 : 
                                Caretaker.Mementos.IndexOf(MementoActual) - 1;

            if(indice < 0)
            {
                return;
            }

            RestaurarMemento(Caretaker.Mementos.ElementAt(indice));
            
        }
        #endregion

        #region MementoSiguienteCommand


        private RelayCommand _mementoSiguienteCommand;

        public ICommand MementoSiguienteCommand
        {
            get
            {
                if (_mementoSiguienteCommand == null)
                {
                    _mementoSiguienteCommand = new RelayCommand(MementoSiguienteCommandHandler, CanMementoSiguiente);
                }

                return _mementoSiguienteCommand;
            }
        }

        private bool CanMementoSiguiente(object parameters)
        {
            return true;
        }


        public void MementoSiguienteCommandHandler(object parameters)
        {
            if (Caretaker.Mementos.Count == 0)
            {
                return;
            }

            int indice = (Caretaker.Mementos.IndexOf(MementoActual) + 1 == Caretaker.Mementos.Count ) ? Caretaker.Mementos.Count - 1 : Caretaker.Mementos.IndexOf(MementoActual) + 1;

            RestaurarMemento(Caretaker.Mementos.ElementAt(indice));

        }
        #endregion

        #endregion

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
