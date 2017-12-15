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
    /// Interaction logic for procedure4.xaml
    /// </summary>
    public partial class procedure4 : Window
    {
        Conexion con;

        public procedure4()
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
            lista.ItemsSource = con.QueryTable($"SELECT * FROM mas_tiempo_almacen('{dias.Text}','{cant.Text}');").DefaultView;
        }
    }
}
