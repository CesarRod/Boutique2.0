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
    /// Interaction logic for reporte8.xaml
    /// </summary>
    public partial class reporte8 : Window
    {
        Conexion con;

        public reporte8()
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
            lista.ItemsSource = con.QueryTable($"SELECT p.nombre AS Proveedor, v.fecha AS Fecha, a.modelo AS Modelo, a.descripcion AS Descripcion, i.cantidad AS Cantidad, (i.cantidad*a.precio_venta) AS Monto FROM venta v, contiene_a i, articulo a, proveedor p, vsurtido s WHERE fecha>='{fecha1.Text}' AND fecha<='{fecha2.Text}' AND v.id_venta=i.id_venta AND i.id_articulo=s.id_articulo AND p.id_proveedor=s.id_proveedor AND i.id_articulo=a.id_articulo ORDER BY(v.fecha);").DefaultView;
        }
    }
}
