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
    /// Interaction logic for funcionExtra2.xaml
    /// </summary>
    public partial class funcionExtra2 : Window
    {
        Conexion con;

        public funcionExtra2()
        {
            InitializeComponent();

            con = new Conexion();
            lista.ItemsSource = con.QueryTable("SELECT num_apartado AS No, MIN(total) AS Total FROM apartado WHERE EXTRACT(MONTH FROM CURRENT_DATE) - EXTRACT(MONTH FROM fecha) < 2 GROUP BY(num_apartado) HAVING MIN(total) < 200;").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
    }
}
