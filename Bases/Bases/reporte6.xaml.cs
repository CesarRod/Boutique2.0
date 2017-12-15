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
    /// Interaction logic for reporte6.xaml
    /// </summary>
    public partial class reporte6 : Window
    {
        Conexion con;

        public reporte6()
        {
            InitializeComponent();
            con = new Conexion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lista.ItemsSource = con.QueryTable($"SELECT modelo AS ARTICULO, descripcion AS Descripcion, f.id_factura AS NO_FACTURA, fecha AS FECHA, (a.precio_proveedor*i.cantidad) AS MONTO, monto AS TOTAL, gasto_envio AS FLETE FROM factura f, articulo a, incluido_en i WHERE modelo ILIKE '{modelo.Text}' AND f.id_factura=i.id_factura AND i.id_articulo=a.id_articulo ORDER BY(fecha, a.id_articulo);").DefaultView;
        }
    }
}
