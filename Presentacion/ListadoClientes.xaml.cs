using MahApps.Metro.Controls;
using Persistencia.lib.dao;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace OnBreakEventos
{
    /// <summary>
    /// Interaction logic for ListadoClientes.xaml
    /// </summary>
    /// 

    public class SeleccionClienteArgs : EventArgs
    {
        private ClienteEntity cliente;

        public ClienteEntity Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

    }
    public partial class ListadoClientes : MetroWindow
    {

        private ClienteDAO clienteDAO;

        public ClienteDAO ClienteDAO
        {
            get { return clienteDAO; }
            set { clienteDAO = value; }
        }

        public event SeleccionClienteHandler SeleccionCliente;
        public delegate void SeleccionClienteHandler(ListadoClientes listadoClientes, SeleccionClienteArgs seleccionClienteArgs);


        public ListadoClientes(ClienteDAO clienteDAO, bool comoAuxiliarBusqueda = false)
        {
            InitializeComponent();

            this.ClienteDAO = clienteDAO;


            dg_clientes.ItemsSource = this.ClienteDAO.BuscarTodo();

            if(comoAuxiliarBusqueda)
            {
                btn_seleccionar.Visibility = Visibility.Visible;
                this.ShowActivated = true;
            }
        }


        private void Btn_refrescarContratos_Click(object sender, RoutedEventArgs e)
        {
            dg_clientes.Items.Refresh();
        }


        private void Txt_filtro_TextChanged(object sender, TextChangedEventArgs e)
        {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dg_clientes.ItemsSource);


            if (String.IsNullOrEmpty(txt_filtro.Text))
            {
                collectionView.Filter = null;
                return;
            }


            if (cmb_tipoFiltro.SelectedIndex != 0)
            { // Si es que no está seleccionada la opción 'sin filtro'

                if(cmb_tipoFiltro.SelectedIndex == 1) // RUT
                {
                    collectionView.Filter = new Predicate<object>(item => 
                    ((ClienteEntity)item).Rut.Contains(txt_filtro.Text.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if(cmb_tipoFiltro.SelectedIndex == 2) // Razon social
                {
                    collectionView.Filter = new Predicate<object>(item => ((ClienteEntity)item).RazonSocial.ToUpper().Contains(txt_filtro.Text.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if(cmb_tipoFiltro.SelectedIndex == 3) // Tipo actividad
                {
                    collectionView.Filter = new Predicate<object>(item => ((ClienteEntity)item).Actividad.ToString().ToUpper().Contains(txt_filtro.Text.ToUpper().Replace("\r\n", string.Empty)));
                }
                else if(cmb_tipoFiltro.SelectedIndex == 4)
                {
                    collectionView.Filter = new Predicate<object>(item => ((ClienteEntity)item).Tipo.ToString().ToUpper().Contains(txt_filtro.Text.ToUpper().Replace("\r\n", string.Empty)));
                }
            }
        }

        private void Btn_seleccionar_Click(object sender, RoutedEventArgs e)
        {
            if(dg_clientes.SelectedItem != null)
            {
                SeleccionClienteArgs args = new SeleccionClienteArgs();

                args.Cliente = (ClienteEntity)dg_clientes.SelectedItem;

                SeleccionCliente(this, args);
            }
        }
    }
}
