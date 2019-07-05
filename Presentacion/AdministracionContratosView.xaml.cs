using MahApps.Metro.Controls;


using Persistencia.lib.dao;
using Persistencia.lib.entity;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace OnBreakEventos
{
    /// <summary>
    /// Interaction logic for AdministracionContratos.xaml
    /// </summary>
    public partial class AdministracionContratosView : MetroWindow
    {

        public AdministracionContratosView(ContratoDAO contratoDAO,  ClienteDAO clienteDAO, TipoEventoDAO tipoEventoDAO, ModalidadServicioDAO modalidadServicioDAO)
        {

            InitializeComponent();
        }


      


    }
}
