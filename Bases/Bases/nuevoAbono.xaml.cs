using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for nuevoAbono.xaml
    /// </summary>
    public partial class nuevoAbono : Window
    {
        Conexion con;
        string idCliente = "";
        string idApartado = "";
        string cantTotal = "";
        public nuevoAbono()
        {
            InitializeComponent();
            con = new Conexion();
            selec1.IsEnabled = false;
            selec2.IsEnabled = false;
            agregar.IsEnabled = false;
        }

        private void atras_Click(object sender, RoutedEventArgs e)
        {
            con.CloseConection();
            this.Close();
        }
        private void buscarNombre(object sender, RoutedEventArgs e)
        {
            lista.ItemsSource = con.QueryTable("SELECT * FROM cliente WHERE nombre ilike '%" + nombre.Text + "%'").DefaultView;
            lista.Columns[0].Visibility = Visibility.Collapsed;
            selec1.IsEnabled = true;
        }
        private void selectNombre (object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView)lista.SelectedItem;
            var idClient = selectedItem["id_cliente"].ToString();
            idCliente = idClient;
            string query = $"SELECT num_apartado, total, fecha FROM apartado where id_cliente={idClient}";
            lista2.ItemsSource = con.QueryTable(query).DefaultView;
            selec2.IsEnabled = true;

        }
        private void selectApartado (object sender, RoutedEventArgs e)
        {
            var selectedItem = (DataRowView)lista2.SelectedItem;
            var numApartado = selectedItem["num_apartado"].ToString();
            var total = selectedItem["total"].ToString();
            cantTotal = total;
            idApartado = numApartado;
            string currAbono = "";
            string sumTotal = "";
            int nextAbono = 0;
            string query = $"SELECT MAX(num_abono), SUM(total)  FROM abono WHERE num_apartado={numApartado}  ";
            NpgsqlDataReader  dataReader = con.Query(query);
            while (dataReader.Read())
            {
                currAbono = dataReader[0].ToString();
                sumTotal = dataReader[1].ToString();
            }
            dataReader.Close();
            int.TryParse(currAbono, out nextAbono);
            nextAbono++;
            numAbono.Text = nextAbono.ToString();
            abonado.Text = sumTotal;
            fecha.Text = DateTime.Now.ToShortDateString();
            agregar.IsEnabled = true;

        }
        private void abonar(object sender, RoutedEventArgs e)
        {
            /*float cantidad = 0;
            float abonofloat = 0;
            float.TryParse(cantTotal, out cantidad);
            float.TryParse(abono.Text, out abonofloat);
            if(abonofloat)*/

            string query = $"INSERT INTO abono(num_abono,num_apartado,id_cliente,total,fecha) VALUES({numAbono.Text},{idApartado},{idCliente},{abono.Text},current_date) ";
            try
            {
                con.Query(query).Close();
                MessageBox.Show("Abonado correctamente");
                abono.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
