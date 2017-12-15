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
    /// Interaction logic for preferences.xaml
    /// </summary>
    public partial class preferences : Window
    {
        public preferences()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
