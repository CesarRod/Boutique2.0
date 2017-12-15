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
    /// Interaction logic for funcionExtra1.xaml
    /// </summary>
    public partial class funcionExtra1 : Window
    {
        Conexion con;

        public funcionExtra1()
        {
            InitializeComponent();
            con = new Conexion();
            lista.ItemsSource = con.QueryTable("SELECT COUNT(preferencia.id_preferencia) AS Cuenta, cliente.nombre AS Nombre, cliente.apellido_paterno AS Apellido, cliente.telefono AS Telefono FROM cliente JOIN preferencia USING(id_cliente) GROUP BY cliente.id_cliente HAVING COUNT(preferencia.id_preferencia) > 3;").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
