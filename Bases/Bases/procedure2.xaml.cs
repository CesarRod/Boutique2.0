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
    /// Interaction logic for procedure2.xaml
    /// </summary>
    public partial class procedure2 : Window
    {
        Conexion con;

        public procedure2()
        {
            InitializeComponent();
            con = new Conexion();
            lista.ItemsSource = con.QueryTable($"SELECT numero_facturas_con_gasto_envio() AS NoFacturas;").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
