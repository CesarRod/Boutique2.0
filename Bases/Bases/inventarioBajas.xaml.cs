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
    /// Interaction logic for inventarioBajas.xaml
    /// </summary>
    public partial class InventarioBajas : Window
    {
        Conexion con;
        public InventarioBajas()
        {
            InitializeComponent();
            con = new Conexion();
        }

        private void atras_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }

        private void busqueda(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM articulo WHERE modelo ilike '%" + modelo.Text + "%'";
            try
            {
                lista.ItemsSource = con.QueryTable(query).DefaultView;
                lista.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void borrarFunc (object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView) lista.SelectedItem;
            var idToErase = selectedItem["id_articulo"].ToString();

            try
            {
                var result = MessageBox.Show("¿Seguro que desea eliminar este articulo?", "Warning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    con.Query("DELETE FROM articulo WHERE id_articulo=" + idToErase);
                    MessageBox.Show("articulo eliminado correctamente", "Exito");

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }

}

