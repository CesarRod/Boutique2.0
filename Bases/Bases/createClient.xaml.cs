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
using System.Text.RegularExpressions;

namespace Bases
{
    /// <summary>
    /// Interaction logic for createClient.xaml
    /// </summary>
    public partial class createClient : Window
    {
        Conexion con;
        public createClient()
        {
            InitializeComponent();
            con = new Conexion();
        }

        private void addCliente(object sender, RoutedEventArgs e)
        {
            string datos = "DEFAULT,'"+name.Text + "','" + appPat.Text + "','" + appMat.Text + "','" + street.Text + "','" +
                coloniashon.Text + "','" +cp.Text+"','"+number.Text + "','" + phone.Text + "','" + email.Text + "'";

            string query = "INSERT INTO cliente(id_cliente,nombre,apellido_paterno,apellido_materno,calle," +
                "colonia,cp,numero,telefono,email) VALUES(" + datos + ");";
            try
            {
                con.Query(query);
                MessageBox.Show("Cliente agregado correctamente","Exito");
                name.Clear();
                appPat.Clear();
                appMat.Clear();
                street.Clear();
                coloniashon.Clear();
                number.Clear();
                phone.Clear();
                email.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error!");
            }


            
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
        
        public void numericValidationText(object sender, TextCompositionEventArgs e)
        {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
        }
}
}
