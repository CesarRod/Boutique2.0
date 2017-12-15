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
    /// Interaction logic for proveedoresLista.xaml
    /// </summary>
    public partial class proveedoresLista : Window
    {
        Conexion con;
        public proveedoresLista()
        {
            InitializeComponent();
            con = new Conexion();
            lista.ItemsSource = con.QueryTable("SELECT * FROM proveedor").DefaultView;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (porPedido.IsChecked.Value)
                {
                    lista.ItemsSource = con.QueryTable("Select p.nombre,p.telefono,p.ciudad,p.estado,p.calle,p.numero,p.colonia, p.cp, pp.pagina_web, pp.email from proveedor_por_pedido pp, proveedor p where pp.id_proveedor = p.id_proveedor;  ").DefaultView;
                }
                else
                {
                    lista.ItemsSource = con.QueryTable("SELECT * FROM proveedor WHERE nombre like '%" + nombre.Text + "%'").DefaultView;
                }
                
            }catch(Exception )
            {
                MessageBox.Show("No se encontro el registro", "ERROR!");
            }
            
        }
    }
}
