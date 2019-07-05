using MahApps.Metro.Controls;
using Presentacion;
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
using MahApps.Metro;

namespace OnBreakEventos
{
    /// <summary>
    /// Interaction logic for VentanaLogin.xaml
    /// </summary>
    public partial class VentanaLogin : MetroWindow
    {
        public LoginDAO LoginDAO;

        public VentanaLogin()
        {
            LoginDAO = new LoginDAO();

            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntentarAutenticacion();
        }

        private void IntentarAutenticacion()
        {
            if(String.IsNullOrEmpty(txt_usuario.Text) || String.IsNullOrEmpty(pwb_contrasena.Password))
            {
                MessageBox.Show("Debe ingresar las credenciales.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            try
            {
                if (LoginDAO.ValidarUsuario(txt_usuario.Text, pwb_contrasena.Password))
                {
                    MainWindow mainWindow = new MainWindow(); // Mostramos la ventana principal

                    mainWindow.ShowActivated = true;
                    mainWindow.Show();

                    this.Close();


                }
                else
                {
                    MessageBox.Show("No existe un usuario con ese nombre o la contraseña es inválida. Inténtelo nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al validar la información. Inténtelo nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Pwb_contrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                IntentarAutenticacion();
            }
        }
    }
}
