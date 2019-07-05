using MahApps.Metro;
using MahApps.Metro.Controls;
using OnBreakEventos;
using Persistencia.lib.dao;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private ClienteDAO clienteDAO;

        public ClienteDAO ClienteDAO
        {
            get { return clienteDAO; }
            set { clienteDAO = value; }
        }

        private ContratoDAO contratoDAO;

        public ContratoDAO ContratoDAO
        {
            get { return contratoDAO; }
            set { contratoDAO = value; }
        }

        private TipoEventoDAO tipoEventoDAO;

        public TipoEventoDAO TipoEventoDAO
        {
            get { return tipoEventoDAO; }
            set { tipoEventoDAO = value; }
        }

        private TipoEmpresaDAO tipoEmpresaDAO;

        public TipoEmpresaDAO TipoEmpresaDAO
        {
            get { return tipoEmpresaDAO; }
            set { tipoEmpresaDAO = value; }
        }

        private ActividadEmpresaDAO actividadEmpresaDAO;

        public ActividadEmpresaDAO ActividadEmpresaDAO
        {
            get { return actividadEmpresaDAO; }
            set { actividadEmpresaDAO = value; }
        }

        private ModalidadServicioDAO modalidadServicioDAO;

        public ModalidadServicioDAO ModalidadServicioDAO
        {
            get { return modalidadServicioDAO; }
            set { modalidadServicioDAO = value; }
        }


        public MainWindow()
        {
            InitializeComponent();


            this.clienteDAO = new ClienteDAO();
            this.contratoDAO = new ContratoDAO();
            this.actividadEmpresaDAO = new ActividadEmpresaDAO();
            this.tipoEmpresaDAO = new TipoEmpresaDAO();
            this.tipoEventoDAO = new TipoEventoDAO();
            this.modalidadServicioDAO = new ModalidadServicioDAO();
        }

        /// <summary>
        /// Nueva instancia del módulo de Administración de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_aniadir_Click(object sender, RoutedEventArgs e)
        {
            AdministracionClientes administracionClientes = new AdministracionClientes(clienteDAO, contratoDAO, actividadEmpresaDAO, tipoEmpresaDAO);

            administracionClientes.Show();
        }

        /// <summary>
        /// Nueva instancia del módulo de Administración de contratos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_contratos_Click(object sender, RoutedEventArgs e)
        {
            AdministracionContratosView administracionContratos = new AdministracionContratosView();

            administracionContratos.Show();
        }

        private void Btn_listarContratos_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratosView listadoContratos = new ListadoContratosView();

            listadoContratos.Show();
        }

        private void Btn_listarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listadoClientes = new ListadoClientes(clienteDAO);
            listadoClientes.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if(ThemeManager.DetectAppStyle().Item1.Name == "BaseLight")
            {
                ThemeManager.ChangeAppTheme(Application.Current, "BaseDark");
            }
            else
            {
                ThemeManager.ChangeAppTheme(Application.Current, "BaseLight");
            }
        }
    }
}
