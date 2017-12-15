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

namespace Bases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createClient(object sender, RoutedEventArgs e)
        {
            var window = new createClient { Owner = this };
            window.Show();
            
        }

        private void preferencesClient(object sender, RoutedEventArgs e)
        {
            var window = new preferences { Owner = this };
            window.Show();
        }

        private void altaArticulo(object sender, RoutedEventArgs e)
        {
            var window = new Inventario { Owner = this };
            window.Show();
        }
        private void bajaArticulo(object sender, RoutedEventArgs e)
        {
            var window = new InventarioBajas  { Owner = this };
            window.Show();
        }
        private void modificarArticulo(object sender, RoutedEventArgs e)
        {
            var window = new inventarioModificar { Owner = this };
            window.Show();

        }
        private void listaArticulos( object sender, RoutedEventArgs e)
        {
            var window = new inventarioShow { Owner = this };
            window.Show();
        }
        private void altaProveedores(object sender, RoutedEventArgs e)
        {
            var window = new proveedoresAlta { Owner = this };
            window.Show();
        }
        private void modificarProveedor(object sender, RoutedEventArgs e)
        {
            var window = new proveedoresModificar { Owner = this };
            window.Show();
        }
        private void bajaProveedor(object sender, RoutedEventArgs e)
        {
            var window = new proveedoresBaja { Owner = this };
            window.Show();
        }
        private void generarPedido( object sender, RoutedEventArgs e)
        {
            var window = new pedidosGenerar { Owner = this };
            window.Show();
        }
        private void listaProveedor( object sender, RoutedEventArgs e)
        {
            var window = new proveedoresLista { Owner = this };
            window.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new showPreferences { Owner = this };
            window.Show();
        }
        private void nuevoAbono (object sender, RoutedEventArgs e)
        {
            var window = new nuevoAbono { Owner = this };
            window.Show();
        }
        private void nuevoApartado (object sender, RoutedEventArgs e)
        {
            var window = new nuevoApartado { Owner = this };
            window.Show();

        }
    }
}
