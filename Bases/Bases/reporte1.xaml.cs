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
    /// Interaction logic for reporte1.xaml
    /// </summary>
    public partial class reporte1 : Window
    {

        Conexion con;

        public reporte1()
        {
            InitializeComponent();
            con = new Conexion();

            lista.ItemsSource = con.QueryTable("SELECT a.tipo_prenda AS Tipo, SUM(c.cantidad) AS Cantidad FROM articulo a, corresponde_a c WHERE a.id_articulo=c.id_articulo GROUP BY (tipo_prenda) ORDER BY (tipo_prenda);").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
