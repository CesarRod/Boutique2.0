using Npgsql;
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
    /// Interaction logic for showPreferences.xaml
    /// </summary>
    public partial class showPreferences : Window
    {
        Conexion con;
        string idClient = "";
        public showPreferences()
        {
            InitializeComponent();
            con = new Conexion();
        }
        public void  busquedaFunc(object sender, RoutedEventArgs e)
        {
            lista.ItemsSource = con.QueryTable("SELECT * FROM cliente WHERE nombre ilike '%" + nombre.Text + "%'").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void atras_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView)lista.SelectedItem;
            idClient = selectedItem["id_cliente"].ToString();
            string query = $"SELECT talla,descripcion,tipo_prenda FROM preferencia where id_cliente={idClient}";
            lista.ItemsSource = con.QueryTable(query).DefaultView;
            //MessageBox.Show("Seleccionado correctamente");
        }
        private void clir (object sender, RoutedEventArgs e)
        {
             
            lista.ItemsSource = new DataTable().DefaultView;
        }
    }
}
