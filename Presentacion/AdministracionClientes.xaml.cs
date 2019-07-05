using MahApps.Metro.Controls;
using OnBreakEventos;
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
using System.Windows.Shapes;
using Persistencia.lib.dao;
using Persistencia.lib.entity;
using System.Text.RegularExpressions;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for AdministracionClientes.xaml
    /// </summary>
    public partial class AdministracionClientes : MetroWindow
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

        private ActividadEmpresaDAO actividadEmpresaDAO;

        public ActividadEmpresaDAO ActividadEmpresaDAO
        {
            get { return actividadEmpresaDAO; }
            set { actividadEmpresaDAO = value; }
        }

        private TipoEmpresaDAO tipoEmpresaDAO;

        public TipoEmpresaDAO TipoEmpresaDAO
        {
            get { return tipoEmpresaDAO; }
            set { tipoEmpresaDAO = value; }
        }


        public AdministracionClientes(ClienteDAO clienteDAO, ContratoDAO contratoDAO, ActividadEmpresaDAO actividadEmpresaDAO, TipoEmpresaDAO tipoEmpresaDAO)
        {
            InitializeComponent();

            this.ClienteDAO = clienteDAO;
            this.ContratoDAO = contratoDAO;
            this.ActividadEmpresaDAO = actividadEmpresaDAO;
            this.TipoEmpresaDAO = tipoEmpresaDAO;
            
            // Añadimos los valores de actividad

            foreach (ActividadEmpresaEntity actividad in actividadEmpresaDAO.BuscarTodo())
            {
                cmb_actividad.Items.Add(actividad);
            }

            // Y los tipos de empresa

            foreach(TipoEmpresaEntity tipoEmpresa in tipoEmpresaDAO.BuscarTodo())
            {
                cmb_tipo.Items.Add(tipoEmpresa);
            }

            RegistroNuevo();
        }

        private void RegistroNuevo()
        {
            btn_eliminarCliente.Visibility = Visibility.Hidden;
            btn_modificarCliente.Visibility = Visibility.Hidden;
            btn_agregarCliente.Visibility = Visibility.Visible;
            tb_rut.IsEnabled = true;
            Btn_limpiar_Click();
        }

        private void RegistroAnterior()
        {
            btn_eliminarCliente.Visibility = Visibility.Visible;
            btn_modificarCliente.Visibility = Visibility.Visible;
            btn_agregarCliente.Visibility = Visibility.Hidden;
            tb_rut.IsEnabled = false;
            //Btn_limpiar_Click();
        }


        private void Btn_limpiar_Click()
        {
            tb_rut.Text = "";
            tb_razon_social.Text = "";
            tb_telefono.Text = "";
            tb_direccion.Text = "";
            txt_emailContacto.Text = "";
            txt_nombreContacto.Text = "";
            cmb_actividad.SelectedItem = null;
            cmb_tipo.SelectedItem = null;
            dg_contratos.ItemsSource = null;
        }

        

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            ClienteEntity cliente = ClienteDAO.BuscarPorRut(tb_rut.Text);

            if (cliente != null)
            {
                tb_razon_social.Text = cliente.RazonSocial;
                tb_direccion.Text = cliente.Direccion;
                tb_telefono.Text = cliente.Telefono;
                cmb_actividad.SelectedItem = cmb_actividad.Items.Cast<ActividadEmpresaEntity>().SingleOrDefault(actividad => actividad.Id == cliente.Actividad.Id);
                cmb_tipo.SelectedItem = cmb_tipo.Items.Cast<TipoEmpresaEntity>().SingleOrDefault(tipo => tipo.Id == cliente.Tipo.Id);
                txt_nombreContacto.Text = cliente.NombreContacto;
                txt_emailContacto.Text = cliente.MailContacto;

                dg_contratos.ItemsSource = this.ContratoDAO.BuscarContratosCliente(cliente);
                RegistroAnterior();
            }
            else
            {
                RegistroNuevo();
                MessageBox.Show("Cliente no registrado");
            }

        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {

            if (!CumpleConCamposObligatorios())
            {
                MessageBox.Show("Se deben completar los campos obligatorios", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string errorValidacion = ValidarCampos();

            if (errorValidacion != null)
            {
                MessageBox.Show(errorValidacion, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            ClienteEntity cliente = new ClienteEntity();

            cliente.Rut = tb_rut.Text;
            cliente.RazonSocial = tb_razon_social.Text;
            cliente.Telefono = tb_telefono.Text;
            cliente.Direccion = tb_direccion.Text;
            cliente.Actividad = (ActividadEmpresaEntity) cmb_actividad.SelectedItem;
            cliente.Tipo = (TipoEmpresaEntity)cmb_tipo.SelectedItem;
            cliente.NombreContacto = txt_nombreContacto.Text;
            cliente.MailContacto = txt_emailContacto.Text;

            try
            {
                ClienteDAO.Crear(cliente);
                MessageBox.Show("Cliente Registrado ->" + ClienteDAO.BuscarTodo().Count());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RegistroNuevo();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {

            ClienteEntity cliente = ClienteDAO.BuscarPorRut(tb_rut.Text);

            if(cliente != null)
            {

                if (ContratoDAO.BuscarContratosCliente(cliente).Count != 0) // Si el cliente tiene contratos creados, no se puede eliminar (ABP 2)
                {
                    MessageBox.Show("No se puede eliminar un cliente con contratos asociados", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }


            ClienteDAO.Eliminar(tb_rut.Text);
            MessageBox.Show("Cliente Eliminado");
            RegistroNuevo();

            /*

            if (cliente != null)
            {
                ColeccionClientes.borrar(tb_rut.Text);
                MessageBox.Show("Cliente Eliminado");
            }
            else
            {
                MessageBox.Show("Cliente no registrado");
            }
            */            
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if(!CumpleConCamposObligatorios())
            {
                MessageBox.Show("Se deben completar los campos obligatorios", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string errorValidacion = ValidarCampos();

            if (errorValidacion != null)
            {
                MessageBox.Show(errorValidacion, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            ClienteEntity cliente = new ClienteEntity();

            cliente.Rut = tb_rut.Text;
            cliente.RazonSocial = tb_razon_social.Text;
            cliente.Direccion = tb_direccion.Text;
            cliente.Telefono = tb_telefono.Text;
            cliente.Actividad = (ActividadEmpresaEntity) cmb_actividad.SelectedItem;
            cliente.Tipo = (TipoEmpresaEntity)cmb_tipo.SelectedItem;
            cliente.NombreContacto = txt_nombreContacto.Text;
            cliente.MailContacto = txt_emailContacto.Text;

            ClienteDAO.Modificar(cliente);
            MessageBox.Show("Datos de cliente actualizados");
            RegistroNuevo();
        }

        private void Btn_buscarPorRutLista_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listadoClientes = new ListadoClientes(this.ClienteDAO, true);

            listadoClientes.Show();

            listadoClientes.SeleccionCliente += (listado, args) =>
            {
                tb_rut.Text = args.Cliente.Rut;
                tb_razon_social.Text = args.Cliente.RazonSocial;
                tb_direccion.Text = args.Cliente.Direccion;
                tb_telefono.Text = args.Cliente.Telefono;
                cmb_actividad.SelectedItem = cmb_actividad.Items.Cast<ActividadEmpresaEntity>().SingleOrDefault(actividad => actividad.Id == args.Cliente.Actividad.Id);
                cmb_tipo.SelectedItem = cmb_tipo.Items.Cast<TipoEmpresaEntity>().SingleOrDefault(tipo => tipo.Id == args.Cliente.Tipo.Id);
                txt_emailContacto.Text = args.Cliente.MailContacto;
                txt_nombreContacto.Text = args.Cliente.NombreContacto;

                // Traemos los contratos del cliente

                dg_contratos.ItemsSource = this.ContratoDAO.BuscarContratosCliente(args.Cliente);

                this.Activate();

                listadoClientes.Close(); // Eliminamos la ventana auxiliar

                RegistroAnterior();
            };

        }

        private string ValidarCampos()
        {
            if( tb_rut.Text.Length > 9)
            {
                return "RUT Inválido";
            }

            // Revisamos la validez del rut. Debe ser un número
            try
            {
                int.Parse(tb_rut.Text);
            }
            catch
            {
                return "RUT inválido. Ingréselo sin puntos o guiones.";
            }

            if(tb_telefono.Text.Length != 11 || !Regex.IsMatch(tb_telefono.Text, @"^\d+$")) 
            {
                return "Teléfono inválido. Debe incluir el código de area sin +.";
            }

            return null;
        }

        private bool CumpleConCamposObligatorios()
        {
            if(String.IsNullOrEmpty(tb_rut.Text))
            {
                return false;
            }

            if(String.IsNullOrEmpty(tb_direccion.Text))
            {
                return false;
            }


            if (String.IsNullOrEmpty(tb_telefono.Text))
            {
                return false;
            }


            if (String.IsNullOrEmpty(txt_nombreContacto.Text))
            {
                return false;
            }


            if (String.IsNullOrEmpty(txt_nombreContacto.Text))
            {
                return false;
            }

            if (cmb_actividad.SelectedItem == null)
            {
                return false;
            }

            if(cmb_tipo.SelectedItem == null)
            {
                return false;
            }

            return true;
        }
    }
}
