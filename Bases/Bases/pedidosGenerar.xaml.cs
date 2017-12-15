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
    /// Interaction logic for pedidosGenerar.xaml
    /// </summary>
    public class articulo
    {
        public string code { get; set; }
        public string modelo { get; set; }
        public string precioVenta { get; set; }
        public string precioProveedor { get; set; }
        public string descripcion { get; set; }
        public string tipoDePrenda { get; set; }
        public int cantidad { get; set; }
        public string talla { get; set; }
        public string color { get; set; }
    }
    public partial class pedidosGenerar : Window
    {
        public pedidosGenerar()
        {
            InitializeComponent();
            fecha.Text = DateTime.Now.ToString();
            List<articulo> articulos = new List<articulo>();
            tablaArticulos.Items.Add(articulos);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
