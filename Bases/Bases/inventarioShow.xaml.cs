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
    /// Interaction logic for inventarioShow.xaml
    /// </summary>
    public partial class inventarioShow : Window
    {
        Conexion con;
        public inventarioShow()
        {
            InitializeComponent();
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
            tiposList.CustomSource = tipos;

            con = new Conexion();
            lista.ItemsSource = con.QueryTable("SELECT a.modelo as MODELO, a.tipo_prenda  as TIPO," +
                "a.descripcion as DESCRIPCION, a.precio_venta as PRECIO_VENTA,a.precio_proveedor as PRECIO_COMPRA, sum(c.cantidad) as CANTIDAD" +
                " from articulo a, corresponde_a c WHERE a.id_articulo=c.id_articulo " +
                " GROUP BY (a.modelo,a.descripcion,a.tipo_prenda,a.precio_venta,a.precio_proveedor) order by a.modelo;").DefaultView;
            //lista.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
        private void busqueda(object sender, RoutedEventArgs e)
        {

            lista.ItemsSource = con.QueryTable("SELECT a.modelo as MODELO, a.tipo_prenda  as TIPO,a.precio_venta as PRECIO_VENTA," +
                "a.descripcion as DESCRIPCION, a.precio_proveedor as PRECIO_COMPRA, sum(c.cantidad) as CANTIDAD from articulo a, corresponde_a c WHERE a.id_articulo=c.id_articulo" +
                " and a.tipo_prenda ='"+tiposList.SelectedValue+"' GROUP BY (a.modelo,a.descripcion,a.tipo_prenda,a.precio_venta,a.precio_proveedor) order by a.modelo;").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void clearSearch(object sender, RoutedEventArgs e)
        {
            tiposList.SelectedValue="";
            lista.ItemsSource = con.QueryTable("SELECT a.modelo as MODELO, a.tipo_prenda  as TIPO," +
                "a.descripcion as DESCRIPCION, a.precio_venta as PRECIO_VENTA,a.precio_proveedor as PRECIO_COMPRA, sum(c.cantidad) as CANTIDAD" +
                " from articulo a, corresponde_a c WHERE a.id_articulo=c.id_articulo " +
                " GROUP BY (a.modelo,a.descripcion,a.tipo_prenda,a.precio_venta,a.precio_proveedor) order by a.modelo;").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
        }

        
    }
}
