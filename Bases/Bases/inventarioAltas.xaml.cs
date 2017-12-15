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

namespace Bases
{
    /// <summary>
    /// Interaction logic for inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        Conexion con;
        public Inventario()
        {
            List<String> tipos = new List<String>();
            tipos.Add("Sweater");
            tipos.Add("Blusa");
            tipos.Add("Chaleco");
            tipos.Add("Vestio");
            tipos.Add("Chamarra");
            tipos.Add("Pantalon");
            tipos.Add("Short");
            tipos.Add("Falda");
            tipos.Add("Playera");
            tipos.Add("Crop top");
            tipos.Add("Conjunto");
            tipos.Add("Saco");
            tipos.Add("Leggin");
            tipos.Add("Jumpsuit");
            
            InitializeComponent();
            tipoPrenda.CustomSource = tipos;
            con = new Conexion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string valores =  "DEFAULT,'" + modelo.Text  + "',"
                + precioVenta.Text + "," + precioProv.Text + ",'" +
                description.Text + "','" + tipoPrenda.SelectedValue + "'";
            string query = "INSERT INTO articulo(id_articulo,modelo,precio_venta, precio_proveedor, descripcion,tipo_prenda)" +
                "VALUES(" + valores + ");";
            agregar.IsEnabled = false;
            try
            {
                
                con.Query(query);
                MessageBox.Show("Articulo agregado exitosamente");
                modelo.Clear();
                precioVenta.Clear();
                precioProv.Clear();
                description.Clear();
                description.Clear();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                agregar.IsEnabled = true;
            }
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
