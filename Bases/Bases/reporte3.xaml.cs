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
    /// Interaction logic for reporte3.xaml
    /// </summary>
    public partial class reporte3 : Window
    {

        Conexion con;

        public reporte3()
        {
            InitializeComponent();
            con = new Conexion();

            lista.ItemsSource = con.QueryTable("SELECT p.nombre AS Proveedor, a.modelo AS Modelo, a.tipo_prenda AS Tipo, SUM(c.cantidad) AS Cantidad FROM articulo a, corresponde_a c, proveedor p, VSurtido s WHERE a.id_articulo=c.id_articulo AND c.id_articulo=s.id_articulo AND s.id_proveedor=p.id_proveedor GROUP BY (p.nombre, a.tipo_prenda, a.modelo) ORDER BY (p.nombre, a.tipo_prenda);").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
