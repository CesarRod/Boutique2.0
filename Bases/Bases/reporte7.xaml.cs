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
    /// Interaction logic for reporte7.xaml
    /// </summary>
    public partial class reporte7 : Window
    {
        Conexion con;

        public reporte7()
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
            lista.ItemsSource = con.QueryTable($"SELECT v.fecha AS Fecha, a.modelo AS MODELO, a.descripcion AS Descripcion, i.cantidad Cantidad, monto AS Monto, CONCAT(c.nombre,' ',c.apellido_paterno) AS Cliente FROM venta v, cliente c, contiene_a i, articulo a WHERE fecha>='{fecha1.Text}' AND fecha<='{fecha2.Text}' AND v.id_cliente=c.id_cliente AND v.id_venta=i.id_venta AND i.id_articulo=a.id_articulo ORDER BY(v.fecha);").DefaultView;
        }
    }
}
