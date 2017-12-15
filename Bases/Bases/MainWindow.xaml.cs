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

        private void reporte1(object sender, RoutedEventArgs e)
        {
            var window = new reporte1 {Owner = this};
            window.Show();
        }

        private void reporte2(object sender, RoutedEventArgs e)
        {
            var window = new reporte2 {Owner = this};
            window.Show();
        }

        private void reporte3(object sender, RoutedEventArgs e)
        {
            var window = new reporte3 {Owner = this};
            window.Show();
        }

        private void reporte4(object sender, RoutedEventArgs e)
        {
            var window = new reporte4 {Owner = this};
            window.Show();
        }

        private void reporte5(object sender, RoutedEventArgs e)
        {
            var window = new reporte5 { Owner = this };
            window.Show();
        }

        private void reporte6(object sender, RoutedEventArgs e)
        {
            var window = new reporte6 { Owner = this };
            window.Show();
        }

        private void reporte7(object sender, RoutedEventArgs e)
        {
            var window = new reporte7 { Owner = this };
            window.Show();
        }

        private void reporte8(object sender, RoutedEventArgs e)
        {
            var window = new reporte8 { Owner = this };
            window.Show();
        }

        private void reporte9(object sender, RoutedEventArgs e)
        {
            var window = new reporte9 { Owner = this };
            window.Show();
        }

        private void reporte10(object sender, RoutedEventArgs e)
        {
            var window = new reporte10 { Owner = this };
            window.Show();
        }

        private void procedure1(object sender, RoutedEventArgs e)
        {
            var window = new procedure1 { Owner = this };
            window.Show();
        }
        private void procedure2(object sender, RoutedEventArgs e)
        {
            var window = new procedure2 { Owner = this };
            window.Show();
        }
        private void procedure3(object sender, RoutedEventArgs e)
        {
            var window = new procedure3 { Owner = this };
            window.Show();
        }
        private void procedure4(object sender, RoutedEventArgs e)
        {
            var window = new procedure4 { Owner = this };
            window.Show();
        }
        private void funcionExtra1(object sender, RoutedEventArgs e)
        {
            var window = new funcionExtra1 { Owner = this };
            window.Show();
        }
        private void funcionExtra2(object sender, RoutedEventArgs e)
        {
            var window = new funcionExtra2 { Owner = this };
            window.Show();
        }
    }
}
