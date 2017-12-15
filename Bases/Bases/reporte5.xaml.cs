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
    /// Interaction logic for reporte5.xaml
    /// </summary>
    public partial class reporte5 : Window
    {
        Conexion con;

        public reporte5()
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
            lista.ItemsSource = con.QueryTable($"SELECT fecha AS FECHA, monto AS MONTO, gasto_envio AS FLETE, nombre AS PROVEEDOR FROM factura f, proveedor p WHERE nombre ~* '{nombre.Text}' AND f.id_proveedor=p.id_proveedor ORDER BY (fecha);").DefaultView;
        }
    }
}
