using System;
using System.Collections.Generic;
using System.Data;
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

namespace Bases
{
    /// <summary>
    /// Interaction logic for proveedoresModificar.xaml
    /// </summary>
    public partial class proveedoresModificar : Window
    {
        Conexion conn;
             
        public proveedoresModificar()
        {
            InitializeComponent();
            conn = new Conexion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void busqueda (object sender, RoutedEventArgs e)
        {
            string query = "Select * FROM proveedor WHERE nombre ilike '%" + nombre.Text + "%'";
            lista.ItemsSource =  conn.QueryTable(query).DefaultView;
        }
        private void openModificar(object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView)lista.SelectedItem;
            var idToModify = selectedItem["id_proveedor"].ToString();
            proveedoresAlta prov = new proveedoresAlta(idToModify);
            prov.Show();
        }
    }
}
